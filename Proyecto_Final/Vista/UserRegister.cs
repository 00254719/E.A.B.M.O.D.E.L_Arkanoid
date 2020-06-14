﻿using Proyecto_Final.Modelo;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Proyecto_Final.Vista
{
    public partial class UserRegister : UserControl
    {
        public delegate void EventUserRegister(object sender, EventArgs e);
        public EventUserRegister OnClickButtonPgame;
        public event EventHandler btnBack_Click2;
        public UserRegister()
        {
            InitializeComponent();
            OptimizeTableLayoutPanel();
        }
        
        // Evento del boton para volver al menu
        private void btnBack_Click(object sender, EventArgs e)
        {
            if (this.btnBack_Click2 != null)
                this.btnBack_Click2(sender: this, e);
        }

        // Evento del boton para iniciar el juego
        private void btnPgame_Click(object sender, EventArgs e)
        {
            if(OnClickButtonPgame != null)
            {
                OnClickButtonPgame(this, e);
            }
        }

        //metodo para cargar el contenido de las tablelayoutpanel sin tanto delay y de forma mas optima
        private void OptimizeTableLayoutPanel()
        {
            Type tp = RegisterTable.GetType().BaseType;
            System.Reflection.PropertyInfo pi =
                tp.GetProperty("DoubleBuffered",
                System.Reflection.BindingFlags.Instance
                | System.Reflection.BindingFlags.NonPublic);
            pi.SetValue(RegisterTable, true, null);
        }
    }
}
