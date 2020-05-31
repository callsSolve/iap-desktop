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

using Google.Solutions.IapDesktop.Application.ObjectModel;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Google.Solutions.IapDesktop.Application.Services.Windows
{
    [ComVisible(false)]
    public abstract partial class SlowLoadingPane : ToolWindow
    {
        private readonly CancellationTokenSource loadCancellationTokenSource
            = new CancellationTokenSource();

        private void UpdateLoadingStatus()
        {
            this.progressLabel.Text = this.LoadingStatusText;
            this.progressBar.Value = Math.Min(100, (int)this.LoadingPercentage);
        }

        public SlowLoadingPane(string title, IServiceProvider serviceProvider)
        {
            // Show the form as normal, which presents the progress bar.
            InitializeComponent();

            this.TabText = title;
            this.DockAreas = WeifenLuo.WinFormsUI.Docking.DockAreas.Document;

            // Show status and keep updating while loading.
            UpdateLoadingStatus();
            this.timer.Start();

            LoadAsync(this.loadCancellationTokenSource.Token)
                .ContinueWith(t =>
                {
                    try
                    {
                        t.Wait();

                        // Loading succeeded. Hide the loading anomation
                        // and reveal the real form.
                        this.loadingPanel.Visible = false;
                        InitializeForm();
                    }
                    catch (Exception e)
                    {
                        // Loading failed.
                        serviceProvider
                            .GetService<IExceptionDialog>()
                            .Show(this, "Loading failed", e);
                        CloseSafely();
                    }
                    finally
                    {
                        this.timer.Stop();
                    }
                },
                CancellationToken.None,
                TaskContinuationOptions.None,
                TaskScheduler.FromCurrentSynchronizationContext()); // Continue on UI thread.
        }

        //---------------------------------------------------------------------
        // Abstract methods/properties.
        //---------------------------------------------------------------------

        protected abstract string LoadingStatusText { get; }
        protected abstract ushort LoadingPercentage { get; }

        protected abstract Task LoadAsync(CancellationToken token);

        protected abstract void InitializeForm();

        //---------------------------------------------------------------------
        // Window event handlers.
        //---------------------------------------------------------------------

        private void SlowLoadingWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.loadCancellationTokenSource.Cancel();
        }

        private void timer_Tick(object sender, EventArgs e) => UpdateLoadingStatus();

        private void SlowLoadingPane_SizeChanged(object sender, EventArgs e)
        {

            this.loadingPanel.Location = new Point(
                (this.Width - this.loadingPanel.Width) / 2,
                this.loadingPanel.Location.Y);
        }
    }
}
