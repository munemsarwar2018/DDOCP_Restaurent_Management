namespace P00196750_Mohammad_Munem_Sarwar_DDOOCP_Winter
{
    partial class frmMenu
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
            this.pnlContainer = new System.Windows.Forms.Panel();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.btnBookingList = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnRide = new System.Windows.Forms.Button();
            this.btnReview = new System.Windows.Forms.Button();
            this.btnRestaurant = new System.Windows.Forms.Button();
            this.btnResort = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnIntro = new System.Windows.Forms.Button();
            this.btnGuide = new System.Windows.Forms.Button();
            this.btnFood = new System.Windows.Forms.Button();
            this.btnListReview = new System.Windows.Forms.Button();
            this.pnlTop.SuspendLayout();
            this.pnlMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContainer
            // 
            this.pnlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContainer.Location = new System.Drawing.Point(124, 57);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(1052, 490);
            this.pnlContainer.TabIndex = 5;
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.Crimson;
            this.pnlTop.Controls.Add(this.lblUser);
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(124, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1052, 57);
            this.pnlTop.TabIndex = 3;
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.ForeColor = System.Drawing.Color.Yellow;
            this.lblUser.Location = new System.Drawing.Point(821, 23);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(52, 13);
            this.lblUser.TabIndex = 1;
            this.lblUser.Text = "Welcome";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.MintCream;
            this.lblTitle.Location = new System.Drawing.Point(30, 18);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(212, 16);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Booking Management System";
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(101)))), ((int)(((byte)(109)))));
            this.pnlMenu.Controls.Add(this.btnListReview);
            this.pnlMenu.Controls.Add(this.btnBookingList);
            this.pnlMenu.Controls.Add(this.button1);
            this.pnlMenu.Controls.Add(this.btnRide);
            this.pnlMenu.Controls.Add(this.btnReview);
            this.pnlMenu.Controls.Add(this.btnRestaurant);
            this.pnlMenu.Controls.Add(this.btnResort);
            this.pnlMenu.Controls.Add(this.btnLogout);
            this.pnlMenu.Controls.Add(this.btnIntro);
            this.pnlMenu.Controls.Add(this.btnGuide);
            this.pnlMenu.Controls.Add(this.btnFood);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(124, 547);
            this.pnlMenu.TabIndex = 4;
            // 
            // btnBookingList
            // 
            this.btnBookingList.Location = new System.Drawing.Point(14, 340);
            this.btnBookingList.Margin = new System.Windows.Forms.Padding(2);
            this.btnBookingList.Name = "btnBookingList";
            this.btnBookingList.Size = new System.Drawing.Size(91, 24);
            this.btnBookingList.TabIndex = 5;
            this.btnBookingList.Text = "Booking List";
            this.btnBookingList.UseVisualStyleBackColor = true;
            this.btnBookingList.Click += new System.EventHandler(this.btnBookingList_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(14, 303);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 24);
            this.button1.TabIndex = 4;
            this.button1.Text = "Booking";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnRide
            // 
            this.btnRide.Location = new System.Drawing.Point(14, 180);
            this.btnRide.Margin = new System.Windows.Forms.Padding(2);
            this.btnRide.Name = "btnRide";
            this.btnRide.Size = new System.Drawing.Size(91, 24);
            this.btnRide.TabIndex = 0;
            this.btnRide.Text = "Park Ride";
            this.btnRide.UseVisualStyleBackColor = true;
            this.btnRide.Click += new System.EventHandler(this.btnRide_Click);
            // 
            // btnReview
            // 
            this.btnReview.Location = new System.Drawing.Point(14, 264);
            this.btnReview.Margin = new System.Windows.Forms.Padding(2);
            this.btnReview.Name = "btnReview";
            this.btnReview.Size = new System.Drawing.Size(91, 24);
            this.btnReview.TabIndex = 0;
            this.btnReview.Text = "Review";
            this.btnReview.UseVisualStyleBackColor = true;
            this.btnReview.Click += new System.EventHandler(this.btnReview_Click);
            // 
            // btnRestaurant
            // 
            this.btnRestaurant.Location = new System.Drawing.Point(14, 99);
            this.btnRestaurant.Margin = new System.Windows.Forms.Padding(2);
            this.btnRestaurant.Name = "btnRestaurant";
            this.btnRestaurant.Size = new System.Drawing.Size(91, 24);
            this.btnRestaurant.TabIndex = 0;
            this.btnRestaurant.Text = "Restaurant";
            this.btnRestaurant.UseVisualStyleBackColor = true;
            this.btnRestaurant.Click += new System.EventHandler(this.btnRestaurant_Click);
            // 
            // btnResort
            // 
            this.btnResort.Location = new System.Drawing.Point(14, 141);
            this.btnResort.Margin = new System.Windows.Forms.Padding(2);
            this.btnResort.Name = "btnResort";
            this.btnResort.Size = new System.Drawing.Size(91, 24);
            this.btnResort.TabIndex = 3;
            this.btnResort.Text = "Resort";
            this.btnResort.UseVisualStyleBackColor = true;
            this.btnResort.Click += new System.EventHandler(this.btnResort_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(13, 423);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(92, 23);
            this.btnLogout.TabIndex = 2;
            this.btnLogout.Text = "Log Out";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnIntro
            // 
            this.btnIntro.Location = new System.Drawing.Point(13, 23);
            this.btnIntro.Name = "btnIntro";
            this.btnIntro.Size = new System.Drawing.Size(92, 23);
            this.btnIntro.TabIndex = 2;
            this.btnIntro.Text = "Home";
            this.btnIntro.UseVisualStyleBackColor = true;
            this.btnIntro.Click += new System.EventHandler(this.btnIntro_Click);
            // 
            // btnGuide
            // 
            this.btnGuide.Location = new System.Drawing.Point(14, 221);
            this.btnGuide.Name = "btnGuide";
            this.btnGuide.Size = new System.Drawing.Size(91, 24);
            this.btnGuide.TabIndex = 1;
            this.btnGuide.Text = "Guide";
            this.btnGuide.UseVisualStyleBackColor = true;
            this.btnGuide.Click += new System.EventHandler(this.btnGuide_Click);
            // 
            // btnFood
            // 
            this.btnFood.Location = new System.Drawing.Point(13, 61);
            this.btnFood.Name = "btnFood";
            this.btnFood.Size = new System.Drawing.Size(92, 23);
            this.btnFood.TabIndex = 0;
            this.btnFood.Text = "Food";
            this.btnFood.UseVisualStyleBackColor = true;
            this.btnFood.Click += new System.EventHandler(this.btnFood_Click);
            // 
            // btnListReview
            // 
            this.btnListReview.Location = new System.Drawing.Point(13, 382);
            this.btnListReview.Margin = new System.Windows.Forms.Padding(2);
            this.btnListReview.Name = "btnListReview";
            this.btnListReview.Size = new System.Drawing.Size(91, 24);
            this.btnListReview.TabIndex = 6;
            this.btnListReview.Text = "Review List";
            this.btnListReview.UseVisualStyleBackColor = true;
            this.btnListReview.Click += new System.EventHandler(this.btnListReview_Click);
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1176, 547);
            this.Controls.Add(this.pnlContainer);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.pnlMenu);
            this.Name = "frmMenu";
            this.Text = "frmMenu";
            this.Load += new System.EventHandler(this.frmMenu_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlContainer;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Button btnRide;
        private System.Windows.Forms.Button btnReview;
        private System.Windows.Forms.Button btnRestaurant;
        private System.Windows.Forms.Button btnResort;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnIntro;
        private System.Windows.Forms.Button btnGuide;
        private System.Windows.Forms.Button btnFood;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnBookingList;
        private System.Windows.Forms.Button btnListReview;
    }
}