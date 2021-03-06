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

using Google.Solutions.Common.Text;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Google.Solutions.IapDesktop.Extensions.Activity.Services.SerialOutput
{
    /// <summary>
    /// Reader that extracts pure text out of a string containing
    /// ANSI escape sequences.
    /// </summary>
    public class AnsiTextReader : IAsyncReader<string>
    {
        private readonly AnsiTokenReader reader;

        public AnsiTextReader(IAsyncReader<string> reader)
        {
            this.reader = new AnsiTokenReader(reader);
        }

        public async Task<string> ReadAsync(CancellationToken token)
        {
            var tokens = await this.reader.ReadAsync(token).ConfigureAwait(false);

            return string.Join(
                string.Empty,
                tokens
                    .Where(t => t.Type == AnsiTextToken.TokenType.Text)
                    .Select(t => t.Value));
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.reader.Dispose();
            }
        }
    }
}
