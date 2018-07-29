using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EstoqueDeTelas
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void btnCadastro_Click(object sender, EventArgs e)
        {
            Cadastro cadastro = new Cadastro();

            cadastro.ShowDialog();
        }

        private void btnEstoque_Click(object sender, EventArgs e)
        {

            Estoque estoque = new Estoque();

            estoque.ShowDialog();
            

         
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Venda venda = new Venda();

            venda.ShowDialog();
        }
    }
}
