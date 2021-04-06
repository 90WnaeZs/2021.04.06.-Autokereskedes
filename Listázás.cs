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
    public partial class Listázás : Form
    {
        Connection_Class conn_class;
        public Listázás()
        {
            InitializeComponent();
            conn_class = new Connection_Class();
            conn_class.Connection();
            tbx_veznev.Text = "A";
            tbx_kernev.Text = "B";
        }

        private void btn_Keresés_Click(object sender, EventArgs e)
        {
            
            string ID = "";
            object scalar_result;
            if (conn_class.conn.State==ConnectionState.Closed)
            {
                conn_class.conn.Open();
            }

            if (tbx_veznev.Text == "" && tbx_kernev.Text == "")
            {
                string QUERY_SELECT_ALL = "SELECT markak.marka, autok.evjarat FROM autok JOIN markak ON markak.ID=autok.ID_marka ORDER BY autok.evjarat ASC";
                using (MySqlCommand CMD_SELECT_ALL = new MySqlCommand(QUERY_SELECT_ALL, conn_class.conn))
                {
                    try
                    {
                        DataTable DT_SELECT_ALL = new DataTable();
                        MySqlDataReader DR_SELECT_ALL = CMD_SELECT_ALL.ExecuteReader();
                        DT_SELECT_ALL.Load(DR_SELECT_ALL);
                        DR_SELECT_ALL.Close();
                        dataGridView1.DataSource = DT_SELECT_ALL;
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
            else if (tbx_veznev.Text != "" && tbx_kernev.Text != "")
            {
                string QUERY_SELECT_ügyfélID = "SELECT ID FROM tulajdonos WHERE vezeteknev=@veznev AND keresztnev=@kernev";
                using (MySqlCommand CMD_SELECT_ügyfélID = new MySqlCommand(QUERY_SELECT_ügyfélID, conn_class.conn))
                {
                    CMD_SELECT_ügyfélID.Parameters.Add("@veznev", MySqlDbType.VarChar).Value = tbx_veznev.Text;
                    CMD_SELECT_ügyfélID.Parameters.Add("@kernev", MySqlDbType.VarChar).Value = tbx_kernev.Text;

                    scalar_result = CMD_SELECT_ügyfélID.ExecuteScalar();

                    if (scalar_result != null)
                    {
                        ID = CMD_SELECT_ügyfélID.ExecuteScalar().ToString();
                    }
                }

                if(scalar_result != null)
                {
                    string QUERY_SELECT_ügyfél = "SELECT * FROM tulajdonos WHERE ID=@tul_id";
                    using (MySqlCommand CMD_SELECT_ügyfél = new MySqlCommand(QUERY_SELECT_ügyfél, conn_class.conn))
                    {
                        CMD_SELECT_ügyfél.Parameters.Add("@tul_id", MySqlDbType.Int32).Value = ID;
                        try
                        {
                            DataTable DT = new DataTable();
                            MySqlDataReader READER_SELECT_ügyfél = CMD_SELECT_ügyfél.ExecuteReader();
                            DT.Load(READER_SELECT_ügyfél);

                            READER_SELECT_ügyfél.Close();
                            dataGridView1.DataSource = DT;
                        }
                        catch (Exception err)
                        {
                            MessageBox.Show(err.Message);
                        }
                    }

                    string QUERY_SELECT_autók = "SELECT * FROM autok WHERE ID_tulajdonos=@id";
                    using (MySqlCommand CMD_SELECT_autók = new MySqlCommand(QUERY_SELECT_autók, conn_class.conn))
                    {

                        CMD_SELECT_autók.Parameters.Add("@id", MySqlDbType.Int32).Value = Convert.ToInt32(ID);
                        try
                        {
                            DataTable DT2 = new DataTable();
                            MySqlDataReader READER_SELECT_autók = CMD_SELECT_autók.ExecuteReader();
                            DT2.Load(READER_SELECT_autók);

                            READER_SELECT_autók.Close();
                            dataGridView2.DataSource = DT2;
                        }
                        catch (Exception err)
                        {
                            MessageBox.Show(err.Message);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Nincs ilyen ügyfél!");
                }
            }
        }
    }
}
