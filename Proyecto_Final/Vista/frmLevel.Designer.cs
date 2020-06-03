namespace Proyecto_Final.Vista
{
    partial class frmLevel
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
            this.picBounceBar = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picBounceBar)).BeginInit();
            this.SuspendLayout();
            // 
            // picBounceBar
            // 
            this.picBounceBar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.picBounceBar.BackColor = System.Drawing.Color.Indigo;
            this.picBounceBar.Location = new System.Drawing.Point(404, 577);
            this.picBounceBar.Margin = new System.Windows.Forms.Padding(2);
            this.picBounceBar.Name = "picBounceBar";
            this.picBounceBar.Size = new System.Drawing.Size(196, 25);
            this.picBounceBar.TabIndex = 0;
            this.picBounceBar.TabStop = false;
            // 
            // frmLevel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(937, 613);
            this.Controls.Add(this.picBounceBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "frmLevel";
            this.Text = "ARKANOID";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmLevel_Load);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frmLevel_MosueMpve);
            ((System.ComponentModel.ISupportInitialize)(this.picBounceBar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picBounceBar;
    }
}