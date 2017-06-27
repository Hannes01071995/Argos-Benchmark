namespace ArgosBenchmark.ui
{
    partial class Main
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtApiBase = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.nupTotalRequests = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.nupClients = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.bStart = new System.Windows.Forms.Button();
            this.lProgress = new System.Windows.Forms.Label();
            this.Progress = new System.Windows.Forms.ProgressBar();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSqlFile = new System.Windows.Forms.TextBox();
            this.bSelectSqlFile = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupTotalRequests)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupClients)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.bSelectSqlFile);
            this.groupBox1.Controls.Add(this.txtSqlFile);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtApiBase);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(410, 97);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Argos";
            // 
            // txtApiBase
            // 
            this.txtApiBase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtApiBase.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.txtApiBase.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtApiBase.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.txtApiBase.Location = new System.Drawing.Point(100, 28);
            this.txtApiBase.Name = "txtApiBase";
            this.txtApiBase.Size = new System.Drawing.Size(303, 23);
            this.txtApiBase.TabIndex = 1;
            this.txtApiBase.Text = "http://localhost:8989/argos";
            this.txtApiBase.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtApiBase.TextChanged += new System.EventHandler(this.txtApiBase_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "API Base";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.nupTotalRequests);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.nupClients);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.groupBox2.Location = new System.Drawing.Point(12, 115);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(410, 94);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Benchmark";
            // 
            // nupTotalRequests
            // 
            this.nupTotalRequests.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nupTotalRequests.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.nupTotalRequests.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.nupTotalRequests.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nupTotalRequests.Location = new System.Drawing.Point(100, 58);
            this.nupTotalRequests.Maximum = new decimal(new int[] {
            1215752191,
            23,
            0,
            0});
            this.nupTotalRequests.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nupTotalRequests.Name = "nupTotalRequests";
            this.nupTotalRequests.Size = new System.Drawing.Size(303, 23);
            this.nupTotalRequests.TabIndex = 3;
            this.nupTotalRequests.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nupTotalRequests.ThousandsSeparator = true;
            this.nupTotalRequests.Value = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nupTotalRequests.ValueChanged += new System.EventHandler(this.nupTotalRequests_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Requests";
            // 
            // nupClients
            // 
            this.nupClients.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nupClients.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.nupClients.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.nupClients.Location = new System.Drawing.Point(100, 22);
            this.nupClients.Maximum = new decimal(new int[] {
            1215752191,
            23,
            0,
            0});
            this.nupClients.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nupClients.Name = "nupClients";
            this.nupClients.Size = new System.Drawing.Size(303, 23);
            this.nupClients.TabIndex = 1;
            this.nupClients.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nupClients.ThousandsSeparator = true;
            this.nupClients.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nupClients.ValueChanged += new System.EventHandler(this.nupClients_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Clients";
            // 
            // bStart
            // 
            this.bStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.bStart.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.bStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bStart.Location = new System.Drawing.Point(12, 215);
            this.bStart.Name = "bStart";
            this.bStart.Size = new System.Drawing.Size(78, 35);
            this.bStart.TabIndex = 2;
            this.bStart.Text = "Start";
            this.bStart.UseVisualStyleBackColor = false;
            this.bStart.Click += new System.EventHandler(this.bStart_Click);
            // 
            // lProgress
            // 
            this.lProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lProgress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.lProgress.Location = new System.Drawing.Point(109, 209);
            this.lProgress.Name = "lProgress";
            this.lProgress.Size = new System.Drawing.Size(313, 13);
            this.lProgress.TabIndex = 4;
            this.lProgress.Text = "0.00 %";
            this.lProgress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Progress
            // 
            this.Progress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Progress.Location = new System.Drawing.Point(112, 225);
            this.Progress.Maximum = 10000;
            this.Progress.Name = "Progress";
            this.Progress.Size = new System.Drawing.Size(310, 25);
            this.Progress.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 15);
            this.label4.TabIndex = 2;
            this.label4.Text = "Data Dump";
            // 
            // txtSqlFile
            // 
            this.txtSqlFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSqlFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.txtSqlFile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSqlFile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.txtSqlFile.Location = new System.Drawing.Point(100, 58);
            this.txtSqlFile.Name = "txtSqlFile";
            this.txtSqlFile.ReadOnly = true;
            this.txtSqlFile.Size = new System.Drawing.Size(216, 23);
            this.txtSqlFile.TabIndex = 3;
            this.txtSqlFile.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // bSelectSqlFile
            // 
            this.bSelectSqlFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bSelectSqlFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.bSelectSqlFile.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.bSelectSqlFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bSelectSqlFile.Location = new System.Drawing.Point(325, 58);
            this.bSelectSqlFile.Name = "bSelectSqlFile";
            this.bSelectSqlFile.Size = new System.Drawing.Size(78, 23);
            this.bSelectSqlFile.TabIndex = 5;
            this.bSelectSqlFile.Text = "...";
            this.bSelectSqlFile.UseVisualStyleBackColor = false;
            this.bSelectSqlFile.Click += new System.EventHandler(this.bSelectSqlFile_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.ClientSize = new System.Drawing.Size(434, 261);
            this.Controls.Add(this.lProgress);
            this.Controls.Add(this.Progress);
            this.Controls.Add(this.bStart);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.ShowIcon = false;
            this.Text = "Argos Benchmark";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupTotalRequests)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupClients)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtApiBase;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown nupClients;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nupTotalRequests;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button bStart;
        private System.Windows.Forms.Label lProgress;
        private System.Windows.Forms.ProgressBar Progress;
        private System.Windows.Forms.Button bSelectSqlFile;
        private System.Windows.Forms.TextBox txtSqlFile;
        private System.Windows.Forms.Label label4;
    }
}