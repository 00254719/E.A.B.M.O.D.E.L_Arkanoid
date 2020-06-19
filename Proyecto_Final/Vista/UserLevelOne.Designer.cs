namespace Proyecto_Final.Vista
{
    partial class UserLevelOne
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.picPlayerBar = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picPlayerBar)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 15;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // picPlayerBar
            // 
            this.picPlayerBar.Location = new System.Drawing.Point(302, 452);
            this.picPlayerBar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.picPlayerBar.Name = "picPlayerBar";
            this.picPlayerBar.Size = new System.Drawing.Size(210, 33);
            this.picPlayerBar.TabIndex = 0;
            this.picPlayerBar.TabStop = false;
            // 
            // UserLevelOne
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImage = global::Proyecto_Final.Properties.Resources.LvlBG;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.picPlayerBar);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "UserLevelOne";
            this.Size = new System.Drawing.Size(797, 496);
            this.Load += new System.EventHandler(this.UserLevelOne_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UserLevelOne_KeyDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.UserLevelOne_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.picPlayerBar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox picPlayerBar;
    }
}
