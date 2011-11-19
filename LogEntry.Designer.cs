namespace TeamTrack
{
    partial class LogEntry
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogEntry));
            this.m_NameAdd = new System.Windows.Forms.ComboBox();
            this.m_LogEntryAdd = new System.Windows.Forms.TextBox();
            this.m_splitContainer = new System.Windows.Forms.SplitContainer();
            this.m_BtnAdd = new System.Windows.Forms.Button();
            this.m_logDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_logDataSet = new TeamTrack.LogDataSet();
            this.m_LogBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.m_logTableAdapter = new TeamTrack.LogDataSetTableAdapters.LogDataTableAdapter();
            this.m_historyTableAdapter = new TeamTrack.TeamTrackDataSetTableAdapters.HistoryTableAdapter();
            this.m_splitContainer.Panel1.SuspendLayout();
            this.m_splitContainer.Panel2.SuspendLayout();
            this.m_splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_logDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_logDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_LogBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // m_NameAdd
            // 
            this.m_NameAdd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_NameAdd.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.m_logDataSet, "LogData.Name", true));
            this.m_NameAdd.FormattingEnabled = true;
            this.m_NameAdd.Location = new System.Drawing.Point(12, 22);
            this.m_NameAdd.Name = "m_NameAdd";
            this.m_NameAdd.Size = new System.Drawing.Size(124, 21);
            this.m_NameAdd.TabIndex = 2;
            // 
            // m_LogEntryAdd
            // 
            this.m_LogEntryAdd.AcceptsReturn = true;
            this.m_LogEntryAdd.AcceptsTab = true;
            this.m_LogEntryAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_LogEntryAdd.Location = new System.Drawing.Point(142, 0);
            this.m_LogEntryAdd.Multiline = true;
            this.m_LogEntryAdd.Name = "m_LogEntryAdd";
            this.m_LogEntryAdd.Size = new System.Drawing.Size(718, 238);
            this.m_LogEntryAdd.TabIndex = 4;
            // 
            // m_splitContainer
            // 
            this.m_splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_splitContainer.Location = new System.Drawing.Point(0, 0);
            this.m_splitContainer.Name = "m_splitContainer";
            this.m_splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // m_splitContainer.Panel1
            // 
            this.m_splitContainer.Panel1.AutoScroll = true;
            this.m_splitContainer.Panel1.Controls.Add(this.m_logDataGridView);
            // 
            // m_splitContainer.Panel2
            // 
            this.m_splitContainer.Panel2.Controls.Add(this.m_BtnAdd);
            this.m_splitContainer.Panel2.Controls.Add(this.m_NameAdd);
            this.m_splitContainer.Panel2.Controls.Add(this.m_LogEntryAdd);
            this.m_splitContainer.Size = new System.Drawing.Size(860, 481);
            this.m_splitContainer.SplitterDistance = 239;
            this.m_splitContainer.TabIndex = 6;
            // 
            // m_BtnAdd
            // 
            this.m_BtnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_BtnAdd.AutoSize = true;
            this.m_BtnAdd.Location = new System.Drawing.Point(12, 203);
            this.m_BtnAdd.Name = "m_BtnAdd";
            this.m_BtnAdd.Size = new System.Drawing.Size(124, 23);
            this.m_BtnAdd.TabIndex = 5;
            this.m_BtnAdd.Text = "Add Log Entry";
            this.m_BtnAdd.UseVisualStyleBackColor = true;
            this.m_BtnAdd.Click += new System.EventHandler(this.m_BtnAdd_Click);
            // 
            // m_logDataGridView
            // 
            this.m_logDataGridView.AllowUserToAddRows = false;
            this.m_logDataGridView.AllowUserToDeleteRows = false;
            this.m_logDataGridView.AutoGenerateColumns = false;
            this.m_logDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.m_logDataGridView.CausesValidation = false;
            this.m_logDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_logDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.Time,
            this.dataGridViewTextBoxColumn4});
            this.m_logDataGridView.DataMember = "LogData";
            this.m_logDataGridView.DataSource = this.m_logDataSet;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.m_logDataGridView.DefaultCellStyle = dataGridViewCellStyle1;
            this.m_logDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_logDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.m_logDataGridView.Location = new System.Drawing.Point(0, 0);
            this.m_logDataGridView.Name = "m_logDataGridView";
            this.m_logDataGridView.ReadOnly = true;
            this.m_logDataGridView.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.m_logDataGridView.RowTemplate.ReadOnly = true;
            this.m_logDataGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.m_logDataGridView.Size = new System.Drawing.Size(860, 239);
            this.m_logDataGridView.TabIndex = 0;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "CID";
            this.dataGridViewTextBoxColumn1.HeaderText = "CID";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 64;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 64;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn2.HeaderText = "Name";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 64;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 64;
            // 
            // Time
            // 
            this.Time.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Time.DataPropertyName = "Time";
            this.Time.HeaderText = "Time";
            this.Time.MinimumWidth = 96;
            this.Time.Name = "Time";
            this.Time.ReadOnly = true;
            this.Time.Width = 128;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "LogEntry";
            this.dataGridViewTextBoxColumn4.HeaderText = "LogEntry";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 128;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // m_logDataSet
            // 
            this.m_logDataSet.DataSetName = "LogDataSet";
            this.m_logDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // m_LogBindingSource
            // 
            this.m_LogBindingSource.DataMember = "LogData";
            this.m_LogBindingSource.DataSource = this.m_logDataSet;
            // 
            // m_logTableAdapter
            // 
            this.m_logTableAdapter.ClearBeforeFill = true;
            // 
            // m_historyTableAdapter
            // 
            this.m_historyTableAdapter.ClearBeforeFill = true;
            // 
            // LogEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 481);
            this.ControlBox = false;
            this.Controls.Add(this.m_splitContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LogEntry";
            this.Text = "LogEntry";
            this.Load += new System.EventHandler(this.LogEntry_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LogEntry_FormClosed);
            this.m_splitContainer.Panel1.ResumeLayout(false);
            this.m_splitContainer.Panel2.ResumeLayout(false);
            this.m_splitContainer.Panel2.PerformLayout();
            this.m_splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_logDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_logDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_LogBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox m_NameAdd;
        private System.Windows.Forms.TextBox m_LogEntryAdd;
        private System.Windows.Forms.SplitContainer m_splitContainer;
        private System.Windows.Forms.Button m_BtnAdd;
        private LogDataSet m_logDataSet;
        private System.Windows.Forms.BindingSource m_LogBindingSource;
        private TeamTrack.LogDataSetTableAdapters.LogDataTableAdapter m_logTableAdapter;
        private System.Windows.Forms.DataGridView m_logDataGridView;
        private TeamTrack.TeamTrackDataSetTableAdapters.HistoryTableAdapter m_historyTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Time;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
    }
}