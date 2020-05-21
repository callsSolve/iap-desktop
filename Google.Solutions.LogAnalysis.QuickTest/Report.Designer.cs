﻿using Google.Solutions.IapDesktop.Application.Services.Windows;

namespace Google.Solutions.LogAnalysis.QuickTest
{
    partial class Report
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.includeFleetVmInstancesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.includeSoleTenantVmInstancesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chartLabel = new System.Windows.Forms.Label();
            this.nodesList = new FlatListView();
            this.serverIdColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.nodeZoneColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.nodeProjectIdColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.firstUseColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lastUseColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.daysUsedColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.peakInstancesColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.nodePlacementsList = new FlatListView();
            this.instanceIdColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.instanceNameColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.instanceZoneColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.instanceProjectIdColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.placedFromColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.placedUntilColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.nodesLabel = new System.Windows.Forms.Label();
            this.nodePlacementsLabel = new System.Windows.Forms.Label();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.tabControl = new Google.Solutions.IapDesktop.Application.Services.Windows.FlatVerticalTabControl();
            this.instancesTabPage = new System.Windows.Forms.TabPage();
            this.nodesTabPage = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.chartMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // chart
            // 
            this.chart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chart.BackColor = System.Drawing.SystemColors.Control;
            chartArea1.AxisX.MajorGrid.Enabled = false;
            chartArea1.AxisX.ScaleView.Zoomable = false;
            chartArea1.AxisY.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.SystemColors.ControlDarkDark;
            chartArea1.AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            chartArea1.BackColor = System.Drawing.SystemColors.Control;
            chartArea1.BorderColor = System.Drawing.Color.DimGray;
            chartArea1.CursorX.IsUserSelectionEnabled = true;
            chartArea1.Name = "mainArea";
            chartArea1.Position.Auto = false;
            chartArea1.Position.Height = 94F;
            chartArea1.Position.Width = 100F;
            chartArea1.Position.Y = 3F;
            this.chart.ChartAreas.Add(chartArea1);
            this.chart.ContextMenuStrip = this.chartMenu;
            this.chart.Location = new System.Drawing.Point(146, 30);
            this.chart.Name = "chart";
            this.chart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Grayscale;
            series1.ChartArea = "mainArea";
            series1.Name = "Series1";
            this.chart.Series.Add(series1);
            this.chart.Size = new System.Drawing.Size(914, 300);
            this.chart.TabIndex = 0;
            this.chart.GetToolTipText += new System.EventHandler<System.Windows.Forms.DataVisualization.Charting.ToolTipEventArgs>(this.chart_GetToolTipText);
            this.chart.SelectionRangeChanged += new System.EventHandler<System.Windows.Forms.DataVisualization.Charting.CursorEventArgs>(this.nodesByDay_SelectionRangeChanged);
            // 
            // chartMenu
            // 
            this.chartMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.includeFleetVmInstancesMenuItem,
            this.includeSoleTenantVmInstancesMenuItem});
            this.chartMenu.Name = "chartMenu";
            this.chartMenu.Size = new System.Drawing.Size(213, 48);
            this.chartMenu.Opening += new System.ComponentModel.CancelEventHandler(this.chartMenu_Opening);
            // 
            // includeFleetVmInstancesMenuItem
            // 
            this.includeFleetVmInstancesMenuItem.Checked = true;
            this.includeFleetVmInstancesMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.includeFleetVmInstancesMenuItem.Name = "includeFleetVmInstancesMenuItem";
            this.includeFleetVmInstancesMenuItem.Size = new System.Drawing.Size(212, 22);
            this.includeFleetVmInstancesMenuItem.Text = "On-demand VM instances";
            this.includeFleetVmInstancesMenuItem.Click += new System.EventHandler(this.includeInstancesMenuItem_Click);
            // 
            // includeSoleTenantVmInstancesMenuItem
            // 
            this.includeSoleTenantVmInstancesMenuItem.Checked = true;
            this.includeSoleTenantVmInstancesMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.includeSoleTenantVmInstancesMenuItem.Name = "includeSoleTenantVmInstancesMenuItem";
            this.includeSoleTenantVmInstancesMenuItem.Size = new System.Drawing.Size(212, 22);
            this.includeSoleTenantVmInstancesMenuItem.Text = "Sole-tenant VM instances";
            this.includeSoleTenantVmInstancesMenuItem.Click += new System.EventHandler(this.includeInstancesMenuItem_Click);
            // 
            // chartLabel
            // 
            this.chartLabel.AutoSize = true;
            this.chartLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chartLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.chartLabel.Location = new System.Drawing.Point(146, 9);
            this.chartLabel.Name = "chartLabel";
            this.chartLabel.Size = new System.Drawing.Size(23, 18);
            this.chartLabel.TabIndex = 1;
            this.chartLabel.Text = "...";
            // 
            // nodesList
            // 
            this.nodesList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nodesList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.serverIdColumnHeader,
            this.nodeZoneColumnHeader,
            this.nodeProjectIdColumnHeader,
            this.firstUseColumnHeader,
            this.lastUseColumnHeader,
            this.daysUsedColumnHeader,
            this.peakInstancesColumnHeader});
            this.nodesList.FullRowSelect = true;
            this.nodesList.HideSelection = false;
            this.nodesList.Location = new System.Drawing.Point(12, 32);
            this.nodesList.Name = "nodesList";
            this.nodesList.Size = new System.Drawing.Size(892, 246);
            this.nodesList.TabIndex = 2;
            this.nodesList.UseCompatibleStateImageBehavior = false;
            this.nodesList.View = System.Windows.Forms.View.Details;
            this.nodesList.SelectedIndexChanged += new System.EventHandler(this.nodesList_SelectedIndexChanged);
            this.nodesList.Click += new System.EventHandler(this.nodesList_Click);
            // 
            // serverIdColumnHeader
            // 
            this.serverIdColumnHeader.Text = "Server ID";
            this.serverIdColumnHeader.Width = 150;
            // 
            // nodeZoneColumnHeader
            // 
            this.nodeZoneColumnHeader.Text = "Zone";
            this.nodeZoneColumnHeader.Width = 80;
            // 
            // nodeProjectIdColumnHeader
            // 
            this.nodeProjectIdColumnHeader.Text = "Project Id";
            this.nodeProjectIdColumnHeader.Width = 120;
            // 
            // firstUseColumnHeader
            // 
            this.firstUseColumnHeader.Text = "First use (UTC)";
            this.firstUseColumnHeader.Width = 130;
            // 
            // lastUseColumnHeader
            // 
            this.lastUseColumnHeader.Text = "Last Use (UTC)";
            this.lastUseColumnHeader.Width = 130;
            // 
            // daysUsedColumnHeader
            // 
            this.daysUsedColumnHeader.Text = "Days used";
            this.daysUsedColumnHeader.Width = 70;
            // 
            // peakInstancesColumnHeader
            // 
            this.peakInstancesColumnHeader.Text = "Peak VMs";
            this.peakInstancesColumnHeader.Width = 80;
            // 
            // nodePlacementsList
            // 
            this.nodePlacementsList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nodePlacementsList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.instanceIdColumnHeader,
            this.instanceNameColumnHeader,
            this.instanceZoneColumnHeader,
            this.instanceProjectIdColumnHeader,
            this.placedFromColumnHeader,
            this.placedUntilColumnHeader});
            this.nodePlacementsList.FullRowSelect = true;
            this.nodePlacementsList.HideSelection = false;
            this.nodePlacementsList.Location = new System.Drawing.Point(12, 31);
            this.nodePlacementsList.Name = "nodePlacementsList";
            this.nodePlacementsList.Size = new System.Drawing.Size(892, 244);
            this.nodePlacementsList.TabIndex = 2;
            this.nodePlacementsList.UseCompatibleStateImageBehavior = false;
            this.nodePlacementsList.View = System.Windows.Forms.View.Details;
            // 
            // instanceIdColumnHeader
            // 
            this.instanceIdColumnHeader.Text = "Instance ID";
            this.instanceIdColumnHeader.Width = 120;
            // 
            // instanceNameColumnHeader
            // 
            this.instanceNameColumnHeader.Text = "Instance name";
            this.instanceNameColumnHeader.Width = 130;
            // 
            // instanceZoneColumnHeader
            // 
            this.instanceZoneColumnHeader.Text = "Zone";
            this.instanceZoneColumnHeader.Width = 80;
            // 
            // instanceProjectIdColumnHeader
            // 
            this.instanceProjectIdColumnHeader.Text = "Project Id";
            this.instanceProjectIdColumnHeader.Width = 120;
            // 
            // placedFromColumnHeader
            // 
            this.placedFromColumnHeader.Text = "From (UTC)";
            this.placedFromColumnHeader.Width = 130;
            // 
            // placedUntilColumnHeader
            // 
            this.placedUntilColumnHeader.Text = "To (UTC)";
            this.placedUntilColumnHeader.Width = 130;
            // 
            // nodesLabel
            // 
            this.nodesLabel.AutoSize = true;
            this.nodesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nodesLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.nodesLabel.Location = new System.Drawing.Point(9, 10);
            this.nodesLabel.Name = "nodesLabel";
            this.nodesLabel.Size = new System.Drawing.Size(102, 18);
            this.nodesLabel.TabIndex = 1;
            this.nodesLabel.Text = "Node details";
            // 
            // nodePlacementsLabel
            // 
            this.nodePlacementsLabel.AutoSize = true;
            this.nodePlacementsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nodePlacementsLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.nodePlacementsLabel.Location = new System.Drawing.Point(9, 9);
            this.nodePlacementsLabel.Name = "nodePlacementsLabel";
            this.nodePlacementsLabel.Size = new System.Drawing.Size(272, 18);
            this.nodePlacementsLabel.TabIndex = 1;
            this.nodePlacementsLabel.Text = "Scheduling history of VM instances";
            // 
            // splitContainer
            // 
            this.splitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer.Location = new System.Drawing.Point(146, 339);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.nodesLabel);
            this.splitContainer.Panel1.Controls.Add(this.nodesList);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.nodePlacementsList);
            this.splitContainer.Panel2.Controls.Add(this.nodePlacementsLabel);
            this.splitContainer.Size = new System.Drawing.Size(916, 565);
            this.splitContainer.SplitterDistance = 281;
            this.splitContainer.TabIndex = 3;
            // 
            // tabControl
            // 
            this.tabControl.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabControl.Controls.Add(this.instancesTabPage);
            this.tabControl.Controls.Add(this.nodesTabPage);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.ItemSize = new System.Drawing.Size(44, 136);
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Multiline = true;
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1072, 911);
            this.tabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl.TabIndex = 4;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // instancesTabPage
            // 
            this.instancesTabPage.Location = new System.Drawing.Point(140, 4);
            this.instancesTabPage.Name = "instancesTabPage";
            this.instancesTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.instancesTabPage.Size = new System.Drawing.Size(928, 903);
            this.instancesTabPage.TabIndex = 1;
            this.instancesTabPage.Text = "Instances";
            this.instancesTabPage.UseVisualStyleBackColor = true;
            // 
            // nodesTabPage
            // 
            this.nodesTabPage.Location = new System.Drawing.Point(140, 4);
            this.nodesTabPage.Name = "nodesTabPage";
            this.nodesTabPage.Size = new System.Drawing.Size(928, 903);
            this.nodesTabPage.TabIndex = 2;
            this.nodesTabPage.Text = "Sole-tenant nodes";
            this.nodesTabPage.UseVisualStyleBackColor = true;
            // 
            // Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(810, 880);
            this.ClientSize = new System.Drawing.Size(1072, 911);
            this.Controls.Add(this.chartLabel);
            this.Controls.Add(this.chart);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.tabControl);
            this.Name = "Report";
            this.Text = "Report";
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.chartMenu.ResumeLayout(false);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel1.PerformLayout();
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.Label chartLabel;
        private FlatListView nodesList;
        private System.Windows.Forms.ColumnHeader serverIdColumnHeader;
        private System.Windows.Forms.ColumnHeader firstUseColumnHeader;
        private System.Windows.Forms.ColumnHeader lastUseColumnHeader;
        private System.Windows.Forms.ColumnHeader peakInstancesColumnHeader;
        private System.Windows.Forms.ColumnHeader daysUsedColumnHeader;
        private FlatListView nodePlacementsList;
        private System.Windows.Forms.ColumnHeader instanceIdColumnHeader;
        private System.Windows.Forms.ColumnHeader instanceNameColumnHeader;
        private System.Windows.Forms.ColumnHeader instanceZoneColumnHeader;
        private System.Windows.Forms.ColumnHeader instanceProjectIdColumnHeader;
        private System.Windows.Forms.ColumnHeader placedFromColumnHeader;
        private System.Windows.Forms.ColumnHeader placedUntilColumnHeader;
        private System.Windows.Forms.ColumnHeader nodeZoneColumnHeader;
        private System.Windows.Forms.ColumnHeader nodeProjectIdColumnHeader;
        private System.Windows.Forms.Label nodesLabel;
        private System.Windows.Forms.Label nodePlacementsLabel;
        private System.Windows.Forms.SplitContainer splitContainer;
        private IapDesktop.Application.Services.Windows.FlatVerticalTabControl tabControl;
        private System.Windows.Forms.TabPage instancesTabPage;
        private System.Windows.Forms.TabPage nodesTabPage;
        private System.Windows.Forms.ContextMenuStrip chartMenu;
        private System.Windows.Forms.ToolStripMenuItem includeFleetVmInstancesMenuItem;
        private System.Windows.Forms.ToolStripMenuItem includeSoleTenantVmInstancesMenuItem;
    }
}