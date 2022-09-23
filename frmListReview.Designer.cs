namespace P00196750_Mohammad_Munem_Sarwar_DDOOCP_Winter
{
    partial class frmListReview
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
            this.gv = new System.Windows.Forms.DataGridView();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Uid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isPublic = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Review_Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).BeginInit();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // gv
            // 
            this.gv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Uid,
            this.Remarks,
            this.isPublic,
            this.Review_Date});
            this.gv.Location = new System.Drawing.Point(11, 120);
            this.gv.Margin = new System.Windows.Forms.Padding(2);
            this.gv.Name = "gv";
            this.gv.RowHeadersWidth = 51;
            this.gv.RowTemplate.Height = 24;
            this.gv.Size = new System.Drawing.Size(834, 399);
            this.gv.TabIndex = 13;
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(29, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(805, 36);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "List of Review  Information";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1075, 58);
            this.pnlTop.TabIndex = 12;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.MinimumWidth = 6;
            this.ID.Name = "ID";
            this.ID.Width = 125;
            // 
            // Uid
            // 
            this.Uid.HeaderText = "Uid";
            this.Uid.MinimumWidth = 6;
            this.Uid.Name = "Uid";
            this.Uid.Width = 125;
            // 
            // Remarks
            // 
            this.Remarks.HeaderText = "Remarks";
            this.Remarks.MinimumWidth = 6;
            this.Remarks.Name = "Remarks";
            this.Remarks.Width = 125;
            // 
            // isPublic
            // 
            this.isPublic.HeaderText = "isPublic";
            this.isPublic.MinimumWidth = 6;
            this.isPublic.Name = "isPublic";
            this.isPublic.Width = 125;
            // 
            // Review_Date
            // 
            this.Review_Date.HeaderText = "Review Date";
            this.Review_Date.MinimumWidth = 6;
            this.Review_Date.Name = "Review_Date";
            this.Review_Date.Width = 125;
            // 
            // frmListReview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1075, 568);
            this.Controls.Add(this.gv);
            this.Controls.Add(this.pnlTop);
            this.Name = "frmListReview";
            this.Text = "frmListReview";
            this.Load += new System.EventHandler(this.frmListReview_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gv)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView gv;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Uid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remarks;
        private System.Windows.Forms.DataGridViewTextBoxColumn isPublic;
        private System.Windows.Forms.DataGridViewTextBoxColumn Review_Date;
    }
}