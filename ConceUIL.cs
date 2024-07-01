using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlConnector;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Concessionária
{
    public partial class ConceUIL : Form
    {
        Carro carro = new Carro();
        createCarro createCarro = new createCarro();
        ReadCarros readCarros = new ReadCarros();

        public ConceUIL()
        {
            InitializeComponent();
        }

        private void InserirCarro_Click(object sender, EventArgs e)
        {
            createCarro.Show();
        }   
        private void Buscar_Click(object sender, EventArgs e)
        {
            carro.setCodigo(textBox1.Text);


            CarroBLL.validaCodigo(carro, 'r');

            if (Erro.getErro())
                MessageBox.Show(Erro.getMsg());
            else
            {
                readCarros.ExibirInformacoes(carro);
                readCarros.Show();
            }

        }

        private void CriarConta_Click(object sender, EventArgs e)
        {

        }
    }
}
