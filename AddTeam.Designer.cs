namespace TeamTrack
{
    partial class AddTeam
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
            this.Dir_data = new System.Windows.Forms.TextBox();
            this.Speed_data = new System.Windows.Forms.TextBox();
            this.TeamDesc = new System.Windows.Forms.TextBox();
            this.TeamName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ButtonOK = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LatLon = new System.Windows.Forms.TextBox();
            this.MGRS = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TeamMembers = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.Label44 = new System.Windows.Forms.Label();
            this.CID = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.Place = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Dir_data
            // 
            this.Dir_data.Location = new System.Drawing.Point(203, 112);
            this.Dir_data.Name = "Dir_data";
            this.Dir_data.Size = new System.Drawing.Size(54, 20);
            this.Dir_data.TabIndex = 7;
            // 
            // Speed_data
            // 
            this.Speed_data.Location = new System.Drawing.Point(78, 110);
            this.Speed_data.Name = "Speed_data";
            this.Speed_data.Size = new System.Drawing.Size(58, 20);
            this.Speed_data.TabIndex = 5;
            // 
            // TeamDesc
            // 
            this.TeamDesc.AcceptsReturn = true;
            this.TeamDesc.Location = new System.Drawing.Point(70, 71);
            this.TeamDesc.Multiline = true;
            this.TeamDesc.Name = "TeamDesc";
            this.TeamDesc.Size = new System.Drawing.Size(221, 43);
            this.TeamDesc.TabIndex = 5;
            // 
            // TeamName
            // 
            this.TeamName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TeamName.Location = new System.Drawing.Point(70, 6);
            this.TeamName.Name = "TeamName";
            this.TeamName.Size = new System.Drawing.Size(221, 20);
            this.TeamName.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(142, 116);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Direction :";
            // 
            // ButtonOK
            // 
            this.ButtonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ButtonOK.Location = new System.Drawing.Point(109, 366);
            this.ButtonOK.Name = "ButtonOK";
            this.ButtonOK.Size = new System.Drawing.Size(75, 25);
            this.ButtonOK.TabIndex = 9;
            this.ButtonOK.Text = "OK";
            this.ButtonOK.UseVisualStyleBackColor = true;
            this.ButtonOK.Click += new System.EventHandler(this.ButtonOK_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 117);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Speed :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Place);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.Dir_data);
            this.groupBox1.Controls.Add(this.Speed_data);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.LatLon);
            this.groupBox1.Controls.Add(this.MGRS);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(10, 214);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(281, 146);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Grid/Coordinates";
            // 
            // LatLon
            // 
            this.LatLon.Location = new System.Drawing.Point(78, 80);
            this.LatLon.Name = "LatLon";
            this.LatLon.Size = new System.Drawing.Size(179, 20);
            this.LatLon.TabIndex = 3;
            this.LatLon.Validated += new System.EventHandler(this.LatLon_Validated);
            this.LatLon.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LatLon_KeyDown);
            this.LatLon.Validating += new System.ComponentModel.CancelEventHandler(this.LatLon_Validating);
            // 
            // MGRS
            // 
            this.MGRS.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.MGRS.Location = new System.Drawing.Point(78, 17);
            this.MGRS.Name = "MGRS";
            this.MGRS.Size = new System.Drawing.Size(179, 20);
            this.MGRS.TabIndex = 1;
            this.MGRS.TextChanged += new System.EventHandler(this.MGRS_TextChanged);
            this.MGRS.Validated += new System.EventHandler(this.MGRS_Validated);
            this.MGRS.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MGRS_KeyDown);
            this.MGRS.Validating += new System.ComponentModel.CancelEventHandler(this.MGRS_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Lat/Lon :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "MGRS :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Description :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Team :";
            // 
            // TeamMembers
            // 
            this.TeamMembers.AcceptsReturn = true;
            this.TeamMembers.Location = new System.Drawing.Point(70, 124);
            this.TeamMembers.Multiline = true;
            this.TeamMembers.Name = "TeamMembers";
            this.TeamMembers.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TeamMembers.Size = new System.Drawing.Size(221, 80);
            this.TeamMembers.TabIndex = 7;
            this.TeamMembers.WordWrap = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(2, 127);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Members :";
            // 
            // Label44
            // 
            this.Label44.AutoSize = true;
            this.Label44.Location = new System.Drawing.Point(2, 44);
            this.Label44.Name = "Label44";
            this.Label44.Size = new System.Drawing.Size(63, 13);
            this.Label44.TabIndex = 2;
            this.Label44.Text = "Combat ID :";
            // 
            // CID
            // 
            this.CID.Location = new System.Drawing.Point(70, 37);
            this.CID.Name = "CID";
            this.CID.Size = new System.Drawing.Size(100, 20);
            this.CID.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(21, 55);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "Place :";
            // 
            // Place
            // 
            this.Place.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Place.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Place.FormattingEnabled = true;
            this.Place.Location = new System.Drawing.Point(78, 48);
            this.Place.Name = "Place";
            this.Place.Size = new System.Drawing.Size(179, 21);
            this.Place.TabIndex = 9;
            this.Place.SelectionChangeCommitted += new System.EventHandler(this.Place_SelectionChangeCommitted);
            // 
            // AddTeam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(303, 403);
            this.Controls.Add(this.CID);
            this.Controls.Add(this.Label44);
            this.Controls.Add(this.TeamMembers);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.TeamDesc);
            this.Controls.Add(this.TeamName);
            this.Controls.Add(this.ButtonOK);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddTeam";
            this.Text = "AddTeam";
            this.Load += new System.EventHandler(this.AddTeam_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Dir_data;
        private System.Windows.Forms.TextBox Speed_data;
        private System.Windows.Forms.TextBox TeamDesc;
        private System.Windows.Forms.TextBox TeamName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button ButtonOK;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox LatLon;
        private System.Windows.Forms.TextBox MGRS;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TeamMembers;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label Label44;
        private System.Windows.Forms.TextBox CID;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.ComboBox Place;
    }
}