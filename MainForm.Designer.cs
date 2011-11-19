namespace TeamTrack
{
    partial class MainForm
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
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Tracking", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Delayed", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("Active", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup4 = new System.Windows.Forms.ListViewGroup("Places", System.Windows.Forms.HorizontalAlignment.Left);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.MainTab = new System.Windows.Forms.TabControl();
            this.StatusTab = new System.Windows.Forms.TabPage();
            this.StatusView = new System.Windows.Forms.ListView();
            this.CID = new System.Windows.Forms.ColumnHeader();
            this.TeamName = new System.Windows.Forms.ColumnHeader();
            this.Grid = new System.Windows.Forms.ColumnHeader("(none)");
            this.Time = new System.Windows.Forms.ColumnHeader();
            this.StatusContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.StopTracking = new System.Windows.Forms.ToolStripMenuItem();
            this.StartTracking = new System.Windows.Forms.ToolStripMenuItem();
            this.Remove = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.AddTeam = new System.Windows.Forms.ToolStripMenuItem();
            this.AddPlace = new System.Windows.Forms.ToolStripMenuItem();
            this.ConfigTab = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.m_ThreshAdj = new System.Windows.Forms.TrackBar();
            this.m_LeftChan = new System.Windows.Forms.ProgressBar();
            this.m_RightChan = new System.Windows.Forms.ProgressBar();
            this.m_SkipTime = new System.Windows.Forms.NumericUpDown();
            this.m_BuffTime = new System.Windows.Forms.NumericUpDown();
            this.label18 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.m_AudioDlg = new System.Windows.Forms.Button();
            this.m_AudioDir = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.m_AudioCapDevices = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.History_Time = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.History_Port = new System.Windows.Forms.TextBox();
            this.Track_Port = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Delayed_time = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.PollInterval = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ConfigComPorts = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PeriodicTimer = new System.Windows.Forms.Timer(this.components);
            this.m_SerialCommPort = new System.IO.Ports.SerialPort(this.components);
            this.m_statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripHttpStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripHistoryStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripRecStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.m_AudioFolderBrowserDlg = new System.Windows.Forms.FolderBrowserDialog();
            this.m_UVMetersTimer = new System.Windows.Forms.Timer(this.components);
            this.m_historyTableAdapter = new TeamTrack.TeamTrackDataSetTableAdapters.HistoryTableAdapter();
            this.m_mp3SoundCapture = new Istrib.Sound.Mp3SoundCapture(this.components);
            this.MainTab.SuspendLayout();
            this.StatusTab.SuspendLayout();
            this.StatusContextMenu.SuspendLayout();
            this.ConfigTab.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_ThreshAdj)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_SkipTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_BuffTime)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.m_statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainTab
            // 
            this.MainTab.Controls.Add(this.StatusTab);
            this.MainTab.Controls.Add(this.ConfigTab);
            this.MainTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTab.Location = new System.Drawing.Point(0, 0);
            this.MainTab.Name = "MainTab";
            this.MainTab.SelectedIndex = 0;
            this.MainTab.Size = new System.Drawing.Size(604, 505);
            this.MainTab.TabIndex = 0;
            // 
            // StatusTab
            // 
            this.StatusTab.Controls.Add(this.StatusView);
            this.StatusTab.Location = new System.Drawing.Point(4, 22);
            this.StatusTab.Name = "StatusTab";
            this.StatusTab.Padding = new System.Windows.Forms.Padding(3);
            this.StatusTab.Size = new System.Drawing.Size(596, 479);
            this.StatusTab.TabIndex = 0;
            this.StatusTab.Text = "Status";
            this.StatusTab.UseVisualStyleBackColor = true;
            // 
            // StatusView
            // 
            this.StatusView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.StatusView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.CID,
            this.TeamName,
            this.Grid,
            this.Time});
            this.StatusView.ContextMenuStrip = this.StatusContextMenu;
            this.StatusView.FullRowSelect = true;
            this.StatusView.GridLines = true;
            listViewGroup1.Header = "Tracking";
            listViewGroup1.Name = "Tracking";
            listViewGroup1.Tag = "Tracking";
            listViewGroup2.Header = "Delayed";
            listViewGroup2.Name = "Delayed";
            listViewGroup2.Tag = "Delayed";
            listViewGroup3.Header = "Active";
            listViewGroup3.Name = "Active";
            listViewGroup3.Tag = "Active";
            listViewGroup4.Header = "Places";
            listViewGroup4.Name = "Places";
            listViewGroup4.Tag = "Places";
            this.StatusView.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2,
            listViewGroup3,
            listViewGroup4});
            this.StatusView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.StatusView.HideSelection = false;
            this.StatusView.LabelWrap = false;
            this.StatusView.Location = new System.Drawing.Point(3, 3);
            this.StatusView.MultiSelect = false;
            this.StatusView.Name = "StatusView";
            this.StatusView.Size = new System.Drawing.Size(611, 474);
            this.StatusView.TabIndex = 0;
            this.StatusView.UseCompatibleStateImageBehavior = false;
            this.StatusView.View = System.Windows.Forms.View.Details;
            this.StatusView.DoubleClick += new System.EventHandler(this.StatusView_DoubleClick);
            // 
            // CID
            // 
            this.CID.Tag = "CID";
            this.CID.Text = "CID";
            // 
            // TeamName
            // 
            this.TeamName.Tag = "TeamName";
            this.TeamName.Text = "Team Name";
            this.TeamName.Width = 118;
            // 
            // Grid
            // 
            this.Grid.Tag = "Grid";
            this.Grid.Text = "Grid/Coord";
            this.Grid.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Grid.Width = 266;
            // 
            // Time
            // 
            this.Time.Tag = "Time";
            this.Time.Text = "Last Time";
            this.Time.Width = 149;
            // 
            // StatusContextMenu
            // 
            this.StatusContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StopTracking,
            this.StartTracking,
            this.Remove,
            this.toolStripSeparator1,
            this.AddTeam,
            this.AddPlace});
            this.StatusContextMenu.Name = "StatusContextMenu";
            this.StatusContextMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.StatusContextMenu.Size = new System.Drawing.Size(145, 120);
            this.StatusContextMenu.Text = "Action";
            this.StatusContextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.StatusContextMenu_Opening);
            // 
            // StopTracking
            // 
            this.StopTracking.Name = "StopTracking";
            this.StopTracking.Size = new System.Drawing.Size(144, 22);
            this.StopTracking.Text = "Stop tracking";
            this.StopTracking.Click += new System.EventHandler(this.StopTracking_Click);
            // 
            // StartTracking
            // 
            this.StartTracking.Name = "StartTracking";
            this.StartTracking.Size = new System.Drawing.Size(144, 22);
            this.StartTracking.Text = "Start tracking";
            this.StartTracking.Click += new System.EventHandler(this.StartTracking_Click);
            // 
            // Remove
            // 
            this.Remove.Name = "Remove";
            this.Remove.Size = new System.Drawing.Size(144, 22);
            this.Remove.Text = "Remove";
            this.Remove.Click += new System.EventHandler(this.Remove_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(141, 6);
            // 
            // AddTeam
            // 
            this.AddTeam.Name = "AddTeam";
            this.AddTeam.Size = new System.Drawing.Size(144, 22);
            this.AddTeam.Text = "AddTeam";
            this.AddTeam.Click += new System.EventHandler(this.AddTeam_Click);
            // 
            // AddPlace
            // 
            this.AddPlace.Name = "AddPlace";
            this.AddPlace.Size = new System.Drawing.Size(144, 22);
            this.AddPlace.Text = "AddPlace";
            this.AddPlace.Click += new System.EventHandler(this.AddPlace_Click);
            // 
            // ConfigTab
            // 
            this.ConfigTab.Controls.Add(this.groupBox3);
            this.ConfigTab.Controls.Add(this.groupBox2);
            this.ConfigTab.Controls.Add(this.groupBox1);
            this.ConfigTab.Location = new System.Drawing.Point(4, 22);
            this.ConfigTab.Name = "ConfigTab";
            this.ConfigTab.Padding = new System.Windows.Forms.Padding(3);
            this.ConfigTab.Size = new System.Drawing.Size(596, 479);
            this.ConfigTab.TabIndex = 1;
            this.ConfigTab.Text = "Configuration";
            this.ConfigTab.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.m_ThreshAdj);
            this.groupBox3.Controls.Add(this.m_LeftChan);
            this.groupBox3.Controls.Add(this.m_RightChan);
            this.groupBox3.Controls.Add(this.m_SkipTime);
            this.groupBox3.Controls.Add(this.m_BuffTime);
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.m_AudioDlg);
            this.groupBox3.Controls.Add(this.m_AudioDir);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.m_AudioCapDevices);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Location = new System.Drawing.Point(24, 275);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(550, 173);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Audio Settings";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(6, 141);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(57, 13);
            this.label17.TabIndex = 8;
            this.label17.Text = "Skip Time:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(239, 157);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(15, 13);
            this.label16.TabIndex = 14;
            this.label16.Text = "R";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(239, 141);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(13, 13);
            this.label15.TabIndex = 13;
            this.label15.Text = "L";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(175, 108);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(57, 13);
            this.label14.TabIndex = 11;
            this.label14.Text = "Threshold:";
            // 
            // m_ThreshAdj
            // 
            this.m_ThreshAdj.Location = new System.Drawing.Point(248, 92);
            this.m_ThreshAdj.Maximum = 100;
            this.m_ThreshAdj.Name = "m_ThreshAdj";
            this.m_ThreshAdj.Size = new System.Drawing.Size(302, 45);
            this.m_ThreshAdj.TabIndex = 12;
            this.m_ThreshAdj.TickFrequency = 4;
            this.m_ThreshAdj.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.m_ThreshAdj.Value = global::TeamTrack.Properties.Settings.Default.CaptureThreshold;
            this.m_ThreshAdj.ValueChanged += new System.EventHandler(this.VOXParams_ValueChanged);
            this.m_ThreshAdj.Scroll += new System.EventHandler(this.VOXParams_ValueChanged);
            // 
            // m_LeftChan
            // 
            this.m_LeftChan.Location = new System.Drawing.Point(258, 140);
            this.m_LeftChan.MarqueeAnimationSpeed = 10;
            this.m_LeftChan.Name = "m_LeftChan";
            this.m_LeftChan.Size = new System.Drawing.Size(286, 14);
            this.m_LeftChan.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.m_LeftChan.TabIndex = 9;
            // 
            // m_RightChan
            // 
            this.m_RightChan.Location = new System.Drawing.Point(258, 157);
            this.m_RightChan.MarqueeAnimationSpeed = 10;
            this.m_RightChan.Name = "m_RightChan";
            this.m_RightChan.Size = new System.Drawing.Size(286, 14);
            this.m_RightChan.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.m_RightChan.TabIndex = 8;
            // 
            // m_SkipTime
            // 
            this.m_SkipTime.Location = new System.Drawing.Point(90, 134);
            this.m_SkipTime.Name = "m_SkipTime";
            this.m_SkipTime.Size = new System.Drawing.Size(32, 20);
            this.m_SkipTime.TabIndex = 9;
            this.m_SkipTime.Value = global::TeamTrack.Properties.Settings.Default.SkipTime;
            this.m_SkipTime.ValueChanged += new System.EventHandler(this.VOXParams_ValueChanged);
            // 
            // m_BuffTime
            // 
            this.m_BuffTime.Location = new System.Drawing.Point(90, 101);
            this.m_BuffTime.Name = "m_BuffTime";
            this.m_BuffTime.Size = new System.Drawing.Size(32, 20);
            this.m_BuffTime.TabIndex = 6;
            this.m_BuffTime.Value = global::TeamTrack.Properties.Settings.Default.BufferTime;
            this.m_BuffTime.ValueChanged += new System.EventHandler(this.VOXParams_ValueChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(128, 141);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(24, 13);
            this.label18.TabIndex = 10;
            this.label18.Text = "sec";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(128, 108);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(24, 13);
            this.label13.TabIndex = 7;
            this.label13.Text = "sec";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 108);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(78, 13);
            this.label12.TabIndex = 5;
            this.label12.Text = "Buffering Time:";
            // 
            // m_AudioDlg
            // 
            this.m_AudioDlg.Location = new System.Drawing.Point(489, 63);
            this.m_AudioDlg.Name = "m_AudioDlg";
            this.m_AudioDlg.Size = new System.Drawing.Size(23, 20);
            this.m_AudioDlg.TabIndex = 4;
            this.m_AudioDlg.Text = "...";
            this.m_AudioDlg.UseVisualStyleBackColor = true;
            this.m_AudioDlg.Click += new System.EventHandler(this.m_AudioFolderClick);
            // 
            // m_AudioDir
            // 
            this.m_AudioDir.AllowDrop = true;
            this.m_AudioDir.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::TeamTrack.Properties.Settings.Default, "AudioDir", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.m_AudioDir.Location = new System.Drawing.Point(133, 63);
            this.m_AudioDir.Name = "m_AudioDir";
            this.m_AudioDir.Size = new System.Drawing.Size(358, 20);
            this.m_AudioDir.TabIndex = 3;
            this.m_AudioDir.Text = global::TeamTrack.Properties.Settings.Default.AudioDir;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 70);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(103, 13);
            this.label11.TabIndex = 2;
            this.label11.Text = "AudioFiles Directory:";
            // 
            // m_AudioCapDevices
            // 
            this.m_AudioCapDevices.AllowDrop = true;
            this.m_AudioCapDevices.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::TeamTrack.Properties.Settings.Default, "CaptureDevice", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.m_AudioCapDevices.FormattingEnabled = true;
            this.m_AudioCapDevices.Location = new System.Drawing.Point(134, 28);
            this.m_AudioCapDevices.MaxDropDownItems = 4;
            this.m_AudioCapDevices.Name = "m_AudioCapDevices";
            this.m_AudioCapDevices.Size = new System.Drawing.Size(378, 21);
            this.m_AudioCapDevices.TabIndex = 1;
            this.m_AudioCapDevices.Text = global::TeamTrack.Properties.Settings.Default.CaptureDevice;
            this.m_AudioCapDevices.SelectedValueChanged += new System.EventHandler(this.m_AudioCapDevices_SelectedValueChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 31);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(82, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Capture device:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.History_Time);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.History_Port);
            this.groupBox2.Controls.Add(this.Track_Port);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(24, 154);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(550, 114);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Http KML server";
            // 
            // History_Time
            // 
            this.History_Time.Location = new System.Drawing.Point(456, 73);
            this.History_Time.Name = "History_Time";
            this.History_Time.Size = new System.Drawing.Size(35, 20);
            this.History_Time.TabIndex = 5;
            this.History_Time.Text = "6";
            this.History_Time.Validated += new System.EventHandler(this.History_Port_Time_Validated);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(497, 80);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(33, 13);
            this.label9.TabIndex = 6;
            this.label9.Text = "hours";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(309, 80);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(143, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "Track Teams movement for :";
            // 
            // History_Port
            // 
            this.History_Port.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::TeamTrack.Properties.Settings.Default, "HistoryPort", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.History_Port.Location = new System.Drawing.Point(456, 44);
            this.History_Port.Name = "History_Port";
            this.History_Port.Size = new System.Drawing.Size(56, 20);
            this.History_Port.TabIndex = 3;
            this.History_Port.Text = global::TeamTrack.Properties.Settings.Default.HistoryPort;
            this.History_Port.Validated += new System.EventHandler(this.History_Port_Time_Validated);
            // 
            // Track_Port
            // 
            this.Track_Port.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::TeamTrack.Properties.Settings.Default, "TrackingPort", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Track_Port.Location = new System.Drawing.Point(159, 48);
            this.Track_Port.Name = "Track_Port";
            this.Track_Port.Size = new System.Drawing.Size(52, 20);
            this.Track_Port.TabIndex = 1;
            this.Track_Port.Text = global::TeamTrack.Properties.Settings.Default.TrackingPort;
            this.Track_Port.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Track_Port.Validated += new System.EventHandler(this.Track_Port_Validated);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(309, 50);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(97, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Team History Port :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Tracking Team Port :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.Delayed_time);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.PollInterval);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.ConfigComPorts);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(24, 33);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(550, 114);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tracking data source";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(381, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "minutes";
            // 
            // Delayed_time
            // 
            this.Delayed_time.Location = new System.Drawing.Point(325, 73);
            this.Delayed_time.Name = "Delayed_time";
            this.Delayed_time.Size = new System.Drawing.Size(50, 20);
            this.Delayed_time.TabIndex = 6;
            this.Delayed_time.Text = global::TeamTrack.Properties.Settings.Default.TeamDelayed;
            this.Delayed_time.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(302, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Consider Team delayed if not receiving SA data for more than :";
            // 
            // PollInterval
            // 
            this.PollInterval.Location = new System.Drawing.Point(396, 28);
            this.PollInterval.Name = "PollInterval";
            this.PollInterval.Size = new System.Drawing.Size(53, 20);
            this.PollInterval.TabIndex = 3;
            this.PollInterval.Text = global::TeamTrack.Properties.Settings.Default.PollingInterval;
            this.PollInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(455, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "sec";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(309, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Polling interval :";
            // 
            // ConfigComPorts
            // 
            this.ConfigComPorts.AllowDrop = true;
            this.ConfigComPorts.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::TeamTrack.Properties.Settings.Default, "ComPort", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ConfigComPorts.FormattingEnabled = true;
            this.ConfigComPorts.Location = new System.Drawing.Point(90, 28);
            this.ConfigComPorts.MaxDropDownItems = 4;
            this.ConfigComPorts.Name = "ConfigComPorts";
            this.ConfigComPorts.Size = new System.Drawing.Size(121, 21);
            this.ConfigComPorts.TabIndex = 1;
            this.ConfigComPorts.Text = global::TeamTrack.Properties.Settings.Default.ComPort;
            this.ConfigComPorts.SelectedValueChanged += new System.EventHandler(this.ConfigComPorts_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Com Port :";
            // 
            // PeriodicTimer
            // 
            this.PeriodicTimer.Enabled = true;
            this.PeriodicTimer.Interval = 5000;
            this.PeriodicTimer.Tag = "1SecondTick";
            this.PeriodicTimer.Tick += new System.EventHandler(this.PeriodicTimer_Tick);
            // 
            // m_SerialCommPort
            // 
            this.m_SerialCommPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.SerialCommlPort_DataReceived);
            // 
            // m_statusStrip
            // 
            this.m_statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatus,
            this.toolStripHttpStatus,
            this.toolStripHistoryStatus,
            this.toolStripRecStatus});
            this.m_statusStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.m_statusStrip.Location = new System.Drawing.Point(0, 483);
            this.m_statusStrip.Name = "m_statusStrip";
            this.m_statusStrip.Size = new System.Drawing.Size(604, 22);
            this.m_statusStrip.TabIndex = 1;
            this.m_statusStrip.Text = "statusStrip";
            // 
            // toolStripStatus
            // 
            this.toolStripStatus.Name = "toolStripStatus";
            this.toolStripStatus.Size = new System.Drawing.Size(84, 17);
            this.toolStripStatus.Text = "toolStripStatus";
            // 
            // toolStripHttpStatus
            // 
            this.toolStripHttpStatus.Name = "toolStripHttpStatus";
            this.toolStripHttpStatus.Size = new System.Drawing.Size(108, 17);
            this.toolStripHttpStatus.Text = "toolStripHttpStatus";
            // 
            // toolStripHistoryStatus
            // 
            this.toolStripHistoryStatus.Name = "toolStripHistoryStatus";
            this.toolStripHistoryStatus.Size = new System.Drawing.Size(122, 17);
            this.toolStripHistoryStatus.Text = "toolStripHistoryStatus";
            // 
            // toolStripRecStatus
            // 
            this.toolStripRecStatus.Name = "toolStripRecStatus";
            this.toolStripRecStatus.Size = new System.Drawing.Size(16, 17);
            this.toolStripRecStatus.Text = "...";
            // 
            // m_UVMetersTimer
            // 
            this.m_UVMetersTimer.Enabled = true;
            this.m_UVMetersTimer.Interval = 50;
            this.m_UVMetersTimer.Tick += new System.EventHandler(this.m_UVMeters_Tick);
            // 
            // m_historyTableAdapter
            // 
            this.m_historyTableAdapter.ClearBeforeFill = true;
            // 
            // m_mp3SoundCapture
            // 
            this.m_mp3SoundCapture.BufferSeconds = 4;
            this.m_mp3SoundCapture.IsDirectory = false;
            this.m_mp3SoundCapture.MinSoundSeconds = 1;
            this.m_mp3SoundCapture.NormalizeVolume = false;
            this.m_mp3SoundCapture.OutputType = Istrib.Sound.Mp3SoundCapture.Outputs.Mp3;
            this.m_mp3SoundCapture.UseSynchronizationContext = true;
            this.m_mp3SoundCapture.UseVOX = true;
            this.m_mp3SoundCapture.VOXThreshold = 300;
            this.m_mp3SoundCapture.WaitOnStop = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 505);
            this.Controls.Add(this.m_statusStrip);
            this.Controls.Add(this.MainTab);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Team Tracking";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.MainTab.ResumeLayout(false);
            this.StatusTab.ResumeLayout(false);
            this.StatusContextMenu.ResumeLayout(false);
            this.ConfigTab.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_ThreshAdj)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_SkipTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_BuffTime)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.m_statusStrip.ResumeLayout(false);
            this.m_statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl MainTab;
        private System.Windows.Forms.TabPage StatusTab;
        private System.Windows.Forms.TabPage ConfigTab;
        private System.Windows.Forms.ListView StatusView;
        private System.Windows.Forms.ColumnHeader CID;
        private System.Windows.Forms.ColumnHeader TeamName;
        private System.Windows.Forms.ColumnHeader Grid;
        private System.Windows.Forms.ColumnHeader Time;
        private System.Windows.Forms.Timer PeriodicTimer;
        private System.IO.Ports.SerialPort m_SerialCommPort;
        private System.Windows.Forms.ContextMenuStrip StatusContextMenu;
        private System.Windows.Forms.ToolStripMenuItem StopTracking;
        private System.Windows.Forms.ToolStripMenuItem StartTracking;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem Remove;
        private System.Windows.Forms.ToolStripMenuItem AddTeam;
        private System.Windows.Forms.ToolStripMenuItem AddPlace;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ConfigComPorts;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox PollInterval;
        private System.Windows.Forms.TextBox Delayed_time;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox History_Port;
        private System.Windows.Forms.TextBox Track_Port;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.StatusStrip m_statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatus;
        private System.Windows.Forms.ToolStripStatusLabel toolStripHttpStatus;
        private System.Windows.Forms.TextBox History_Time;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ToolStripStatusLabel toolStripHistoryStatus;
        private TeamTrack.TeamTrackDataSetTableAdapters.HistoryTableAdapter m_historyTableAdapter;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox m_AudioCapDevices;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.FolderBrowserDialog m_AudioFolderBrowserDlg;
        private System.Windows.Forms.Button m_AudioDlg;
        private System.Windows.Forms.TextBox m_AudioDir;
        private System.Windows.Forms.ProgressBar m_RightChan;
        private System.Windows.Forms.NumericUpDown m_BuffTime;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TrackBar m_ThreshAdj;
        private System.Windows.Forms.ProgressBar m_LeftChan;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.NumericUpDown m_SkipTime;
        private System.Windows.Forms.Label label18;
        private Istrib.Sound.Mp3SoundCapture m_mp3SoundCapture;
        private System.Windows.Forms.Timer m_UVMetersTimer;
        public System.Windows.Forms.ToolStripStatusLabel toolStripRecStatus;
    }
}

