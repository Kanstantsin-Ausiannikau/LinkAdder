namespace LinkAdder
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.btnLinksNormalize = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnOpenDay = new System.Windows.Forms.Button();
            this.btnSetLinks = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(784, 302);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnLinksNormalize
            // 
            this.btnLinksNormalize.Location = new System.Drawing.Point(12, 12);
            this.btnLinksNormalize.Name = "btnLinksNormalize";
            this.btnLinksNormalize.Size = new System.Drawing.Size(134, 23);
            this.btnLinksNormalize.TabIndex = 1;
            this.btnLinksNormalize.Text = "Vuz Normalize";
            this.btnLinksNormalize.UseVisualStyleBackColor = true;
            this.btnLinksNormalize.Click += new System.EventHandler(this.btnLinksNormalize_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 41);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(732, 284);
            this.textBox1.TabIndex = 2;
            // 
            // btnOpenDay
            // 
            this.btnOpenDay.Location = new System.Drawing.Point(153, 12);
            this.btnOpenDay.Name = "btnOpenDay";
            this.btnOpenDay.Size = new System.Drawing.Size(128, 23);
            this.btnOpenDay.TabIndex = 3;
            this.btnOpenDay.Text = "Open Day Normalize";
            this.btnOpenDay.UseVisualStyleBackColor = true;
            this.btnOpenDay.Click += new System.EventHandler(this.btnOpenDay_Click);
            // 
            // btnSetLinks
            // 
            this.btnSetLinks.Location = new System.Drawing.Point(288, 11);
            this.btnSetLinks.Name = "btnSetLinks";
            this.btnSetLinks.Size = new System.Drawing.Size(138, 23);
            this.btnSetLinks.TabIndex = 4;
            this.btnSetLinks.Text = "Set Links";
            this.btnSetLinks.UseVisualStyleBackColor = true;
            this.btnSetLinks.Click += new System.EventHandler(this.btnSetLinks_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 337);
            this.Controls.Add(this.btnSetLinks);
            this.Controls.Add(this.btnOpenDay);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnLinksNormalize);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnLinksNormalize;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnOpenDay;
        private System.Windows.Forms.Button btnSetLinks;
    }
}

