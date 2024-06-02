using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Customs
{
    public partial class Form2 : Form
    {
        private MySqlConnection sqlConn;
        private MySqlDataAdapter sqlData;
        private DataSet dataSet;
        private DataSet dataSetSec;
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int j = 0;
                bool flag = false;
                int speed = 0;
                double final = 0;
                int ShipNum = Convert.ToInt32(textBox1.Text);

                sqlData = new MySqlDataAdapter($"SELECT * FROM Batch WHERE ShipmentID = {ShipNum}", sqlConn);
                dataSet = new DataSet();
                sqlData.Fill(dataSet, "Batch");

                sqlData = new MySqlDataAdapter("SELECT * FROM Process", sqlConn);
                dataSetSec = new DataSet();
                sqlData.Fill(dataSetSec, "Process");


                for (int i = 0; i < dataSet.Tables["Batch"].Rows.Count; i++) 
                {
                    while (!flag)
                    {
                        if(Convert.ToInt32(dataSetSec.Tables["Process"].Rows[j]["BatchTypeId"]) == Convert.ToInt32(dataSet.Tables["Batch"].Rows[i]["BatchTypeID"]))
                        {
                            speed = Convert.ToInt32(dataSetSec.Tables["Process"].Rows[j]["Volume"]);
                            flag = true;
                        } 
                        j++;
                    }
                    final += (double)Convert.ToInt32(dataSet.Tables["Batch"].Rows[i]["Volume"])/(double)speed;
                    j = 0;
                    flag = false;
                }
                MessageBox.Show(final.ToString());

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ОШИБКА СТОП", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            string arg = "server=localhost;user=root;database=Kurs;";
            sqlConn = new MySqlConnection(arg);
            try
            {
                sqlConn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ОШИБКА СТОП", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
