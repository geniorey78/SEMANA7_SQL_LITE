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
    public partial class Login : ContentPage
    {
        private SQLiteAsyncConnection _conn;
        public Login()
        {
            InitializeComponent();
            //
            _conn = DependencyService.Get <DataBase>().GetConnection();
        }
        // hace referencia a la tabla estudiante
        public static IEnumerable<Estudiante> SELECT_WHERE(SQLiteConnection db, string usuario, string contrasena) {
            return db.Query<Estudiante>("SELECT * FROM Estudiante where usuario=? and contrasena=?",usuario, contrasena);
                }
            private void btnRegistro_Clicked(object sender, EventArgs e)
        {

        }

        private void btnIngresar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));
                var db = new SQLiteConnection(databasePath);
                db.CreateTable<Estudiante>();
                IEnumerable<Estudiante> resultado = SELECT_WHERE(db, txtUsuario.Text, txtContraseñar.Text);
                if(resultado.Count()>0)
                {
                    Navigation.PushAsync(new ConsultaRegistro());

                }
                else
                {
                    DisplayAlert("Alerta", "verifique el usuario", "ok");
                }

            }
            catch(Exception ex)
            {
                DisplayAlert("alerta", ex.Message, "ok");
            }
        }
    }
}