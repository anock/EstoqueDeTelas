using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EstoqueDeTelas
{
    public partial class Cadastro : Form
    {
        public Cadastro()

        {

            InitializeComponent();
            desliga();
            btnAtualizar.Enabled = false;
            txtAtualizar.Enabled = false;
        }

        private void Cadastro_Load(object sender, EventArgs e)
        {

            

            // data.
            // TODO: This line of code loads data into the 'estoqueDataSet1.Table' table. You can move, or remove it, as needed.
            //this.tableTableAdapter.Fill(this.estoqueDataSet.Table);
            // TODO: This line of code loads data into the 'estoqueDataSet.Table' table. You can move, or remove it, as needed.
            // this.tableTableAdapter.Fill(this.estoqueDataSet.Table);

        }

        private void bntAdd_Click(object sender, EventArgs e)
        {
            //int datas = int.Parse(txtData.Text);
            // adicionar dados

            

            liga();
            
            txtModelo.Focus();
            this.Validate();
            this.tableBindingSource.AddNew();
            DateTime data = DateTime.Today;
            txtData.Text = data.ToShortDateString().ToString();


        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //deletar dados
            if (MessageBox.Show("Deseja mesmo Excluir", "Excluir dados", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                txtModelo.Focus();
                this.Validate();
                this.tableBindingSource.RemoveCurrent();
                this.tableTableAdapter.Update(estoqueDataSet.Table);
            }
            else if (MessageBox.Show("Deseja mesmo excluir ", "Excluir dados", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                txtModelo.Focus();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            liga();
            btnAtualizar.Enabled = true;
            txtAtualizar.Enabled= true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            quantidadeTotal();
            this.Validate();
            this.tableBindingSource.EndEdit();
            this.tableTableAdapter.Update(estoqueDataSet.Table);
            txtModelo.Focus();
            desliga();


        }

        public void quantidadeTotal() // mostra a quantidade total em estoque 
        {
            try
            {
                int azul = int.Parse(txtAzul.Text);
                int preto = int.Parse(txtPreto.Text);
                int branco = int.Parse(txtBranco.Text);
                int dourado = int.Parse(txtDourado.Text);

                int soma = preto + azul + branco + dourado;

                txtTotal.Text = soma.ToString();
            }
            catch
            {
                MessageBox.Show("Preencha os campos", "Mula vai ferrar a merda toda", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void btnImagem_Click(object sender, EventArgs e)
        {
            //armazena imagem 

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "select an image";

            ofd.Filter = "Image File (*.png;*jpg)|*.png;*jpg";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(ofd.FileName);
            }

            saveImagem();



            this.Validate();
            this.tableBindingSource.EndEdit();

        }
        private byte[] saveImagem() // salva a imagem no banco de dados 
        {

            MemoryStream ms = new MemoryStream();

            pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
            return ms.GetBuffer();
        }

        //desativa a esntrada de dados
        public void desliga()
        {
            txtData.Enabled = false;
            txtAzul.Enabled = false;
            txtBranco.Enabled = false;
            txtCompra.Enabled = false;
            txtDourado.Enabled = false;
            txtModelo.Enabled = false;
            txtPreto.Enabled = false;
            txtTotal.Enabled = false;
            txtVenda.Enabled = false;
            btnImagem.Enabled = false;
            //txtData.Enabled = false;
            btnDelete.Enabled = false;
            //btnEdit.Enabled = false;
            btnSave.Enabled = false;
            txtCodigo.Enabled = false;
            //metroButton1.Enabled = false;
            //TxtBusca.Enabled = false;
            //btnAtualizar.Enabled = false;

        }
        //ativa a entrada de dados
        public void liga()
        {
            //btnAtualizar.Enabled = true;
            txtAzul.Enabled = true;
            txtBranco.Enabled = true;
            txtCompra.Enabled = true;
            txtDourado.Enabled = true;
            txtModelo.Enabled = true;
            txtPreto.Enabled = true;
            txtTotal.Enabled = true;
            txtVenda.Enabled = true;
            btnImagem.Enabled = true;
            // txtData.Enabled = true;
            btnDelete.Enabled = true;
            btnEdit.Enabled = true;
            btnSave.Enabled = true;
            txtCodigo.Enabled = true;
            //metroButton1.Enabled = true;
            //TxtBusca.Enabled = true;
            txtData.Enabled = true;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            bntAdd.Enabled = false;
            btnEdit.Enabled = true;
            btnSave.Enabled = true;
            btnDelete.Enabled = true;
            
            txtModelo.Enabled = false;
            int codigo = int.Parse(txtAtualizar.Text);
            tableTableAdapter.FillBy2(estoqueDataSet.Table, codigo);

        }
    }


}
