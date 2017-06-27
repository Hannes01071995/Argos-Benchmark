namespace ArgosBenchmark.ui
{
    partial class CreateBenchmarkRun
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.nupRepetitions = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.nupTotalRequests = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.nupClients = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.bOk = new System.Windows.Forms.Button();
            this.bCancel = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupRepetitions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupTotalRequests)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupClients)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.nupRepetitions);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.nupTotalRequests);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.nupClients);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(410, 125);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Benchmark";
            // 
            // nupRepetitions
            // 
            this.nupRepetitions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nupRepetitions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.nupRepetitions.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.nupRepetitions.Location = new System.Drawing.Point(100, 88);
            this.nupRepetitions.Maximum = new decimal(new int[] {
            1215752191,
            23,
            0,
            0});
            this.nupRepetitions.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nupRepetitions.Name = "nupRepetitions";
            this.nupRepetitions.Size = new System.Drawing.Size(303, 20);
            this.nupRepetitions.TabIndex = 5;
            this.nupRepetitions.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nupRepetitions.ThousandsSeparator = true;
            this.nupRepetitions.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nupRepetitions.ValueChanged += new System.EventHandler(this.nupRepetitions_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Repetitions";
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
            this.nupTotalRequests.Size = new System.Drawing.Size(303, 20);
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
            this.label3.Size = new System.Drawing.Size(55, 13);
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
            this.nupClients.Size = new System.Drawing.Size(303, 20);
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
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Clients";
            // 
            // bOk
            // 
            this.bOk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.bOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bOk.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.bOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bOk.Location = new System.Drawing.Point(344, 143);
            this.bOk.Name = "bOk";
            this.bOk.Size = new System.Drawing.Size(78, 35);
            this.bOk.TabIndex = 3;
            this.bOk.Text = "Ok";
            this.bOk.UseVisualStyleBackColor = false;
            // 
            // bCancel
            // 
            this.bCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.bCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.bCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bCancel.Location = new System.Drawing.Point(12, 143);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(78, 35);
            this.bCancel.TabIndex = 4;
            this.bCancel.Text = "Start";
            this.bCancel.UseVisualStyleBackColor = false;
            // 
            // CreateBenchmarkRun
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.ClientSize = new System.Drawing.Size(434, 191);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.bOk);
            this.Controls.Add(this.groupBox2);
            this.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(450, 230);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(450, 230);
            this.Name = "CreateBenchmarkRun";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New Run";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupRepetitions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupTotalRequests)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupClients)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown nupRepetitions;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nupTotalRequests;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nupClients;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bOk;
        private System.Windows.Forms.Button bCancel;
    }
}