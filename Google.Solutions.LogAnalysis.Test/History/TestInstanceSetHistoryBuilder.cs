﻿//
// Copyright 2019 Google LLC
//
// Licensed to the Apache Software Foundation (ASF) under one
// or more contributor license agreements.  See the NOTICE file
// distributed with this work for additional information
// regarding copyright ownership.  The ASF licenses this file
// to you under the Apache License, Version 2.0 (the
// "License"); you may not use this file except in compliance
// with the License.  You may obtain a copy of the License at
// 
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing,
// software distributed under the License is distributed on an
// "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
// KIND, either express or implied.  See the License for the
// specific language governing permissions and limitations
// under the License.
//

using Google.Solutions.Compute;
using Google.Solutions.LogAnalysis.Events;
using Google.Solutions.LogAnalysis.Events.Lifecycle;
using Google.Solutions.LogAnalysis.Events.System;
using Google.Solutions.LogAnalysis.History;
using Google.Solutions.LogAnalysis.Logs;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Google.Solutions.LogAnalysis.Test.History
{
    [TestFixture]
    public class TestInstanceSetHistoryBuilder
    {
        private static readonly VmInstanceReference SampleReference = new VmInstanceReference("pro", "zone", "name");
        private static readonly GlobalResourceReference SampleImage
            = GlobalResourceReference.FromString("projects/project-1/global/images/image-1");

        private static InstanceSetHistory BuildHistoryFromResource(string resourceName)
        {
            var testDataResource = Assembly.GetExecutingAssembly()
                .GetManifestResourceNames()
                .First(n => n.EndsWith(resourceName));

            var b = new InstanceSetHistoryBuilder();

            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(testDataResource))
            using (var reader = new JsonTextReader(new StreamReader(stream)))
            {
                var events = new JsonSerializer().Deserialize<LogRecord[]>(reader)
                    .Select(rec => rec.ToEvent())
                    .OrderByDescending(e => e.Timestamp);

                foreach (var e in events)
                {
                    b.Process(e);
                }
            }

            return b.Build();
        }

        [Test]
        public void WhenInstanceAdded_ThenInstanceIncludedInSet()
        {
            var b = new InstanceSetHistoryBuilder();
            b.AddExistingInstance(
                1,
                SampleReference,
                SampleImage,
                InstanceState.Terminated,
                DateTime.Now,
                Tenancy.Fleet);

            var set = b.Build();

            Assert.AreEqual(0, set.InstancesWithIncompleteInformation.Count());
            Assert.AreEqual(1, set.Instances.Count());
            Assert.AreEqual(1, set.Instances.First().InstanceId);
        }

        [Test]
        public void WhenInstanceNotAddedButStopEventRecorded_ThenInstanceIncludedInSetAsIncomplete()
        {
            var b = new InstanceSetHistoryBuilder();
            b.Process(new StopInstanceEvent(new LogRecord()
            {
                LogName = "projects/project-1/logs/cloudaudit.googleapis.com%2Factivity",
                ProtoPayload = new AuditLogRecord()
                {
                    MethodName = StopInstanceEvent.Method,
                    ResourceName = "projects/project-1/zones/us-central1-a/instances/instance-1"
                },
                Resource = new ResourceRecord()
                {
                    Labels = new Dictionary<string, string>
                    {
                        { "instance_id", "123" }
                    }
                },
                Timestamp = new DateTime(2019, 12, 31)
            }));

            var set = b.Build();

            Assert.AreEqual(1, set.InstancesWithIncompleteInformation.Count());
            Assert.AreEqual(0, set.Instances.Count());
            Assert.AreEqual(123, set.InstancesWithIncompleteInformation.First().InstanceId);
        }

        [Test]
        public void WhenInstanceNotAddedButInsertEventRecorded_ThenInstanceIncludedInSet()
        {
            var b = new InstanceSetHistoryBuilder();
            b.Process(new InsertInstanceEvent(new LogRecord()
            {
                LogName = "projects/project-1/logs/cloudaudit.googleapis.com%2Factivity",
                ProtoPayload = new AuditLogRecord()
                {
                    MethodName = InsertInstanceEvent.Method,
                    ResourceName = "projects/project-1/zones/us-central1-a/instances/instance-1",
                },
                Resource = new ResourceRecord()
                {
                    Labels = new Dictionary<string, string>
                    {
                        { "instance_id", "123" }
                    }
                },
                Timestamp = new DateTime(2019, 12, 31)
            }));

            var set = b.Build();

            Assert.AreEqual(0, set.InstancesWithIncompleteInformation.Count());
            Assert.AreEqual(1, set.Instances.Count());
            Assert.AreEqual(123, set.Instances.First().InstanceId);
        }

        [Test]
        public void WhenReadingSample1_ThenHistoryIsRestored()
        {
            var set = BuildHistoryFromResource("instance-1.json");

            Assert.AreEqual(1, set.Instances.Count());
            Assert.AreEqual(0, set.InstancesWithIncompleteInformation.Count());

            var instance = set.Instances.First();
            Assert.AreEqual(Tenancy.SoleTenant, instance.Tenancy);
            Assert.AreEqual(
                GlobalResourceReference.FromString("projects/windows-cloud/global/images/windows-server"),
                instance.Image);
            Assert.AreEqual(1, instance.Placements.Count());

            var placement = (SoleTenantPlacement)instance.Placements.First();
            Assert.AreEqual("15934ff9aee7d8c5719fad1053b7fc7d", placement.ServerId);

            // NotifyInstanceLocation..
            Assert.AreEqual(DateTime.Parse("2020-05-06T14:58:55.490Z").ToUniversalTime(), placement.From);

            // ..till
            Assert.AreEqual(DateTime.Parse("2020-05-15T10:57:06.997Z").ToUniversalTime(), placement.To);
        }

        [Test]
        public void WhenReadingSample2_ThenHistoryIsRestored()
        {
            var set = BuildHistoryFromResource("instance-2.json");
            Assert.AreEqual(1, set.Instances.Count());
            Assert.AreEqual(0, set.InstancesWithIncompleteInformation.Count());

            var instance = set.Instances.First();
            Assert.AreEqual(Tenancy.SoleTenant, instance.Tenancy);
            Assert.AreEqual(
                GlobalResourceReference.FromString("projects/windows-cloud/global/images/windows-server"),
                instance.Image);
            Assert.AreEqual(1, instance.Placements.Count());

            var placement = (SoleTenantPlacement)instance.Placements.First();
            Assert.AreEqual("15934ff9aee7d8c5719fad1053b7fc7d", placement.ServerId);

            // NotifyInstanceLocation..
            Assert.AreEqual(DateTime.Parse("2020-05-06T14:57:49.149Z").ToUniversalTime(), placement.From);

            // ..till GuestTerminate.
            Assert.AreEqual(DateTime.Parse("2020-05-06T16:03:06.484Z").ToUniversalTime(), placement.To);
        }

        [Test]
        public void WhenReadingSample3_ThenHistoryIsRestored()
        {
            var set = BuildHistoryFromResource("instance-3.json");
            Assert.AreEqual(1, set.Instances.Count());
            Assert.AreEqual(0, set.InstancesWithIncompleteInformation.Count());

            var instance = set.Instances.First();
            Assert.AreEqual(Tenancy.SoleTenant, instance.Tenancy);
            Assert.AreEqual(
                GlobalResourceReference.FromString("projects/project-1/global/images/windows-server"),
                instance.Image);
            Assert.AreEqual(2, instance.Placements.Count());

            var firstPlacement = (SoleTenantPlacement)instance.Placements.First();
            Assert.AreEqual("413db7b32a208e7ccb4ee62acedee725", firstPlacement.ServerId);

            // NotifyInstanceLocation..
            Assert.AreEqual(DateTime.Parse("2020-05-05T08:31:43.735Z").ToUniversalTime(), firstPlacement.From);

            // ..till TerminateOnHostMaintenance.
            Assert.AreEqual(DateTime.Parse("2020-05-06T16:10:46.781Z").ToUniversalTime(), firstPlacement.To);


            var secondPlacement = (SoleTenantPlacement)instance.Placements.Last();
            Assert.AreEqual("413db7b32a208e7ccb4ee62acedee725", secondPlacement.ServerId);

            // NotifyInstanceLocation..
            Assert.AreEqual(DateTime.Parse("2020-05-06T16:36:01.441Z").ToUniversalTime(), secondPlacement.From);

            // ..till GuestTerminate.
            Assert.AreEqual(DateTime.Parse("2020-05-06T17:39:34.635Z").ToUniversalTime(), secondPlacement.To);
        }

        [Test]
        public void SupportedMethodsIncludeSystemAndLifecycleEvents()
        {
            var b = new InstanceSetHistoryBuilder();

            CollectionAssert.Contains(b.SupportedMethods, NotifyInstanceLocationEvent.Method);
            CollectionAssert.Contains(b.SupportedMethods, HostErrorEvent.Method);

            CollectionAssert.Contains(b.SupportedMethods, InsertInstanceEvent.Method);
            CollectionAssert.Contains(b.SupportedMethods, DeleteInstanceEvent.Method);
        }
    }
}
