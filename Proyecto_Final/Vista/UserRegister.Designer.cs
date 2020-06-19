namespace Proyecto_Final.Vista
{
    partial class UserRegister
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
            this.RegisterTable = new System.Windows.Forms.TableLayoutPanel();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnPgame = new System.Windows.Forms.Button();
            this.RegisterTable.SuspendLayout();
            this.SuspendLayout();
            // 
            // RegisterTable
            // 
            this.RegisterTable.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.RegisterTable.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.RegisterTable.ColumnCount = 7;
            this.RegisterTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3F));
            this.RegisterTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.RegisterTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.RegisterTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.RegisterTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.RegisterTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.RegisterTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3F));
            this.RegisterTable.Controls.Add(this.richTextBox1, 2, 3);
            this.RegisterTable.Controls.Add(this.btnBack, 1, 5);
            this.RegisterTable.Controls.Add(this.btnPgame, 4, 5);
            this.RegisterTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RegisterTable.Location = new System.Drawing.Point(0, 0);
            this.RegisterTable.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RegisterTable.Name = "RegisterTable";
            this.RegisterTable.RowCount = 7;
            this.RegisterTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 29.99984F));
            this.RegisterTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.46993F));
            this.RegisterTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.006428F));
            this.RegisterTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.19642F));
            this.RegisterTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.13095F));
            this.RegisterTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.16369F));
            this.RegisterTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.032737F));
            this.RegisterTable.Size = new System.Drawing.Size(1235, 724);
            this.RegisterTable.TabIndex = 1;
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.Black;
            this.RegisterTable.SetColumnSpan(this.richTextBox1, 3);
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Font = new System.Drawing.Font("Barcade No Bar Bold", 60F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(169)))), ((int)(((byte)(255)))));
            this.richTextBox1.Location = new System.Drawing.Point(188, 373);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.richTextBox1.MaxLength = 20;
            this.richTextBox1.Multiline = false;
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(858, 127);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // btnBack
            // 
            this.btnBack.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnBack.BackColor = System.Drawing.Color.Transparent;
            this.btnBack.BackgroundImage = global::Proyecto_Final.Properties.Resources.btnBack;
            this.btnBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.RegisterTable.SetColumnSpan(this.btnBack, 2);
            this.btnBack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnBack.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(40, 591);
            this.btnBack.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(327, 105);
            this.btnBack.TabIndex = 2;
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnPgame
            // 
            this.btnPgame.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnPgame.BackColor = System.Drawing.Color.Transparent;
            this.btnPgame.BackgroundImage = global::Proyecto_Final.Properties.Resources.btnPlay__1_;
            this.btnPgame.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.RegisterTable.SetColumnSpan(this.btnPgame, 2);
            this.btnPgame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPgame.FlatAppearance.BorderSize = 0;
            this.btnPgame.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnPgame.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnPgame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPgame.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPgame.Location = new System.Drawing.Point(867, 591);
            this.btnPgame.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPgame.Name = "btnPgame";
            this.btnPgame.Size = new System.Drawing.Size(327, 105);
            this.btnPgame.TabIndex = 3;
            this.btnPgame.UseVisualStyleBackColor = false;
            this.btnPgame.Click += new System.EventHandler(this.btnPgame_Click);
            // 
            // UserRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImage = global::Proyecto_Final.Properties.Resources.NNBG;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.RegisterTable);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "UserRegister";
            this.Size = new System.Drawing.Size(1235, 724);
            this.RegisterTable.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel RegisterTable;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnPgame;
    }
}
