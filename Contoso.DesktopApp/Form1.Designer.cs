namespace Contoso.DesktopApp
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
			this.asdfasfdds = new System.Windows.Forms.Label();
			this.LblVersion = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.LblStatus = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// asdfasfdds
			// 
			this.asdfasfdds.AutoSize = true;
			this.asdfasfdds.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.asdfasfdds.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			this.asdfasfdds.Location = new System.Drawing.Point(354, 202);
			this.asdfasfdds.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.asdfasfdds.Name = "asdfasfdds";
			this.asdfasfdds.Size = new System.Drawing.Size(661, 58);
			this.asdfasfdds.TabIndex = 0;
			this.asdfasfdds.Text = "Contoso Desktop App v2.0.6";
			// 
			// LblVersion
			// 
			this.LblVersion.AutoSize = true;
			this.LblVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LblVersion.ForeColor = System.Drawing.Color.DarkRed;
			this.LblVersion.Location = new System.Drawing.Point(504, 285);
			this.LblVersion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.LblVersion.Name = "LblVersion";
			this.LblVersion.Size = new System.Drawing.Size(146, 46);
			this.LblVersion.TabIndex = 1;
			this.LblVersion.Text = "V 2.0.1";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(542, 429);
			this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(112, 35);
			this.button1.TabIndex = 2;
			this.button1.Text = "Hello!";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.Button1_Click);
			// 
			// LblStatus
			// 
			this.LblStatus.AutoSize = true;
			this.LblStatus.Location = new System.Drawing.Point(18, 658);
			this.LblStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.LblStatus.Name = "LblStatus";
			this.LblStatus.Size = new System.Drawing.Size(60, 20);
			this.LblStatus.TabIndex = 3;
			this.LblStatus.Text = "Status:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.SystemColors.Info;
			this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
			this.label1.Location = new System.Drawing.Point(448, 560);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(288, 20);
			this.label1.TabIndex = 4;
			this.label1.Text = "Now updates from http://127.0.0.1:8081";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.PaleGreen;
			this.ClientSize = new System.Drawing.Size(1200, 692);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.LblStatus);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.LblVersion);
			this.Controls.Add(this.asdfasfdds);
			this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Auto-Update Example";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label asdfasfdds;
        private System.Windows.Forms.Label LblVersion;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label LblStatus;
        private System.Windows.Forms.Label label1;
    }
}

