using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Autokereskedes
{
    public partial class Márka : Form
    {
        Connection_Class conn_class;
        public Márka()
        {
            InitializeComponent();
            conn_class = new Connection_Class();
            conn_class.Connection();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if(conn_class.conn.State==ConnectionState.Closed)
            {
                conn_class.conn.Open();
            }
            
            string QUERY_INSERT_marka = $"INSERT INTO markak(marka) values(@marka)";

            using (MySqlCommand CMD_INSERT_marka=new MySqlCommand(QUERY_INSERT_marka, conn_class.conn))
            {
                CMD_INSERT_marka.Parameters.Add("@marka",MySqlDbType.String).Value =tbx_Márka.Text;

                if(CMD_INSERT_marka.ExecuteNonQuery()>0)
                {
                    conn_class.conn.Close();
                    MessageBox.Show("Sikeres hozzáadás!");
                }
            }
            
        }
    }
}
