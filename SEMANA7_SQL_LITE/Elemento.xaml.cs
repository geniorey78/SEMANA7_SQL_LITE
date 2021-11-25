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
    public partial class Elemento : ContentPage
    {
        public int IdSeleccionado;
        private SQLiteAsyncConnection _conn;
        IEnumerable<Estudiante> ResultadoDelete;

        public Elemento(int id)
        {
            _conn = DependencyService.Get<DataBase>().GetConnection();
            IdSeleccionado = id;
            InitializeComponent();
        }
        public static IEnumerable<Estudiante> Delete(SQLiteConnection db, int id)
        {

            return db.Query<Estudiante>("DELETE FROM Estudiante where ID=?", id);
        }
        public static IEnumerable<Estudiante> Update(SQLiteConnection db, string nombre, string usuario, string contrasenia, int id)
        {
            return db.Query<Estudiante>("UPDATE Estudiante SET Nombre =?,Usuario=?," + "Contrasenia=? where Id=?", nombre, usuario, contrasenia, id);
        }
            private void btn_actualizar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(databasePath);
               // ResultadoUpdate = UpdateChildrenLayout(db, txtNombre.Text, txtUsuario.Text, txtContraseña.Text, IdSeleccionado);
            }
            catch (Exception ex)
            {
                DisplayAlert("Alertar", "ERROR" + ex.Message, "ok");
            }
        }

        private void btn_eliminar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(databasePath);
                ResultadoDelete = Delete(db, IdSeleccionado);

            }
            catch (Exception ex)
            {
                DisplayAlert("Alertar", "ERROR" + ex.Message, "ok");
            }
        }
    }
}