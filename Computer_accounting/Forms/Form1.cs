using System;
using System.Data;
using System.Linq;
using System.Management;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace Computer_accounting
{
    public partial class Form1 : Form
    {        
        MySqlConnection conn;
        List<Computer> computers = new List<Computer>();

        public Form1()
        {
            InitializeComponent();

            dataGridView.CellClick += new DataGridViewCellEventHandler(CellClick);

            aboutToolStripMenuItem.Click += new EventHandler(aboutMenu_Click);
            connectToolStripMenuItem.Click += new EventHandler(connectMenu_Click);
            disconnectToolStripMenuItem.Click += new EventHandler(disconnectMenu_Click);

            this.KeyPreview = true;
        }

        private void disconnectMenu_Click(object sender, EventArgs e)
        {
            if (conn == null)
                return;

            conn.Close();
            dataGridView.Rows.Clear();
            conn = null;
        }

        private void aboutMenu_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Программа для учета работающих в сети организации компьютеров ",
                "About program");
        }

        private void connectMenu_Click(object sender, EventArgs e)
        {
            ConnectForm cf = new ConnectForm();

            if (cf.ShowDialog() == DialogResult.OK)
            {
                this.conn = cf.conn;
                updateDGV();
            }

        }

        private void CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (conn == null)
                return;

            if (e.RowIndex < 0 || e.RowIndex > dataGridView.Rows.Count)
                return;

            if (e.ColumnIndex == 4)
            {
                String fullInfo = "";

                var res = computers.Where(
                    (a) => a.id == dataGridView.Rows[e.RowIndex].Cells[0].Value.ToString());

                Computer computer = new Computer(res.ElementAt(0).id,
                    res.ElementAt(0).cpu_id, res.ElementAt(0).memory_id, res.ElementAt(0).motherboard_id);
                computer.graphics_id = res.ElementAt(0).graphics_id;
                computer.hard_drive_id = res.ElementAt(0).hard_drive_id;
                computer.keyboard_id = res.ElementAt(0).keyboard_id;
                computer.monitor_id = res.ElementAt(0).monitor_id;
                computer.mouse_id = res.ElementAt(0).mouse_id;

                #region get fullinfo
                MySqlCommand cmd = new MySqlCommand(String.Format(
                    "SELECT * FROM cpus WHERE id={0}", computer.cpu_id), conn);

                fullInfo += "CPU: ";
                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        fullInfo += dr.GetValue(1).ToString().Trim() + " "
                        + dr.GetValue(2).ToString().Trim() + " " + dr.GetValue(3).ToString().Trim();
                    }
                }

                cmd = new MySqlCommand(String.Format(
                    "SELECT * FROM memory WHERE id={0}", computer.memory_id), conn);

                fullInfo += "\nMemory: ";
                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        fullInfo += dr.GetValue(1).ToString().Trim() + " "
                        + dr.GetValue(2).ToString().Trim() + " ";

                        if (!String.IsNullOrWhiteSpace(dr.GetValue(3).ToString()))
                            fullInfo += dr.GetValue(3).ToString().Trim() + "GHz ";
                        if(!String.IsNullOrWhiteSpace(dr.GetValue(4).ToString()))
                            fullInfo += dr.GetValue(4).ToString().Trim() + "Gb";
                    }
                }

                cmd = new MySqlCommand(String.Format(
                    "SELECT * FROM motherboards WHERE id={0}", computer.motherboard_id), conn);

                fullInfo += "\nMotherboard: ";
                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        fullInfo += dr.GetValue(1).ToString().Trim() + " "
                        + dr.GetValue(2).ToString().Trim() + " " + dr.GetValue(3).ToString().Trim()
                        + " " + dr.GetValue(4).ToString().Trim();
                    }
                }

                cmd = new MySqlCommand(String.Format(
                    "SELECT * FROM graphics_cards WHERE id={0}", computer.graphics_id), conn);

                fullInfo += "\nGraphics card: ";
                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        fullInfo += dr.GetValue(1).ToString().Trim() + " "
                        + dr.GetValue(2).ToString().Trim() + " ";

                        if(!String.IsNullOrWhiteSpace(dr.GetValue(3).ToString()))
                            fullInfo += dr.GetValue(3).ToString().Trim() + "Gb";
                    }
                }

                cmd = new MySqlCommand(String.Format(
                    "SELECT * FROM internal_hard_drives WHERE id={0}", computer.hard_drive_id), conn);

                fullInfo += "\nInternal hard drive: ";
                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        fullInfo += dr.GetValue(1).ToString().Trim() + " "
                        + dr.GetValue(2).ToString().Trim();

                        if (!String.IsNullOrWhiteSpace(dr.GetValue(3).ToString()))
                            fullInfo += " " + dr.GetValue(3).ToString().Trim() + "Gb";
                    }
                }

                cmd = new MySqlCommand(String.Format(
                    "SELECT * FROM keyboards WHERE id={0}", computer.keyboard_id), conn);

                fullInfo += "\n----------------periphery-------------------\nKeyboard: ";
                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        fullInfo += dr.GetValue(1).ToString().Trim() + " "
                        + dr.GetValue(2).ToString().Trim();
                    }
                }

                cmd = new MySqlCommand(String.Format(
                    "SELECT * FROM monitors WHERE id={0}", computer.monitor_id), conn);

                fullInfo += "\nMonitor: ";
                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        fullInfo += dr.GetValue(1).ToString().Trim() + " "
                        + dr.GetValue(2).ToString().Trim() + " " + dr.GetValue(3).ToString().Trim() + "\"";
                    }
                }

                cmd = new MySqlCommand(String.Format(
                   "SELECT * FROM mouses WHERE id={0}", computer.mouse_id), conn);

                fullInfo += "\nMouse: ";
                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        fullInfo += dr.GetValue(1).ToString().Trim() + " "
                        + dr.GetValue(2).ToString().Trim();
                    }
                }
                #endregion sql

                MessageBox.Show(fullInfo, "Full info");
            }
            else if (e.ColumnIndex == 5)
            {
                var res = computers.Where(
                    (a) => a.id == dataGridView.Rows[e.RowIndex].Cells[0].Value.ToString());

                Computer computer = new Computer(res.ElementAt(0).id,
                    res.ElementAt(0).cpu_id, res.ElementAt(0).memory_id, res.ElementAt(0).motherboard_id);

                ChangeLogForm clf = new ChangeLogForm(computer, conn);
                clf.ShowDialog();
            }
            else return;
        }

        private void updateDGV()
        {
            dataGridView.Rows.Clear();
            computers.Clear();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM computers", conn);

            using (MySqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    Computer computer = new Computer(dr.GetValue(0).ToString(),
                        (int)dr.GetValue(1), (int)dr.GetValue(2), (int)dr.GetValue(3));

                    if(!String.IsNullOrEmpty(dr.GetValue(4).ToString()))
                        computer.graphics_id = (int)dr.GetValue(4);
                    if (!String.IsNullOrEmpty(dr.GetValue(5).ToString()))
                        computer.hard_drive_id = (int)dr.GetValue(5);
                    if (!String.IsNullOrEmpty(dr.GetValue(6).ToString()))
                        computer.keyboard_id = (int)dr.GetValue(6);
                    if (!String.IsNullOrEmpty(dr.GetValue(7).ToString()))
                        computer.monitor_id = (int)dr.GetValue(7);
                    if (!String.IsNullOrEmpty(dr.GetValue(8).ToString()))
                        computer.mouse_id = (int)dr.GetValue(8);

                    computers.Add(computer);
                }
            }

           foreach(Computer computer in computers)
            {
                dataGridView.Rows.Add(computer.id, computer.cpu_id, computer.memory_id, computer.motherboard_id);
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (conn == null)
                return;

            AddForm af = new AddForm(conn);
            if (af.ShowDialog() == DialogResult.OK)
                updateDGV();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (conn == null)
                return;

            foreach(DataGridViewRow row in dataGridView.SelectedRows)
            {
                if (MessageBox.Show("Are you sure you want to delete this data?",
                    "Delete data", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    String today = String.Format("{0:yyyy-MM-dd}", DateTime.Today);

                    MySqlCommand cmd = new MySqlCommand(
                    String.Format("INSERT INTO computers_log(computer_id, cpu_id, memory_id, motherboard_id,"+
                    " graphics_id, hard_drive_id, keyboard_id, monitor_id, mouse_id) SELECT " +
                    "id, cpu_id, memory_id, motherboard_id, graphics_id," +
                    " hard_drive_id, keyboard_id, monitor_id, mouse_id FROM computers WHERE computers.id=\"{0}\"",
                    row.Cells["IdColumn"].Value), conn);
                    cmd.ExecuteNonQuery();
                    long id = cmd.LastInsertedId;

                    cmd = new MySqlCommand(
                        String.Format("UPDATE computers_log SET date=\"{0}\", operation=\"delete\" WHERE id={1}"
                        , today, id), conn);
                    cmd.ExecuteNonQuery();

                    cmd = new MySqlCommand(
                        String.Format("DELETE FROM computers WHERE id=\"{0}\"", row.Cells["IdColumn"].Value), conn);
                    cmd.ExecuteNonQuery();
                }
                updateDGV();
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (conn == null)
                return;

            foreach (DataGridViewRow row in dataGridView.SelectedRows)
            {
                var res = computers.Where((a) => a.id == row.Cells["idColumn"].Value.ToString());

                Computer computer = new Computer(res.ElementAt(0).id,
                    res.ElementAt(0).cpu_id, res.ElementAt(0).memory_id, res.ElementAt(0).motherboard_id);
                computer.graphics_id = res.ElementAt(0).graphics_id;
                computer.hard_drive_id = res.ElementAt(0).hard_drive_id;
                computer.keyboard_id = res.ElementAt(0).keyboard_id;
                computer.monitor_id = res.ElementAt(0).monitor_id;
                computer.mouse_id = res.ElementAt(0).mouse_id;

                UpdateForm uf = new UpdateForm(computer, conn);
                uf.ShowDialog();
            }
            updateDGV();
        }

        private void buttonFullLog_Click(object sender, EventArgs e)
        {
            if (conn == null)
                return;

            FullChageLogForm fclf = new FullChageLogForm(conn);
            fclf.ShowDialog();
        }

        private void autoUpdateCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (conn == null)
                return;

            if (autoUpdateCheckBox.Checked)
                timer1.Start();
            else timer1.Stop();
        }

        private void computerButton_Click(object sender, EventArgs e)
        {
            if (conn == null)
                return;

            AddThisPCForm atpc = new AddThisPCForm(conn);

            atpc.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            updateDGV();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (conn == null)
                return;

            if (e.KeyCode == Keys.F5)
                updateDGV();
        }
    }
}
