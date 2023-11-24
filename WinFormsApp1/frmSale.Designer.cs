
namespace TaxData
{
    partial class frmSale
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnLog = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtToDate = new System.Windows.Forms.MaskedTextBox();
            this.txtFromDate = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnData = new System.Windows.Forms.Button();
            this.rdbRet = new System.Windows.Forms.RadioButton();
            this.rdbSale = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.grdData = new System.Windows.Forms.DataGridView();
            this.inno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.irtaxid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.indatim = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tax17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ins = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sstid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sstt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.am = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.grdResult = new System.Windows.Forms.DataGridView();
            this.inno2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TaxId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Error_Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Reference_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Create_Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Update_Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdResult)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnLog);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.txtToDate);
            this.panel1.Controls.Add(this.txtFromDate);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnData);
            this.panel1.Controls.Add(this.rdbRet);
            this.panel1.Controls.Add(this.rdbSale);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1207, 123);
            this.panel1.TabIndex = 0;
            // 
            // btnLog
            // 
            this.btnLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLog.Location = new System.Drawing.Point(236, 45);
            this.btnLog.Name = "btnLog";
            this.btnLog.Size = new System.Drawing.Size(212, 34);
            this.btnLog.TabIndex = 11;
            this.btnLog.Text = "3 : بررسی نتیجه شماره مالیاتی صادره";
            this.btnLog.UseVisualStyleBackColor = true;
            this.btnLog.Click += new System.EventHandler(this.btnLog_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Location = new System.Drawing.Point(464, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(185, 41);
            this.label3.TabIndex = 10;
            this.label3.Text = "2 : ارسال اطلاعات از طریق سامانه معتمد مالیاتی";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(29, 45);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(194, 34);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "4 : ذخیره شماره مالیاتی صادره";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtToDate
            // 
            this.txtToDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtToDate.Location = new System.Drawing.Point(885, 76);
            this.txtToDate.Mask = "0000/00/00";
            this.txtToDate.Name = "txtToDate";
            this.txtToDate.Size = new System.Drawing.Size(87, 22);
            this.txtToDate.TabIndex = 8;
            this.txtToDate.ValidatingType = typeof(System.DateTime);
            // 
            // txtFromDate
            // 
            this.txtFromDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFromDate.Location = new System.Drawing.Point(885, 28);
            this.txtFromDate.Mask = "0000/00/00";
            this.txtFromDate.Name = "txtFromDate";
            this.txtFromDate.Size = new System.Drawing.Size(87, 22);
            this.txtFromDate.TabIndex = 7;
            this.txtFromDate.ValidatingType = typeof(System.DateTime);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(978, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 14);
            this.label2.TabIndex = 6;
            this.label2.Text = "تا تاریخ";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(978, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 14);
            this.label1.TabIndex = 4;
            this.label1.Text = "از تاریخ";
            // 
            // btnData
            // 
            this.btnData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnData.Location = new System.Drawing.Point(662, 45);
            this.btnData.Name = "btnData";
            this.btnData.Size = new System.Drawing.Size(194, 34);
            this.btnData.TabIndex = 2;
            this.btnData.Text = "1 : آماده سازی اطلاعات ارسالی";
            this.btnData.UseVisualStyleBackColor = true;
            this.btnData.Click += new System.EventHandler(this.btnData_Click);
            // 
            // rdbRet
            // 
            this.rdbRet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rdbRet.AutoSize = true;
            this.rdbRet.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.rdbRet.ForeColor = System.Drawing.Color.Red;
            this.rdbRet.Location = new System.Drawing.Point(1042, 75);
            this.rdbRet.Name = "rdbRet";
            this.rdbRet.Size = new System.Drawing.Size(128, 20);
            this.rdbRet.TabIndex = 1;
            this.rdbRet.Text = "برگشت از فروش";
            this.rdbRet.UseVisualStyleBackColor = true;
            // 
            // rdbSale
            // 
            this.rdbSale.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rdbSale.AutoSize = true;
            this.rdbSale.Checked = true;
            this.rdbSale.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.rdbSale.ForeColor = System.Drawing.Color.Blue;
            this.rdbSale.Location = new System.Drawing.Point(1090, 29);
            this.rdbSale.Name = "rdbSale";
            this.rdbSale.Size = new System.Drawing.Size(80, 20);
            this.rdbSale.TabIndex = 0;
            this.rdbSale.TabStop = true;
            this.rdbSale.Text = "فــــروش";
            this.rdbSale.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.grdData);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 123);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1207, 345);
            this.panel2.TabIndex = 1;
            // 
            // grdData
            // 
            this.grdData.AllowUserToAddRows = false;
            this.grdData.AllowUserToDeleteRows = false;
            this.grdData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.inno,
            this.irtaxid,
            this.indatim,
            this.Tax17,
            this.inty,
            this.inp,
            this.ins,
            this.sstid,
            this.sstt,
            this.am,
            this.mu,
            this.fee,
            this.dis,
            this.vra});
            this.grdData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdData.Location = new System.Drawing.Point(0, 0);
            this.grdData.Name = "grdData";
            this.grdData.ReadOnly = true;
            this.grdData.RowTemplate.Height = 25;
            this.grdData.Size = new System.Drawing.Size(1207, 345);
            this.grdData.TabIndex = 0;
            // 
            // inno
            // 
            this.inno.DataPropertyName = "inno";
            this.inno.HeaderText = "inno";
            this.inno.Name = "inno";
            this.inno.ReadOnly = true;
            this.inno.Width = 120;
            // 
            // irtaxid
            // 
            this.irtaxid.DataPropertyName = "irtaxid";
            this.irtaxid.HeaderText = "irtaxid";
            this.irtaxid.Name = "irtaxid";
            this.irtaxid.ReadOnly = true;
            this.irtaxid.Width = 120;
            // 
            // indatim
            // 
            this.indatim.DataPropertyName = "indatim";
            this.indatim.HeaderText = "indatim";
            this.indatim.Name = "indatim";
            this.indatim.ReadOnly = true;
            this.indatim.Width = 160;
            // 
            // Tax17
            // 
            this.Tax17.DataPropertyName = "Tax17";
            this.Tax17.HeaderText = "Tax17";
            this.Tax17.Name = "Tax17";
            this.Tax17.ReadOnly = true;
            // 
            // inty
            // 
            this.inty.DataPropertyName = "inty";
            this.inty.HeaderText = "inty";
            this.inty.Name = "inty";
            this.inty.ReadOnly = true;
            this.inty.Width = 60;
            // 
            // inp
            // 
            this.inp.DataPropertyName = "inp";
            this.inp.HeaderText = "inp";
            this.inp.Name = "inp";
            this.inp.ReadOnly = true;
            this.inp.Width = 60;
            // 
            // ins
            // 
            this.ins.DataPropertyName = "ins";
            this.ins.HeaderText = "ins";
            this.ins.Name = "ins";
            this.ins.ReadOnly = true;
            this.ins.Width = 60;
            // 
            // sstid
            // 
            this.sstid.DataPropertyName = "sstid";
            this.sstid.HeaderText = "sstid";
            this.sstid.Name = "sstid";
            this.sstid.ReadOnly = true;
            this.sstid.Width = 120;
            // 
            // sstt
            // 
            this.sstt.DataPropertyName = "sstt";
            this.sstt.HeaderText = "sstt";
            this.sstt.Name = "sstt";
            this.sstt.ReadOnly = true;
            this.sstt.Width = 120;
            // 
            // am
            // 
            this.am.DataPropertyName = "am";
            this.am.HeaderText = "am";
            this.am.Name = "am";
            this.am.ReadOnly = true;
            this.am.Width = 60;
            // 
            // mu
            // 
            this.mu.DataPropertyName = "mu";
            this.mu.HeaderText = "mu";
            this.mu.Name = "mu";
            this.mu.ReadOnly = true;
            this.mu.Width = 60;
            // 
            // fee
            // 
            this.fee.DataPropertyName = "fee";
            this.fee.HeaderText = "fee";
            this.fee.Name = "fee";
            this.fee.ReadOnly = true;
            // 
            // dis
            // 
            this.dis.DataPropertyName = "dis";
            this.dis.HeaderText = "dis";
            this.dis.Name = "dis";
            this.dis.ReadOnly = true;
            // 
            // vra
            // 
            this.vra.DataPropertyName = "vra";
            this.vra.HeaderText = "vra";
            this.vra.Name = "vra";
            this.vra.ReadOnly = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.grdResult);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 468);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1207, 240);
            this.panel3.TabIndex = 2;
            // 
            // grdResult
            // 
            this.grdResult.AllowUserToAddRows = false;
            this.grdResult.AllowUserToDeleteRows = false;
            this.grdResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdResult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.inno2,
            this.TaxId,
            this.Error_Description,
            this.Status,
            this.Reference_ID,
            this.Create_Time,
            this.Update_Time});
            this.grdResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdResult.Location = new System.Drawing.Point(0, 0);
            this.grdResult.Name = "grdResult";
            this.grdResult.ReadOnly = true;
            this.grdResult.RowTemplate.Height = 25;
            this.grdResult.Size = new System.Drawing.Size(1207, 240);
            this.grdResult.TabIndex = 0;
            // 
            // inno2
            // 
            this.inno2.DataPropertyName = "inno";
            this.inno2.HeaderText = "Inno";
            this.inno2.Name = "inno2";
            this.inno2.ReadOnly = true;
            this.inno2.Width = 120;
            // 
            // TaxId
            // 
            this.TaxId.DataPropertyName = "TaxId";
            this.TaxId.HeaderText = "TaxId";
            this.TaxId.Name = "TaxId";
            this.TaxId.ReadOnly = true;
            this.TaxId.Width = 200;
            // 
            // Error_Description
            // 
            this.Error_Description.DataPropertyName = "Error_Description";
            this.Error_Description.HeaderText = "Error_Description";
            this.Error_Description.Name = "Error_Description";
            this.Error_Description.ReadOnly = true;
            this.Error_Description.Width = 300;
            // 
            // Status
            // 
            this.Status.DataPropertyName = "Status";
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            // 
            // Reference_ID
            // 
            this.Reference_ID.DataPropertyName = "Reference_ID";
            this.Reference_ID.HeaderText = "Reference_ID";
            this.Reference_ID.Name = "Reference_ID";
            this.Reference_ID.ReadOnly = true;
            // 
            // Create_Time
            // 
            this.Create_Time.DataPropertyName = "Create_Time";
            this.Create_Time.HeaderText = "Create_Time";
            this.Create_Time.Name = "Create_Time";
            this.Create_Time.ReadOnly = true;
            this.Create_Time.Width = 160;
            // 
            // Update_Time
            // 
            this.Update_Time.DataPropertyName = "Update_Time";
            this.Update_Time.HeaderText = "Update_Time";
            this.Update_Time.Name = "Update_Time";
            this.Update_Time.ReadOnly = true;
            this.Update_Time.Width = 160;
            // 
            // frmSale
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1207, 708);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "frmSale";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmSale_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdResult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.MaskedTextBox txtToDate;
        private System.Windows.Forms.MaskedTextBox txtFromDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnData;
        private System.Windows.Forms.RadioButton rdbRet;
        private System.Windows.Forms.RadioButton rdbSale;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView grdData;
        private System.Windows.Forms.DataGridView grdResult;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnLog;
        private System.Windows.Forms.DataGridViewTextBoxColumn inno;
        private System.Windows.Forms.DataGridViewTextBoxColumn irtaxid;
        private System.Windows.Forms.DataGridViewTextBoxColumn indatim;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tax17;
        private System.Windows.Forms.DataGridViewTextBoxColumn inty;
        private System.Windows.Forms.DataGridViewTextBoxColumn inp;
        private System.Windows.Forms.DataGridViewTextBoxColumn ins;
        private System.Windows.Forms.DataGridViewTextBoxColumn sstid;
        private System.Windows.Forms.DataGridViewTextBoxColumn sstt;
        private System.Windows.Forms.DataGridViewTextBoxColumn am;
        private System.Windows.Forms.DataGridViewTextBoxColumn mu;
        private System.Windows.Forms.DataGridViewTextBoxColumn fee;
        private System.Windows.Forms.DataGridViewTextBoxColumn dis;
        private System.Windows.Forms.DataGridViewTextBoxColumn vra;
        private System.Windows.Forms.DataGridViewTextBoxColumn inno2;
        private System.Windows.Forms.DataGridViewTextBoxColumn TaxId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Error_Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn Reference_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Create_Time;
        private System.Windows.Forms.DataGridViewTextBoxColumn Update_Time;
    }
}