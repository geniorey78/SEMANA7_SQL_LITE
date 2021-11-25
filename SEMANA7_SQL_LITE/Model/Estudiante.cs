using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
namespace SEMANA7_SQL_LITE.Model
{
    public class Estudiante
    {

        // esto es lo que se va a crear en la tabla 
    [PrimaryKey,AutoIncrement]
    public int Id { set; get; }
        [MaxLength(255)]
        public string Nombre { set; get; }
        [MaxLength(255)]
        public string usuario { set; get; }
        [MaxLength(255)]
        public string contrasena { set; get; }

    }
}
