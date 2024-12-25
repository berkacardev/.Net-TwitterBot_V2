
namespace UserInterfaceWF
{
    partial class UpdateAccountToFollow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateAccountToFollow));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbl_AccountToFollowDate = new System.Windows.Forms.Label();
            this.lbl_AccountToFollowUserName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_AccountToFollowUserName = new System.Windows.Forms.TextBox();
            this.btn_Update = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbl_AccountToFollowDate);
            this.groupBox1.Controls.Add(this.lbl_AccountToFollowUserName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(300, 74);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Hesap Bilgileri";
            // 
            // lbl_AccountToFollowDate
            // 
            this.lbl_AccountToFollowDate.AutoSize = true;
            this.lbl_AccountToFollowDate.Location = new System.Drawing.Point(99, 50);
            this.lbl_AccountToFollowDate.Name = "lbl_AccountToFollowDate";
            this.lbl_AccountToFollowDate.Size = new System.Drawing.Size(0, 13);
            this.lbl_AccountToFollowDate.TabIndex = 3;
            // 
            // lbl_AccountToFollowUserName
            // 
            this.lbl_AccountToFollowUserName.AutoSize = true;
            this.lbl_AccountToFollowUserName.Location = new System.Drawing.Point(99, 22);
            this.lbl_AccountToFollowUserName.Name = "lbl_AccountToFollowUserName";
            this.lbl_AccountToFollowUserName.Size = new System.Drawing.Size(0, 13);
            this.lbl_AccountToFollowUserName.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(7, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Kayıt Tarihi :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Kullanıcı Adı :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Kullanıcı Adı";
            // 
            // txt_AccountToFollowUserName
            // 
            this.txt_AccountToFollowUserName.Location = new System.Drawing.Point(82, 99);
            this.txt_AccountToFollowUserName.Name = "txt_AccountToFollowUserName";
            this.txt_AccountToFollowUserName.Size = new System.Drawing.Size(230, 20);
            this.txt_AccountToFollowUserName.TabIndex = 2;
            // 
            // btn_Update
            // 
            this.btn_Update.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_Update.Location = new System.Drawing.Point(12, 134);
            this.btn_Update.Name = "btn_Update";
            this.btn_Update.Size = new System.Drawing.Size(300, 38);
            this.btn_Update.TabIndex = 3;
            this.btn_Update.Text = "Düzenle";
            this.btn_Update.UseVisualStyleBackColor = true;
            this.btn_Update.Click += new System.EventHandler(this.btn_Update_Click);
            // 
            // UpdateAccountToFollow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 189);
            this.Controls.Add(this.btn_Update);
            this.Controls.Add(this.txt_AccountToFollowUserName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UpdateAccountToFollow";
            this.Text = "Takip Edilecek Hesap Düzenle";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_AccountToFollowUserName;
        private System.Windows.Forms.Button btn_Update;
        private System.Windows.Forms.Label lbl_AccountToFollowUserName;
        private System.Windows.Forms.Label lbl_AccountToFollowDate;
    }
}