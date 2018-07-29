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
    public partial class Venda : Form
    {

        public Venda()
        {

            InitializeComponent();

        }


        public void totalPagar() // Metodo que calcula o valor total a pagar 
        {
            try
            {
                double p = double.Parse(txPt.Text);
                double b = double.Parse(txBr.Text);
                double a = double.Parse(txAz.Text);
                double d = double.Parse(txDr.Text);
                double preco = double.Parse(txPreco.Text);

                double soma = a + b + d + p;


                double total = soma * preco;

                txTotal.Text = total.ToString();
            }
            catch
            {
                MessageBox.Show("Indique a quantidade ARROMBADO", "Deu merda ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            //int total = soma * preco;
            //lbResultado.Text = total.ToString();
        }

        public void baixaTotal() // Metodo baixa o estoque por cor 
        {
            int azul = int.Parse(txtAzul.Text);
            int az = int.Parse(txAz.Text);
            int diminuir = azul - az;
            txtAzul.Text = diminuir.ToString();


            int preto = int.Parse(txtPreto.Text);
            int pr = int.Parse(txPt.Text);
            int diminuir1 = preto - pr;
            txtPreto.Text = diminuir1.ToString();



            int branco = int.Parse(txtBranco.Text);
            int br = int.Parse(txBr.Text);
            int diminuir2 = branco - br;
            txtBranco.Text = diminuir2.ToString();



            int dourado = int.Parse(txtDourado.Text);
            int dr = int.Parse(txDr.Text);
            int diminuir3 = dourado - dr;
            txtDourado.Text = diminuir3.ToString();




            //this.Validate();
            //this.tableBindingSource.EndEdit();
            //t/his.tableTableAdapter.Update(controleDataSet.Table);
        }
        public void quantidadeTotal() // mostra a quantidade total atualizada
        {
            int azul = int.Parse(txtAzul.Text);
            int preto = int.Parse(txtPreto.Text);
            int branco = int.Parse(txtBranco.Text);
            int dourado = int.Parse(txtDourado.Text);

            int soma = preto + azul + branco + dourado;

            txtQtd.Text = soma.ToString();

        }


        private void button1_Click(object sender, EventArgs e)
        {
            totalPagar();
        }

        private void button4_Click(object sender, EventArgs e)
        {


            if (txCodigo.Text == "")
            {
                MessageBox.Show("Cara passa a porra de um número ARROMBADO", "FERROU A PORRA TODA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int codigo = int.Parse(txCodigo.Text);
                tableTableAdapter.FillBy2(estoqueDataSet.Table, codigo);

            }


        }

        private void Venda_Load(object sender, EventArgs e)
        {
            txCodigo.Focus();
            // TODO: This line of code loads data into the 'estoqueDataSet.Table' table. You can move, or remove it, as needed.
            // this.tableTableAdapter.Fill(this.estoqueDataSet.Table);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                baixaTotal(); //baixa estoque
                quantidadeTotal(); // atualiza a quantidade de estoque

                this.Validate();//valida
                this.tableBindingSource.EndEdit(); // finaliza edicao 
                tableTableAdapter.Update(this.estoqueDataSet.Table);// atualilza os dados

                MessageBox.Show("venda efetuada com sucesso");
            }
            catch
            {
                MessageBox.Show("Preencha os campos vazios sua MULA", "Bugou todo o sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }



}


