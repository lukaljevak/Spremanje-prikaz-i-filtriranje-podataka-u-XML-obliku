using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Spremanje__prikaz_i_filtriranje_podataka_u_XML_obliku
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnUnos_Click(object sender, EventArgs e)
        {
            UnosForm unosForm = new UnosForm();
            unosForm.ShowDialog();
        }

        private void btnPrikaz_Click(object sender, EventArgs e)
        {
            PregledForm pregledForm = new PregledForm();
            pregledForm.ShowDialog();
        }
    }
}
