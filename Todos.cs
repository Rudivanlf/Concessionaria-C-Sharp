using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Concessionária
{
    public partial class Todos : Form
    {
        Button[] c = new Button[9];
        int contador = 0;
        char letra = 'A';
        public Todos()
        {
            InitializeComponent();
        }

        private void Todos_Load(object sender, EventArgs e)
        {
            int colunas = 45;
            int linhas = 30;
            for (int i = 0; i < 10; i++) 
            {
                c[i] = new Button();
                c[i].Size = new System.Drawing.Size(35, 23);
            }
        }
    }
}
