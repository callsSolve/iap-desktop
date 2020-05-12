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

using Google.Solutions.Audit.Records;
using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics;

namespace Google.Solutions.Audit.Events.System
{
    public class NotifyInstanceLocationEvent : VmInstanceEventBase
    {
        public const string Method = "NotifyInstanceLocation";

        public string ServerId => base.LogRecord.ProtoPayload.Metadata["serverId"].Value<string>();

        public DateTime SchedulingTimestamp => base.LogRecord.ProtoPayload.Metadata["timestamp"].Value<DateTime>();

        internal NotifyInstanceLocationEvent(LogRecord logRecord) : base(logRecord)
        {
            Debug.Assert(IsInstanceScheduledEvent(logRecord));
        }

        public static bool IsInstanceScheduledEvent(LogRecord record)
        {
            return record.IsSystemEvent &&
                record.ProtoPayload.MethodName == Method;
        }
    }
}