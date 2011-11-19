namespace TeamTrack
{
    partial class AddPlace
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Dir_data = new System.Windows.Forms.TextBox();
            this.Speed_data = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.LatLon = new System.Windows.Forms.TextBox();
            this.MGRS = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ButtonOK = new System.Windows.Forms.Button();
            this.PlaceName = new System.Windows.Forms.TextBox();
            this.PlaceDesc = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Description :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Dir_data);
            this.groupBox1.Controls.Add(this.Speed_data);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.LatLon);
            this.groupBox1.Controls.Add(this.MGRS);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(12, 117);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(281, 141);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Grid/Coordinates";
            // 
            // Dir_data
            // 
            this.Dir_data.Location = new System.Drawing.Point(203, 104);
            this.Dir_data.Name = "Dir_data";
            this.Dir_data.Size = new System.Drawing.Size(54, 20);
            this.Dir_data.TabIndex = 7;
            // 
            // Speed_data
            // 
            this.Speed_data.Location = new System.Drawing.Point(78, 102);
            this.Speed_data.Name = "Speed_data";
            this.Speed_data.Size = new System.Drawing.Size(58, 20);
            this.Speed_data.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(142, 108);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Direction :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 109);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Speed :";
            // 
            // LatLon
            // 
            this.LatLon.Location = new System.Drawing.Point(78, 64);
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
            this.MGRS.Location = new System.Drawing.Point(78, 29);
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
            this.label4.Location = new System.Drawing.Point(21, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Lat/Lon :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "MGRS :";
            // 
            // ButtonOK
            // 
            this.ButtonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ButtonOK.Location = new System.Drawing.Point(115, 264);
            this.ButtonOK.Name = "ButtonOK";
            this.ButtonOK.Size = new System.Drawing.Size(75, 23);
            this.ButtonOK.TabIndex = 5;
            this.ButtonOK.Text = "OK";
            this.ButtonOK.UseVisualStyleBackColor = true;
            this.ButtonOK.Click += new System.EventHandler(this.ButtonOK_Click);
            // 
            // PlaceName
            // 
            this.PlaceName.Location = new System.Drawing.Point(80, 19);
            this.PlaceName.Name = "PlaceName";
            this.PlaceName.Size = new System.Drawing.Size(213, 20);
            this.PlaceName.TabIndex = 1;
            // 
            // PlaceDesc
            // 
            this.PlaceDesc.AcceptsReturn = true;
            this.PlaceDesc.Location = new System.Drawing.Point(80, 55);
            this.PlaceDesc.Multiline = true;
            this.PlaceDesc.Name = "PlaceDesc";
            this.PlaceDesc.Size = new System.Drawing.Size(213, 46);
            this.PlaceDesc.TabIndex = 2;
            // 
            // AddPlace
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(305, 294);
            this.Controls.Add(this.PlaceDesc);
            this.Controls.Add(this.PlaceName);
            this.Controls.Add(this.ButtonOK);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AddPlace";
            this.Text = "Add New Place";
            this.Load += new System.EventHandler(this.AddPlace_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button ButtonOK;
        private System.Windows.Forms.TextBox PlaceName;
        private System.Windows.Forms.TextBox PlaceDesc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox LatLon;
        private System.Windows.Forms.TextBox MGRS;
        private System.Windows.Forms.TextBox Dir_data;
        private System.Windows.Forms.TextBox Speed_data;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
    }
}