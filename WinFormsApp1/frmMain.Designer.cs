
namespace TaxData
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnDirect = new System.Windows.Forms.ToolStripButton();
            this.btnTis = new System.Windows.Forms.ToolStripButton();
            this.btnExist = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnDirect,
            this.btnTis,
            this.btnExist});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(871, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnDirect
            // 
            this.btnDirect.Image = global::TaxData.Properties.Resources.document_add;
            this.btnDirect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDirect.Name = "btnDirect";
            this.btnDirect.Size = new System.Drawing.Size(137, 22);
            this.btnDirect.Text = "تبادل اطلاعات مستقیم";
            this.btnDirect.Click += new System.EventHandler(this.btnDirect_Click);
            // 
            // btnTis
            // 
            this.btnTis.Image = global::TaxData.Properties.Resources.document_add;
            this.btnTis.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTis.Name = "btnTis";
            this.btnTis.Size = new System.Drawing.Size(164, 22);
            this.btnTis.Text = "تبادل اطلاعات فروش با تیس";
            this.btnTis.Click += new System.EventHandler(this.btnTis_Click);
            // 
            // btnExist
            // 
            this.btnExist.Image = global::TaxData.Properties.Resources.cancel;
            this.btnExist.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExist.Name = "btnExist";
            this.btnExist.Size = new System.Drawing.Size(70, 22);
            this.btnExist.Text = "خـــــــــروج";
            this.btnExist.Click += new System.EventHandler(this.btnExist_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::TaxData.Properties.Resources.Gimporter;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(871, 649);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تبادل اطلاعات فروش با سازمان امور مالیاتی  نسخه 1.0.2";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnTis;
        private System.Windows.Forms.ToolStripButton btnExist;
        private System.Windows.Forms.ToolStripButton btnDirect;
    }
}