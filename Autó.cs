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
    public partial class Autó : Form
    {
        Connection_Class conn_class;
        MySqlDataReader READER_márka;
        MySqlDataReader READER_tulaj;
        public Autó()
        {
            InitializeComponent();
            conn_class = new Connection_Class();
            conn_class.Connection();
            using (MySqlCommand CMD_márka = new MySqlCommand("Select marka From markak", conn_class.conn))
            using (MySqlCommand CMD_tulaj = new MySqlCommand("Select vezeteknev, keresztnev From tulajdonos", conn_class.conn))
            using (READER_márka = CMD_márka.ExecuteReader())
            {
                while (READER_márka.Read())
                {
                    combo_Márka.Items.Add(READER_márka.GetString("marka"));
                }
                READER_márka.Close();
                using (READER_tulaj = CMD_tulaj.ExecuteReader())
                {
                    while (READER_tulaj.Read())
                    {
                        string teljesnév = READER_tulaj.GetString("vezeteknev") + " " + READER_tulaj.GetString("keresztnev");
                        combo_tulaj.Items.Add(teljesnév);
                    }
                    READER_tulaj.Close();
                }
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (conn_class.conn.State == ConnectionState.Closed)
            {
                conn_class.conn.Open();
            }

            string QUERY_SELECT_markaID = "SELECT ID FROM markak WHERE marka=@marka";
            string QUERY_SELECT_tulajID = "SELECT ID FROM tulajdonos WHERE vezeteknev=@veznev AND keresztnev=@kernev";
            string QUERY_INSERT_auto = $"INSERT INTO autok(ID_marka,evjarat,kilometer,iranyar,minimum_ar,ID_tulajdonos) values(@markaID, @evjarat,@km,@iranyar,@minar,@tulajID)";

            using (MySqlCommand CMD_SELECT_markaID = new MySqlCommand(QUERY_SELECT_markaID, conn_class.conn))
            using (MySqlCommand CMD_SELECT_tulajID = new MySqlCommand(QUERY_SELECT_tulajID, conn_class.conn))
            using (MySqlCommand CMD_INSERT_auto = new MySqlCommand(QUERY_INSERT_auto, conn_class.conn))
            {
                string markaID = "";
                string tulajID = "";

                CMD_SELECT_markaID.Parameters.Add("@marka", MySqlDbType.VarChar).Value = combo_Márka.Text;
                using (MySqlDataReader READER_SELECT_markaID = CMD_SELECT_markaID.ExecuteReader())
                {
                    
                    while (READER_SELECT_markaID.Read())
                    {
                        markaID = READER_SELECT_markaID.GetString("ID");
                    }
                    READER_SELECT_markaID.Close();
                }

                var s = combo_Márka.Text.Split(" ".ToCharArray());

                CMD_SELECT_tulajID.Parameters.Add("@veznev", MySqlDbType.VarChar).Value = "A";
                CMD_SELECT_tulajID.Parameters.Add("@kernev", MySqlDbType.VarChar).Value = "B";
                using (MySqlDataReader READER_SELECT_tulajID = CMD_SELECT_tulajID.ExecuteReader())
                {
                    
                    while (READER_SELECT_tulajID.Read())
                    {
                        tulajID = READER_SELECT_tulajID.GetString("ID");
                    }
                    READER_SELECT_tulajID.Close();
                }
                //@markaID, @evjarat,@km,@iranyar,@minar,@tulajID
                CMD_INSERT_auto.Parameters.Add("@markaID", MySqlDbType.Int32).Value = Convert.ToInt32(markaID);
                CMD_INSERT_auto.Parameters.Add("@evjarat", MySqlDbType.Year).Value = Convert.ToInt32(tbx_Évjárat.Text);
                CMD_INSERT_auto.Parameters.Add("@km", MySqlDbType.Int32).Value = Convert.ToInt32(tbx_Km.Text);
                CMD_INSERT_auto.Parameters.Add("@iranyar", MySqlDbType.Int32).Value = Convert.ToInt32(tbx_irányár2.Text);
                CMD_INSERT_auto.Parameters.Add("@minar", MySqlDbType.Int32).Value = Convert.ToInt32(tbx_minÁr.Text);
                CMD_INSERT_auto.Parameters.Add("@tulajID", MySqlDbType.Int32).Value = Convert.ToInt32(tulajID);
                if (CMD_INSERT_auto.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Sikeres hozzáadás!");
                }
                else
                {
                    MessageBox.Show("Nem sikerült a hozzáadás!" + markaID + " " + tulajID);
                }
                //teljesnév = READER_tulaj.GetString("vezeteknev") + " " + READER_tulaj.GetString("keresztnev");


            }
        }
    }
}

