using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace _2a_bmi
{
    public partial class Form1 : Form
    {
        static string DatabaseName = "2a_bmi";
        static string Server = "localhost";
        static string UserName = "root";
        static string Password = "";


        private static MySqlConnection Connection = null;
        public Form1()
        {
            InitializeComponent();
            isConnection();
        }

        private bool isConnection()
        {
            if (Connection == null)
            {
                if (String.IsNullOrEmpty(DatabaseName))
                    return false;
                string connstring = string.Format("Server={0}; database={1}; UID={2}; password={3}",  Server, DatabaseName, UserName, Password);
                Connection = new MySqlConnection(connstring);
                Connection.Open();
            }

            return true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MySqlDataAdapter da = new MySqlDataAdapter("select * from wyniki", Connection);
            DataSet sd = new DataSet();
            da.Fill(sd);
            dataGridView1.DataSource = sd.Tables[0];
        }
    }
}
