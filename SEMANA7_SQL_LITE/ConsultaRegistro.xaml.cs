using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using System.Collections.ObjectModel;
using SEMANA7_SQL_LITE.Model;
using System.IO;

namespace SEMANA7_SQL_LITE
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConsultaRegistro : ContentPage
    {
        private SQLiteAsyncConnection _conn;
        private ObservableCollection<Estudiante> _tablaEstudiante;

        public object ResultadoDelete { get; private set; }

        public ConsultaRegistro()
        {
            InitializeComponent();
            _conn = DependencyService.Get<DataBase>().GetConnection();
            NavigationPage.SetHasBackButton(this, false);
        }
        //CARGA LOS DATOS A LISTVIEW
        protected async override void OnAppearing()
        {
            var Resultado = await _conn.Table<Estudiante>().ToListAsync();
            _tablaEstudiante = new ObservableCollection<Estudiante>(Resultado);
            ListaUsuario.ItemsSource = _tablaEstudiante;
            base.OnAppearing();
        }
        public void OnSelection(object sender, SelectedItemChangedEventArgs e)
        {
            //se realiza una consukta sobre el metodo seleccionado de la tabal estudainte
            var Obj = (Estudiante)e.SelectedItem;
            var item = Obj.Id.ToString();

            int ID = Convert.ToInt32(item);
            try
            {
                Navigation.PushAsync(new Elemento(ID));
            }
            catch
            {

            }
        }

        private void btnEliminar_Clicked(object sender, EventArgs e)
        {
           
        }

        private void btnActualizar_Clicked(object sender, EventArgs e)
        {
            
        }
    }
}