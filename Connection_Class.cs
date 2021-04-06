using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Autokereskedes
{
    class Connection_Class
    {
        public MySqlConnection conn;
        public void Connection()
        {
            MySqlConnectionStringBuilder db = new MySqlConnectionStringBuilder();
            db.Server = "localhost";
            db.Database = "autokereskedes";
            db.UserID = "root";
            db.Password = "";

            conn = new MySqlConnection(db.ToString());
            conn.Open();
        }
        
    }
}
