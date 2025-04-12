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
using VotoWinForms.Model;
using VotoWinForms.Service;
using static System.Net.Mime.MediaTypeNames;

namespace VotoWinForms.Forms
{
    public partial class FormUrna : Form
    {
        private readonly IVotoService _votoService;
        private string _digitos = string.Empty;
        private TipoVoto _tipoVoto = TipoVoto.Valido;

        public FormUrna(IVotoService votoService)
        {
            InitializeComponent();
            _votoService = votoService;
        }

        private void SetDigitos(string digito)
        {
            //Verificar se foram digitados 2 números
            if (_digitos.Length < 1)
                _digitos += digito;
            else if (_digitos.Length < 2)
            {
                _digitos += digito;
                GetCandidato();
            }

            lblNumero.Text = _digitos;
        }

        private void GetCandidato()
        {
            Candidato? candidato = _votoService.GetByNumber(Convert.ToInt32(_digitos));

            if (candidato == null)
            {
                candidato = _votoService.GetNulo();
                _tipoVoto = TipoVoto.Nulo;
            }
            else
            {
                _tipoVoto = TipoVoto.Valido;
            }

            lblNomeCandidato.Text = candidato.Nome;
            Bitmap image = new Bitmap(candidato.CaminhoFoto);
            picFotoCandidato.Image = image;
        }

        private void ClearForm()
        {
            _digitos = string.Empty;
            _tipoVoto = TipoVoto.Valido;
            picFotoCandidato.Image = null;
            lblNumero.Text = string.Empty;
            lblNomeCandidato.Text = string.Empty;
            lblNumero.Visible = true;
        }

        private void btnDigito_Click(object sender, EventArgs e)
        {
            SetDigitos(((Button)sender).Text);
        }

        private void btnVotoBranco_Click(object sender, EventArgs e)
        {
            Candidato candidato = _votoService.GetBranco();

            _digitos = candidato.Numero.ToString();
            _tipoVoto = TipoVoto.Branco;
            lblNomeCandidato.Text = candidato.Nome;
            Bitmap image = new Bitmap(candidato.CaminhoFoto);
            picFotoCandidato.Image = image;

            lblNumero.Text = string.Empty;
            lblNumero.Visible = false;
        }

        private void btnCorrige_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void btnConfirma_Click(object sender, EventArgs e)
        {
            _votoService.Register(_tipoVoto, Convert.ToInt32(_digitos));
        }
    }
}
