using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Concessionária
{
    public partial class createCarro : Form
    {
        Carro carro = new Carro();
        public createCarro()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            carro.setCodigo(textBox1.Text);
            carro.setModelo(textBox2.Text);
            carro.setMarca(textBox3.Text);
            carro.setKm(textBox4.Text);
            carro.setAno(textBox5.Text);

            CarroBLL.validaDados(carro, 'c');

            if (Erro.getErro())
                MessageBox.Show(Erro.getMsg());
            else
                MessageBox.Show("Dados inseridos com sucesso!");

        }

        private void createCarro_Load(object sender, EventArgs e)
        {
            CarroBLL.conecta();
            if (Erro.getErro())
                MessageBox.Show(Erro.getMsg());
        }

        private void createCarro_FormClosing(object sender, FormClosingEventArgs e)
        {
            CarroBLL.desconecta();
        }
    }
}
