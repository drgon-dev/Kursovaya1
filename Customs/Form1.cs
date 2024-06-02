using System.Diagnostics;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
namespace Customs
{
    public partial class Form1 : Form
    {
        private MySqlConnection sqlConn;
        private MySqlCommandBuilder sqlBuilder;
        private MySqlDataAdapter sqlData;
        private DataSet dataSet;

        private string table = "State";
        private int tableRows = 2;

        private bool newAdding = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            try
            {
                sqlData = new MySqlDataAdapter($"SELECT *, 'Delete' AS 'Delete' FROM {table}", sqlConn);

                sqlBuilder = new MySqlCommandBuilder(sqlData);
                sqlBuilder.GetInsertCommand();
                sqlBuilder.GetUpdateCommand();
                sqlBuilder.GetDeleteCommand();

                dataSet = new DataSet();

                sqlData.Fill(dataSet, table);

                dataGridViewMain.DataSource = dataSet.Tables[table];

                for (int i = 0; i < dataGridViewMain.Rows.Count; i++)
                {
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    dataGridViewMain[tableRows, i] = linkCell;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ÎØÈÁÊÀ ÑÒÎÏ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ReloadData()
        {
            try
            {
                if (dataSet == null)
                    throw new Exception("dataset == null!");
                dataSet.Tables[table].Clear();
                sqlData.Fill(dataSet, table);

                dataGridViewMain.DataSource = dataSet.Tables[table];

                for (int i = 0; i < dataGridViewMain.Rows.Count; i++)
                {
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    dataGridViewMain[tableRows, i] = linkCell;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ÎØÈÁÊÀ ÑÒÎÏ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string arg = "server=localhost;user=root;database=Kurs;";
            sqlConn = new MySqlConnection(arg);
            try
            {
                sqlConn.Open();
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ÎØÈÁÊÀ ÑÒÎÏ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void StripButtonReload_Click(object sender, EventArgs e)
        {
            ReloadData();
        }

        private void dataGridViewMain_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == tableRows)
                {
                    string task = dataGridViewMain.Rows[e.RowIndex].Cells[tableRows].Value.ToString();
                    if (task == "Delete")
                    {
                        int rowIndex = e.RowIndex;
                        dataGridViewMain.Rows.RemoveAt(rowIndex);
                        dataSet.Tables[table].Rows[rowIndex].Delete();
                        sqlData.Update(dataSet, table);
                    }
                    else if (task == "Insert")
                    {
                        int rowIndex = dataGridViewMain.Rows.Count - 2;
                        DataRow row = dataSet.Tables[table].NewRow();

                        if (table == "State")
                        {
                            row["StateID"] = dataGridViewMain.Rows[rowIndex].Cells["StateID"].Value;
                            row["StateName"] = dataGridViewMain.Rows[rowIndex].Cells["StateName"].Value;
                        }
                        else if (table == "BatchType")
                        {
                            row["BatchTypeID"] = dataGridViewMain.Rows[rowIndex].Cells["BatchTypeID"].Value;
                            row["TypeName"] = dataGridViewMain.Rows[rowIndex].Cells["TypeName"].Value;
                        }
                        else if (table == "Batch")
                        {
                            row["BatchID"] = dataGridViewMain.Rows[rowIndex].Cells["BatchID"].Value;
                            row["BatchTypeID"] = dataGridViewMain.Rows[rowIndex].Cells["BatchTypeID"].Value;
                            row["ShipmentID"] = dataGridViewMain.Rows[rowIndex].Cells["ShipmentID"].Value;
                            row["Volume"] = dataGridViewMain.Rows[rowIndex].Cells["Volume"].Value;
                        }
                        else if (table == "Customs")
                        {
                            row["CustomsID"] = dataGridViewMain.Rows[rowIndex].Cells["CustomsID"].Value;
                            row["StateID"] = dataGridViewMain.Rows[rowIndex].Cells["StateID"].Value;
                            row["CustomsLocation"] = dataGridViewMain.Rows[rowIndex].Cells["CustomsLocation"].Value;
                            row["CustomsName"] = dataGridViewMain.Rows[rowIndex].Cells["CustomsName"].Value;
                        }
                        else if (table == "Process")
                        {
                            row["ProcessID"] = dataGridViewMain.Rows[rowIndex].Cells["ProcessID"].Value;
                            row["CustomsID"] = dataGridViewMain.Rows[rowIndex].Cells["CustomsID"].Value;
                            row["BatchTypeID"] = dataGridViewMain.Rows[rowIndex].Cells["BatchTypeID"].Value;
                            row["Volume"] = dataGridViewMain.Rows[rowIndex].Cells["Volume"].Value;
                            row["Finished"] = dataGridViewMain.Rows[rowIndex].Cells["Finished"].Value;
                        }
                        else if (table == "Schedule")
                        {
                            row["ScheduleID"] = dataGridViewMain.Rows[rowIndex].Cells["ScheduleID"].Value;
                            row["CustomsID"] = dataGridViewMain.Rows[rowIndex].Cells["CustomsID"].Value;
                            row["ShipmentID"] = dataGridViewMain.Rows[rowIndex].Cells["ShipmentID"].Value;
                            row["Time"] = dataGridViewMain.Rows[rowIndex].Cells["Time"].Value;
                            row["Date"] = dataGridViewMain.Rows[rowIndex].Cells["Date"].Value;
                        }
                        else if (table == "Shipment")
                        {
                            row["ShipmentID"] = dataGridViewMain.Rows[rowIndex].Cells["ShipmentID"].Value;
                            row["StateID"] = dataGridViewMain.Rows[rowIndex].Cells["StateID"].Value;
                            row["ShipmentName"] = dataGridViewMain.Rows[rowIndex].Cells["ShipmentName"].Value;
                        }
                        dataSet.Tables[table].Rows.Add(row);
                        dataSet.Tables[table].Rows.RemoveAt(dataSet.Tables[table].Rows.Count - 1);
                        dataGridViewMain.Rows.RemoveAt(dataGridViewMain.Rows.Count - 2);
                        dataGridViewMain.Rows[e.RowIndex].Cells[tableRows].Value = "Delete";
                        sqlData.Update(dataSet, table);
                        newAdding = false;
                    }
                    else if (task == "Update")
                    {
                        int r = e.RowIndex;
                        if (table == "State")
                        {
                            dataSet.Tables[table].Rows[r]["StateID"] = dataGridViewMain.Rows[r].Cells["StateID"].Value;
                            dataSet.Tables[table].Rows[r]["StateName"] = dataGridViewMain.Rows[r].Cells["StateName"].Value;
                        }
                        else if (table == "BatchType")
                        {
                            dataSet.Tables[table].Rows[r]["BatchTypeID"] = dataGridViewMain.Rows[r].Cells["BatchTypeID"].Value;
                            dataSet.Tables[table].Rows[r]["TypeName"] = dataGridViewMain.Rows[r].Cells["TypeName"].Value;
                        }
                        else if (table == "Batch")
                        {
                            dataSet.Tables[table].Rows[r]["BatchID"] = dataGridViewMain.Rows[r].Cells["BatchID"].Value;
                            dataSet.Tables[table].Rows[r]["BatchTypeID"] = dataGridViewMain.Rows[r].Cells["BatchTypeID"].Value;
                            dataSet.Tables[table].Rows[r]["ShipmentID"] = dataGridViewMain.Rows[r].Cells["ShipmentID"].Value;
                            dataSet.Tables[table].Rows[r]["Volume"] = dataGridViewMain.Rows[r].Cells["Volume"].Value;
                        }
                        else if (table == "Customs")
                        {
                            dataSet.Tables[table].Rows[r]["CustomsID"] = dataGridViewMain.Rows[r].Cells["CustomsID"].Value;
                            dataSet.Tables[table].Rows[r]["StateID"] = dataGridViewMain.Rows[r].Cells["StateID"].Value;
                            dataSet.Tables[table].Rows[r]["CustomsLocation"] = dataGridViewMain.Rows[r].Cells["CustomsLocation"].Value;
                            dataSet.Tables[table].Rows[r]["CustomsName"] = dataGridViewMain.Rows[r].Cells["CustomsName"].Value;
                        }
                        else if (table == "Process")
                        {
                            dataSet.Tables[table].Rows[r]["ProcessID"] = dataGridViewMain.Rows[r].Cells["ProcessID"].Value;
                            dataSet.Tables[table].Rows[r]["CustomsID"] = dataGridViewMain.Rows[r].Cells["CustomsID"].Value;
                            dataSet.Tables[table].Rows[r]["BatchTypeID"] = dataGridViewMain.Rows[r].Cells["BatchTypeID"].Value;
                            dataSet.Tables[table].Rows[r]["Volume"] = dataGridViewMain.Rows[r].Cells["Volume"].Value;
                            dataSet.Tables[table].Rows[r]["Finished"] = dataGridViewMain.Rows[r].Cells["Finished"].Value;
                        }
                        else if (table == "Schedule")
                        {
                            dataSet.Tables[table].Rows[r]["ScheduleID"] = dataGridViewMain.Rows[r].Cells["ScheduleID"].Value;
                            dataSet.Tables[table].Rows[r]["CustomsID"] = dataGridViewMain.Rows[r].Cells["CustomsID"].Value;
                            dataSet.Tables[table].Rows[r]["ShipmentID"] = dataGridViewMain.Rows[r].Cells["ShipmentID"].Value;
                            dataSet.Tables[table].Rows[r]["Time"] = dataGridViewMain.Rows[r].Cells["Time"].Value;
                            dataSet.Tables[table].Rows[r]["Date"] = dataGridViewMain.Rows[r].Cells["Date"].Value;
                        }
                        else if (table == "Shipment")
                        {
                            dataSet.Tables[table].Rows[r]["ShipmentID"] = dataGridViewMain.Rows[r].Cells["ShipmentID"].Value;
                            dataSet.Tables[table].Rows[r]["StateId"] = dataGridViewMain.Rows[r].Cells["StateID"].Value;
                            dataSet.Tables[table].Rows[r]["ShipmentName"] = dataGridViewMain.Rows[r].Cells["ShipmentName"].Value;
                        }
                        sqlData.Update(dataSet, table);

                        dataGridViewMain.Rows[e.RowIndex].Cells[tableRows].Value = "Delete";
                    }
                }
                ReloadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ÎØÈÁÊÀ ÑÒÎÏ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewMain_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            try
            {
                if (newAdding == false)
                {
                    newAdding = true;
                    int lastRow = dataGridViewMain.Rows.Count - 2;
                    DataGridViewRow row = dataGridViewMain.Rows[lastRow];

                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    dataGridViewMain[tableRows, lastRow] = linkCell;
                    row.Cells["Delete"].Value = "Insert";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ÎØÈÁÊÀ ÑÒÎÏ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewMain_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (newAdding == false)
                {
                    int rowIndex = dataGridViewMain.SelectedCells[0].RowIndex;
                    DataGridViewRow editingRow = dataGridViewMain.Rows[rowIndex];

                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    dataGridViewMain[tableRows, rowIndex] = linkCell;
                    editingRow.Cells["Delete"].Value = "Update";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ÎØÈÁÊÀ ÑÒÎÏ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void stateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            table = "State";
            tableRows = 2;
            newAdding = false;
            LoadData();
        }

        private void batchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            table = "Batch";
            tableRows = 4;
            newAdding = false;
            LoadData();
        }

        private void batchTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            table = "BatchType";
            tableRows = 2;
            newAdding = false;
            LoadData();
        }

        private void customsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            table = "Customs";
            tableRows = 4;
            newAdding = false;
            LoadData();
        }

        private void processToolStripMenuItem_Click(object sender, EventArgs e)
        {
            table = "Process";
            tableRows = 4;
            newAdding = false;
            LoadData();
        }

        private void scheduleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            table = "Schedule";
            tableRows = 5;
            newAdding = false;
            LoadData();
        }

        private void shipmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            table = "Shipment";
            tableRows = 3;
            newAdding = false;
            LoadData();
        }

        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            new Form2().Show();
        }

        private void dataGridViewMain_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(Column_KeyPress);

            if (dataGridViewMain.CurrentCell.ColumnIndex == 0) 
            {
                TextBox textBox = e.Control as TextBox;
                if(textBox != null)
                {
                    textBox.KeyPress += new KeyPressEventHandler(Column_KeyPress);
                }
            }
        }
        private void Column_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}