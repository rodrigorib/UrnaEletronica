using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VotoWinForms.Contract.Service;
using VotoWinForms.Service;

namespace VotoWinForms.Forms
{
    public partial class FormUrna : Form
    {
        private readonly IVotoService _votoService;
        private List<int> numero = new List<int>();

        public FormUrna(IVotoService votoService)
        {
            InitializeComponent();
            _votoService = votoService;
        }

        private void SetDigitos(int digito)
        {
            //Verificar se foram digitados 2 números
            if (numero.Count() < 2)
                numero.Add(digito);

            lblNumero.Text = "99";
        }

        private void btnNumero1_Click(object sender, EventArgs e)
        {

        }

        private void btnNumero2_Click(object sender, EventArgs e)
        {

        }

        private void btnNumero3_Click(object sender, EventArgs e)
        {

        }

        private void btnNumero4_Click(object sender, EventArgs e)
        {

        }

        private void btnNumero5_Click(object sender, EventArgs e)
        {

        }

        private void btnNumero6_Click(object sender, EventArgs e)
        {

        }

        private void btnNumero7_Click(object sender, EventArgs e)
        {

        }

        private void btnNumero8_Click(object sender, EventArgs e)
        {

        }

        private void btnNumero9_Click(object sender, EventArgs e)
        {

        }

        private void btnNumero0_Click(object sender, EventArgs e)
        {

        }

        private void btnVotoBranco_Click(object sender, EventArgs e)
        {

        }

        private void btnCorrige_Click(object sender, EventArgs e)
        {

        }

        private void btnConfirma_Click(object sender, EventArgs e)
        {

        }
    }
}
