using SEMANA7_SQL_LITE.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SEMANA7_SQL_LITE
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registro : ContentPage
    {

        private SQLiteAsyncConnection _conn;

        public object ResultadoUpdate { get; private set; }
        public object ResultadoDelete { get; private set; }
        public object IdSeleccionado { get; private set; }

        public Registro()
        {
            InitializeComponent();

            _conn = DependencyService.Get<DataBase>().GetConnection();

        }

        private void btnRegistro_Clicked(object sender, EventArgs e)
        {
            var DatosRegistro = new Estudiante { Nombre = txtNombre.Text, usuario = txtUsuario.Text, contrasena = txtContraseña.Text };
            _conn.InsertAsync(DatosRegistro);
            txtNombre.Text = "";
            txtUsuario.Text = "";
            txtContraseña.Text = "";


        }
    }
}