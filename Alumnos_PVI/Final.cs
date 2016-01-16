using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PVI_Final
{
    public partial class Final : Form
    {
        public Final(int tarea, int faltas)
        {
            InitializeComponent();
            this.labelTarea.Text = "(de "+tarea+")";
            this.labelFalta.Text = "(de "+faltas+")";
            numericUpDown2.Maximum = tarea;
            numericUpDown3.Maximum = faltas;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
