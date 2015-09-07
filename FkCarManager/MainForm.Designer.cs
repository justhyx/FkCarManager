namespace FkCarManager
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.MainFormMenuStrip = new System.Windows.Forms.MenuStrip();
            this.TSMBookingMng = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMBillManager = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMCustMng = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMCarMng = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMDriverMng = new System.Windows.Forms.ToolStripMenuItem();
            this.MainStatusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.TSMBooking = new System.Windows.Forms.ToolStripMenuItem();
            this.MainFormMenuStrip.SuspendLayout();
            this.MainStatusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainFormMenuStrip
            // 
            this.MainFormMenuStrip.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MainFormMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMBookingMng,
            this.TSMBillManager,
            this.TSMSetting,
            this.TSMBooking});
            this.MainFormMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MainFormMenuStrip.Name = "MainFormMenuStrip";
            this.MainFormMenuStrip.Size = new System.Drawing.Size(792, 34);
            this.MainFormMenuStrip.TabIndex = 1;
            // 
            // TSMBookingMng
            // 
            this.TSMBookingMng.Name = "TSMBookingMng";
            this.TSMBookingMng.Size = new System.Drawing.Size(100, 30);
            this.TSMBookingMng.Text = "订单管理";
            this.TSMBookingMng.Click += new System.EventHandler(this.TSMBookingMng_Click);
            // 
            // TSMBillManager
            // 
            this.TSMBillManager.Name = "TSMBillManager";
            this.TSMBillManager.Size = new System.Drawing.Size(100, 30);
            this.TSMBillManager.Text = "帐目列表";
            // 
            // TSMSetting
            // 
            this.TSMSetting.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMCustMng,
            this.TSMCarMng,
            this.TSMDriverMng});
            this.TSMSetting.Name = "TSMSetting";
            this.TSMSetting.Size = new System.Drawing.Size(100, 30);
            this.TSMSetting.Text = "设置列表";
            // 
            // TSMCustMng
            // 
            this.TSMCustMng.Name = "TSMCustMng";
            this.TSMCustMng.Size = new System.Drawing.Size(160, 30);
            this.TSMCustMng.Text = "客户管理";
            // 
            // TSMCarMng
            // 
            this.TSMCarMng.Name = "TSMCarMng";
            this.TSMCarMng.Size = new System.Drawing.Size(160, 30);
            this.TSMCarMng.Text = "车辆管理";
            this.TSMCarMng.Click += new System.EventHandler(this.TSMCarMng_Click);
            // 
            // TSMDriverMng
            // 
            this.TSMDriverMng.Name = "TSMDriverMng";
            this.TSMDriverMng.Size = new System.Drawing.Size(160, 30);
            this.TSMDriverMng.Text = "司机管理";
            // 
            // MainStatusStrip
            // 
            this.MainStatusStrip.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MainStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripProgressBar1});
            this.MainStatusStrip.Location = new System.Drawing.Point(0, 543);
            this.MainStatusStrip.Name = "MainStatusStrip";
            this.MainStatusStrip.Size = new System.Drawing.Size(792, 30);
            this.MainStatusStrip.TabIndex = 2;
            this.MainStatusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(107, 25);
            this.toolStripStatusLabel1.Text = "当前窗体：";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 24);
            // 
            // TSMBooking
            // 
            this.TSMBooking.Name = "TSMBooking";
            this.TSMBooking.Size = new System.Drawing.Size(62, 30);
            this.TSMBooking.Text = "下单";
            this.TSMBooking.Click += new System.EventHandler(this.TSMBooking_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.MainStatusStrip);
            this.Controls.Add(this.MainFormMenuStrip);
            this.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.MainFormMenuStrip;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CarSys";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MainFormMenuStrip.ResumeLayout(false);
            this.MainFormMenuStrip.PerformLayout();
            this.MainStatusStrip.ResumeLayout(false);
            this.MainStatusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MainFormMenuStrip;
        private System.Windows.Forms.StatusStrip MainStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripMenuItem TSMBookingMng;
        private System.Windows.Forms.ToolStripMenuItem TSMBillManager;
        private System.Windows.Forms.ToolStripMenuItem TSMSetting;
        private System.Windows.Forms.ToolStripMenuItem TSMCustMng;
        private System.Windows.Forms.ToolStripMenuItem TSMCarMng;
        private System.Windows.Forms.ToolStripMenuItem TSMDriverMng;
        private System.Windows.Forms.ToolStripMenuItem TSMBooking;
    }
}

