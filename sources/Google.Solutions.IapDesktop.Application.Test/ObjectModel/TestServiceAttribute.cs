﻿//
// Copyright 2020 Google LLC
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

using Google.Solutions.IapDesktop.Application.ObjectModel;
using NUnit.Framework;
using System.Reflection;

namespace Google.Solutions.IapDesktop.Application.Test.ObjectModel
{
    [TestFixture]
    public class TestServiceAttribute : FixtureBase
    {
        //---------------------------------------------------------------------
        // Register singleton service.
        //---------------------------------------------------------------------

        public interface ISingletonServiceInterface { }

        [Service(typeof(ISingletonServiceInterface), ServiceLifetime.Singleton)]
        public class SingletonServiceWithInterface : ISingletonServiceInterface
        {
        }

        [Test]
        public void WhenClassAnnotatedAsSingletonServiceWithInterface_ThenServiceIsRegistered()
        {
            var registry = new ServiceRegistry();
            registry.AddExtensionAssembly(Assembly.GetExecutingAssembly());

            Assert.IsNotNull(registry.GetService<ISingletonServiceInterface>());
            Assert.AreSame(
                registry.GetService<ISingletonServiceInterface>(),
                registry.GetService<ISingletonServiceInterface>());
            Assert.Throws<UnknownServiceException>(
                () => registry.GetService<SingletonServiceWithInterface>());
        }

        [Service(ServiceLifetime.Singleton)]
        public class SingletonService : ISingletonServiceInterface
        {
        }

        [Test]
        public void WhenClassAnnotatedAsSingletonService_ThenServiceIsRegistered()
        {
            var registry = new ServiceRegistry();
            registry.AddExtensionAssembly(Assembly.GetExecutingAssembly());

            Assert.IsNotNull(registry.GetService<SingletonService>());
            Assert.AreSame(
                registry.GetService<ISingletonServiceInterface>(),
                registry.GetService<ISingletonServiceInterface>());
        }

        //---------------------------------------------------------------------
        // Register transient service.
        //---------------------------------------------------------------------

        public interface ITransientServiceInterface { }

        [Service(typeof(ITransientServiceInterface), ServiceLifetime.Transient)]
        public class TransientServiceWithInterface : ITransientServiceInterface
        {
        }

        [Test]
        public void WhenClassAnnotatedAsTransientServiceWithInterface_ThenServiceIsRegistered()
        {
            var registry = new ServiceRegistry();
            registry.AddExtensionAssembly(Assembly.GetExecutingAssembly());

            Assert.IsNotNull(registry.GetService<ITransientServiceInterface>());
            Assert.AreNotSame(
                registry.GetService<ITransientServiceInterface>(),
                registry.GetService<ITransientServiceInterface>());
            Assert.Throws<UnknownServiceException>(
                () => registry.GetService<TransientServiceWithInterface>());
        }

        [Service(ServiceLifetime.Transient)]
        public class TransientService
        {
        }

        [Test]
        public void WhenClassAnnotatedAsTransientService_ThenServiceIsRegistered()
        {
            var registry = new ServiceRegistry();
            registry.AddExtensionAssembly(Assembly.GetExecutingAssembly());

            Assert.IsNotNull(registry.GetService<TransientService>());
            Assert.AreNotSame(
                registry.GetService<TransientService>(),
                registry.GetService<TransientService>());
        }
    }
}
