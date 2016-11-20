using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Computer_accounting
{
    public partial class ChangeLogForm : Form
    {
        Computer computer;
        MySqlConnection conn;

        public ChangeLogForm(Computer computer, MySqlConnection conn)
        {
            InitializeComponent();

            this.computer = computer;
            this.conn = conn;

            UpdateDGV();

            dataGridView.CellFormatting += DataGridView_CellFormatting;
        }

        private void DataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value == null)
                return;
            else if (String.IsNullOrWhiteSpace(e.Value.ToString()))
                    return;

            if (e.ColumnIndex == this.dataGridView.Columns["cpuColumn"].Index)
            {
                DataGridViewCell cell = this.dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];

                String info = "";

                MySqlCommand cmd = new MySqlCommand(String.Format(
                    "SELECT * FROM cpus WHERE id={0}", cell.Value), conn);

                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                        info += dr.GetValue(1).ToString().Trim() + " "
                        + dr.GetValue(2).ToString().Trim() + " " + dr.GetValue(3).ToString().Trim();
                }

                cell.ToolTipText = info;
            }
            else if (e.ColumnIndex == this.dataGridView.Columns["memoryColumn"].Index)
            {
                DataGridViewCell cell = this.dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];

                String info = "";

                MySqlCommand cmd = new MySqlCommand(String.Format(
                    "SELECT * FROM memory WHERE id={0}", cell.Value), conn);

                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        info += dr.GetValue(1).ToString().Trim() + " "
                        + dr.GetValue(2).ToString().Trim() + " ";

                        if (!String.IsNullOrWhiteSpace(dr.GetValue(3).ToString()))
                            info += dr.GetValue(3).ToString().Trim() + "GHz ";
                        if (!String.IsNullOrWhiteSpace(dr.GetValue(4).ToString()))
                            info += dr.GetValue(4).ToString().Trim() + "Gb";
                    }
                }

                cell.ToolTipText = info;
            }
            else if (e.ColumnIndex == this.dataGridView.Columns["motherboardColumn"].Index)
            {
                DataGridViewCell cell = this.dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];

                String info = "";

                MySqlCommand cmd = new MySqlCommand(String.Format(
                    "SELECT * FROM motherboards WHERE id={0}", cell.Value), conn);

                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        info += dr.GetValue(1).ToString().Trim() + " "
                        + dr.GetValue(2).ToString().Trim() + " " + dr.GetValue(3).ToString().Trim()
                        + " " + dr.GetValue(4).ToString().Trim();
                    }
                }

                cell.ToolTipText = info;
            }
            else if (e.ColumnIndex == this.dataGridView.Columns["graphicsCardColumn"].Index)
            {
                DataGridViewCell cell = this.dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];

                String info = "";

                MySqlCommand cmd = new MySqlCommand(String.Format(
                    "SELECT * FROM graphics_cards WHERE id={0}", cell.Value), conn);

                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        info += dr.GetValue(1).ToString().Trim() + " "
                        + dr.GetValue(2).ToString().Trim() + " ";

                        if (!String.IsNullOrWhiteSpace(dr.GetValue(3).ToString()))
                            info += dr.GetValue(3).ToString().Trim() + "Gb";
                    }
                }

                cell.ToolTipText = info;
            }
            else if (e.ColumnIndex == this.dataGridView.Columns["hardDriveColumn"].Index)
            {
                DataGridViewCell cell = this.dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];

                String info = "";

                MySqlCommand cmd = new MySqlCommand(String.Format(
                    "SELECT * FROM internal_hard_drives WHERE id={0}", cell.Value), conn);

                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        info += dr.GetValue(1).ToString().Trim() + " "
                        + dr.GetValue(2).ToString().Trim();

                        if (!String.IsNullOrWhiteSpace(dr.GetValue(3).ToString()))
                            info += " " + dr.GetValue(3).ToString().Trim() + "Gb";
                    }
                }

                cell.ToolTipText = info;
            }
            else if (e.ColumnIndex == this.dataGridView.Columns["keyboardColumn"].Index)
            {
                DataGridViewCell cell = this.dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];

                String info = "";

                MySqlCommand cmd = new MySqlCommand(String.Format(
                    "SELECT * FROM keyboards WHERE id={0}", cell.Value), conn);

                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        info += dr.GetValue(1).ToString().Trim() + " "
                        + dr.GetValue(2).ToString().Trim();
                    }
                }

                cell.ToolTipText = info;
            }
            else if (e.ColumnIndex == this.dataGridView.Columns["monitorColumn"].Index)
            {
                DataGridViewCell cell = this.dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];

                String info = "";

                MySqlCommand cmd = new MySqlCommand(String.Format(
                    "SELECT * FROM monitors WHERE id={0}", cell.Value), conn);

                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        info += dr.GetValue(1).ToString().Trim() + " "
                        + dr.GetValue(2).ToString().Trim() + " " + dr.GetValue(3).ToString().Trim() + "\"";
                    }
                }

                cell.ToolTipText = info;
            }
            else if (e.ColumnIndex == this.dataGridView.Columns["mouseColumn"].Index)
            {
                DataGridViewCell cell = this.dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];

                String info = "";

                MySqlCommand cmd = new MySqlCommand(String.Format(
                    "SELECT * FROM mouses WHERE id={0}", cell.Value), conn);

                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        info += dr.GetValue(1).ToString().Trim() + " "
                        + dr.GetValue(2).ToString().Trim();
                    }
                }

                cell.ToolTipText = info;
            }
        }

        private void UpdateDGV()
        {
            MySqlCommand cmd = new MySqlCommand(
                String.Format("SELECT * FROM computers_log WHERE computer_id=\"{0}\"", computer.id), conn);

            using (MySqlDataReader dr = cmd.ExecuteReader())
            {
                while(dr.Read())
                {
                    dataGridView.Rows.Add(dr.GetDateTime(10).ToString("yyyy-MM-dd"), 
                        dr.GetValue(2), dr.GetValue(3), dr.GetValue(4), dr.GetValue(5), dr.GetValue(6),
                        dr.GetValue(7), dr.GetValue(8), dr.GetValue(9), dr.GetValue(11));
                }
            }
            dataGridView.ReadOnly = true;
        }
    }
}
