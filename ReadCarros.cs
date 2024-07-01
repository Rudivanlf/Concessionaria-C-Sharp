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
    public partial class ReadCarros : Form
    {
        public ReadCarros()
        {
            InitializeComponent();
        }

        public void ExibirInformacoes(Carro carro)
        {
            label1.Text = carro.getCodigo();
            label2.Text = carro.getModelo();
            label3.Text = carro.getMarca();
            label4.Text = carro.getAno();
            label5.Text = carro.getKm();
        }
        private void ReadCarros_Load(object sender, EventArgs e)
        {

        }
    }
}
