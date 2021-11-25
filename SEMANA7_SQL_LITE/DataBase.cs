using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace SEMANA7_SQL_LITE
{
    public interface DataBase
    {

        //METODO
        SQLiteAsyncConnection GetConnection();
    }
}
