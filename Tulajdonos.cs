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
    public partial class Tulajdonos : Form
    {
        Connection_Class conn_class;
        public Tulajdonos()
        {
            InitializeComponent();
            conn_class = new Connection_Class();
            conn_class.Connection();
        }

        private bool textbox_ellenorzes(TextBox txtbox)
        {
            txtbox.Text = txtbox.Text.Trim();
            bool result = false;
            if(!string.IsNullOrWhiteSpace(txtbox.Text))
            {
                result = true;
            }
            return result;
        }
        private void btn_Save_Click(object sender, EventArgs e)
        {
            bool dataLoader = true;
            for (int i = 0; i < groupBox1.Controls.Count; i++)
            {
                if(groupBox1.Controls[i] is TextBox)
                {
                    if(!textbox_ellenorzes(groupBox1.Controls[i] as TextBox) )
                    {
                        dataLoader = false;
                        MessageBox.Show("Üres beviteli mező");
                        (groupBox1.Controls[i] as TextBox).Focus();
                        break;
                    }
                }
            }
            if(dataLoader)
            {
                if (conn_class.conn.State == ConnectionState.Closed)
                {
                    conn_class.conn.Open();
                }

                string QUERY_INSERT_tulaj = $"INSERT INTO `tulajdonos`" +
                    $"(`vezeteknev`, `keresztnev`, `lakcim_irszam`, `lakcim_telepules`, `lakcim_kozterulet`, `lakcim_hazszam`, `telefon`) " +
                    $"VALUES (@veznev,@kernev,@irszam,@telepules,@kozterulet,@hazszam,@tel)";

                using (MySqlCommand CMD_INSERT_tulaj = new MySqlCommand(QUERY_INSERT_tulaj, conn_class.conn))
                {
                    try
                    {
                        CMD_INSERT_tulaj.Parameters.Add("@veznev", MySqlDbType.VarChar).Value = tbx_Vezeteknev.Text;
                        CMD_INSERT_tulaj.Parameters.Add("@kernev", MySqlDbType.VarChar).Value = tbx_Keresztnev.Text;
                        CMD_INSERT_tulaj.Parameters.Add("@irszam", MySqlDbType.Int32).Value = Convert.ToInt32(tbx_Iranyitoszam.Text);
                        CMD_INSERT_tulaj.Parameters.Add("@telepules", MySqlDbType.VarChar).Value = tbx_Telepules.Text;
                        CMD_INSERT_tulaj.Parameters.Add("@kozterulet", MySqlDbType.VarChar).Value = tbx_Kozterulet.Text;
                        CMD_INSERT_tulaj.Parameters.Add("@hazszam", MySqlDbType.VarChar).Value = tbx_Hazszam.Text;
                        CMD_INSERT_tulaj.Parameters.Add("@tel", MySqlDbType.VarChar).Value = tbx_Telefon.Text;

                        if (CMD_INSERT_tulaj.ExecuteNonQuery() > 0)
                        {
                            MessageBox.Show("Sikeres hozzáadás!");
                        }
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show(err.Message);
                    }
                    
                }
            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn_class.conn.State == ConnectionState.Closed)
                {
                    conn_class.conn.Open();
                }

                string ID_tulaj = "";

                string QUERY_SELECT_tulajID = "SELECT ID FROM tulajdonos WHERE vezeteknev=@veznev AND keresztnev=@kernev";
                string QUERY_SELECT_auto = "SELECT * FROM autok WHERE ID_tulajdonos=@idtulaj";
                string QUERY_DELETE_tulaj = "DELETE FROM tulajdonos WHERE vezeteknev=@veznev AND keresztnev=@kernev";

                using (MySqlCommand CMD_SELECT_tulajID = new MySqlCommand(QUERY_SELECT_tulajID, conn_class.conn))
                using (MySqlDataAdapter SDA_SELECT_tulajID = new MySqlDataAdapter(CMD_SELECT_tulajID))
                using (MySqlCommand CMD_SELECT_auto = new MySqlCommand(QUERY_SELECT_auto, conn_class.conn))
                using (MySqlDataAdapter SDA_SELECT_auto = new MySqlDataAdapter(CMD_SELECT_auto))
                using (MySqlCommand CMD_DELETE_tulaj = new MySqlCommand(QUERY_DELETE_tulaj, conn_class.conn))
                {
                    CMD_SELECT_tulajID.Parameters.Add("@veznev", MySqlDbType.VarChar).Value = tbx_DEL_vezeteknev.Text;
                    CMD_SELECT_tulajID.Parameters.Add("@kernev", MySqlDbType.VarChar).Value = tbx_DEL_keresztnev.Text;

                    DataTable DT_tulajid = new DataTable();
                    SDA_SELECT_tulajID.Fill(DT_tulajid);
                    if (DT_tulajid != null && DT_tulajid.Rows.Count > 0)
                    {
                        DataRow ROW_tulaj = DT_tulajid.Rows[0];

                        ID_tulaj = ROW_tulaj["ID"].ToString();
                    }

                    bool vanautoja = false;
                    CMD_SELECT_auto.Parameters.Add("@idtulaj", MySqlDbType.Int32).Value = Convert.ToInt32(ID_tulaj);
                    DataTable DT_auto = new DataTable();
                    SDA_SELECT_auto.Fill(DT_auto);

                    if (DT_auto.Rows.Count>0)
                    {
                        MessageBox.Show("Van autója");
                        vanautoja = true;
                    }
                    else
                    {
                        MessageBox.Show("Nincs autója");
                        vanautoja = false;
                    }

                    if (!vanautoja)
                    {
                        CMD_DELETE_tulaj.Parameters.Add("@veznev", MySqlDbType.VarChar).Value = tbx_DEL_vezeteknev.Text;
                        CMD_DELETE_tulaj.Parameters.Add("@kernev", MySqlDbType.VarChar).Value = tbx_DEL_keresztnev.Text;

                        if (CMD_DELETE_tulaj.ExecuteNonQuery() > 0)
                        {
                            MessageBox.Show("Sikeres törlés!");
                        }
                        else
                        {
                            MessageBox.Show("Nem sikerült a törlés!");
                        }
                    }
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
            
        }
    }
}
