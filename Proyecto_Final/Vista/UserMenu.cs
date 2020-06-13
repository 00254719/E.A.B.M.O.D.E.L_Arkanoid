﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Final.Vista
{
    public partial class UserMenu : UserControl
    {
        public event EventHandler btnPlay_Click1;
        public UserMenu()
        {
            InitializeComponent();
            Type tp = tableLayoutPanel1.GetType().BaseType;
            System.Reflection.PropertyInfo pi =
                tp.GetProperty("DoubleBuffered",
                System.Reflection.BindingFlags.Instance
                | System.Reflection.BindingFlags.NonPublic);
            pi.SetValue(tableLayoutPanel1, true, null);
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (this.btnPlay_Click1 != null)
                this.btnPlay_Click1(sender: this, e);
        }

        private void btnTop10_Click(object sender, EventArgs e)
        {
            frmTop10 Top = new frmTop10();
            Top.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
