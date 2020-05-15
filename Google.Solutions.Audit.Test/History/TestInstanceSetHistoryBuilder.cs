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
using Google.Solutions.LogAnalysis.Events.Lifecycle;
using Google.Solutions.LogAnalysis.History;
using Google.Solutions.LogAnalysis.Logs;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Google.Solutions.LogAnalysis.Test.History
{
    [TestFixture]
    public class TestInstanceSetHistoryBuilder
    {
        private static readonly VmInstanceReference SampleReference = new VmInstanceReference("pro", "zone", "name");
        private static readonly GlobalResourceReference SampleImage 
            = GlobalResourceReference.FromString("projects/project-1/global/images/image-1");

        [Test]
        public void WhenInstanceAdded_ThenInstanceIncludedInSet()
        {
            var b = new InstanceSetHistoryBuilder();
            b.AddExistingInstance(
                1,
                SampleReference,
                SampleImage,
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
            b.OnEvent(new StopInstanceEvent(new LogRecord()
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
            b.OnEvent(new InsertInstanceEvent(new LogRecord()
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
    }
}
