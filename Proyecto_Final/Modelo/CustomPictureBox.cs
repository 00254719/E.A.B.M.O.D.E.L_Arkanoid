using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Final.Modelo
{
    public class CustomPictureBox : PictureBox 
    {
        public int Hits { get; set; }

        public CustomPictureBox() : base() { }
    }
}
