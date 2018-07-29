using DGVPrinterHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Globalization;
using System.Windows.Forms.VisualStyles;
using System.Collections;


namespace EstoqueDeTelas
{
    public partial class Estoque : Form
    {
        public Estoque()
        {
            InitializeComponent();
        }

        private void tableBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            //this.Validate();
            //this.tableBindingSource.EndEdit();
            //this.tableAdapterManager.UpdateAll(this.estoqueDataSet);

        }

        private void Estoque_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'estoqueDataSet.Table' table. You can move, or remove it, as needed.
            this.tableTableAdapter.Fill(this.estoqueDataSet.Table);

        }



        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtBuscar.Text == "")
                {
                    this.tableTableAdapter.Fill(this.estoqueDataSet.Table);
                }
                else
                {
                    tableTableAdapter.FillBy1(estoqueDataSet.Table, txtBuscar.Text);
                }
            }
            catch 
            {
                MessageBox.Show("Valores inválidos");
            }
            
           
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            this.printDocument1.DefaultPageSettings.Landscape = true;
            DGVPrinter printer = new DGVPrinter();
            printer.PrintDataGridView(tableDataGridView);

            
        }
    }
}