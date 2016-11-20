using System;
using System.Collections.Generic;
using System.Management;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;

namespace Computer_accounting
{
    public partial class AddThisPCForm : Form
    {
        MySqlConnection conn;
        Dictionary<String, String> queries = new Dictionary<string, string>();

        public AddThisPCForm(MySqlConnection conn)
        {
            InitializeComponent();

            this.conn = conn;

            queries.Add("cpu", "");
            queries.Add("memory", "");
            queries.Add("motherboard", "");
            queries.Add("graphics", "");
            queries.Add("hard_drive", "");
            queries.Add("monitor", "");
            queries.Add("mouse", "");
            queries.Add("keyboard", "");

            Info();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text))
            {
                errorProvider1.SetError(textBox1, "Enter computer id");
                return;
            }

            long[] indexes = new long[8];
            int i = 0;

            foreach (KeyValuePair<String, String> pair in queries)
            {
                try
                {
                    MySqlCommand cmd1 = new MySqlCommand(pair.Value, conn);
                    cmd1.ExecuteNonQuery();
                    indexes[i] = cmd1.LastInsertedId;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
                i++;
            }

            MySqlCommand cmd;
            try
            {
                cmd = new MySqlCommand(
                    String.Format("INSERT INTO computers(id, cpu_id, memory_id, motherboard_id, graphics_id," +
                    " hard_drive_id, keyboard_id, monitor_id, mouse_id) VALUES " +
                    "(\"{0}\", {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8})",
                    textBox1.Text, indexes[0], indexes[1], indexes[2], indexes[3],
                    indexes[4], indexes[7], indexes[5], indexes[6]), conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                this.Close();
            }

            String today = String.Format("{0:yyyy-MM-dd}", DateTime.Today);

            cmd = new MySqlCommand(
                String.Format("INSERT INTO computers_log(computer_id, cpu_id, memory_id, motherboard_id, graphics_id," +
                " hard_drive_id, keyboard_id, monitor_id, mouse_id, date, operation) VALUES " +
                "(\"{0}\", {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, \"{9}\", \"add\")",
                textBox1.Text, indexes[0], indexes[1], indexes[2], indexes[3],
                indexes[4], indexes[7], indexes[5], indexes[6], today), conn);
            cmd.ExecuteNonQuery();

            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Info()
        {
            //----------------------------CPU
            infoLabel.Text += "CPU: ";

            ManagementObjectSearcher searcher =
                new ManagementObjectSearcher("SELECT SocketDesignation, Name, Manufacturer FROM Win32_Processor");

            foreach (ManagementObject o in searcher.Get())
            {
                infoLabel.Text += o["Manufacturer"] + "--" + o["Name"] + "--" + o["SocketDesignation"];

                queries["cpu"] = String.Format(
                                    "INSERT INTO cpus(manufacturer, model, mounting) VALUES(\"{0}\", \"{1}\", \"{2}\")",
                                    o["Manufacturer"], o["Name"], o["SocketDesignation"]);
            }

            //----------------------------memory
            infoLabel.Text += "\nMemory: ";
            searcher =
                new ManagementObjectSearcher("SELECT MemoryType, Capacity, Model, Speed FROM Win32_PhysicalMemory");

            foreach (ManagementObject o in searcher.Get())
            {
                infoLabel.Text += o["Model"] + "--" + o["Speed"] + "MGz--" + o["Capacity"] + " bytes";
                long capacity = Int64.Parse(o["Capacity"].ToString()) / 1000000000;
                queries["memory"] = String.Format(
                                    "INSERT INTO memory(model, frequency, capacity)" +
                                    " VALUES(\"{0}\", {1}, {2})", o["Model"], o["Speed"], capacity);
            }

            //----------------------------motherboard
            infoLabel.Text += "\nMotherboard: ";
            searcher =
                new ManagementObjectSearcher("SELECT Manufacturer, Model, Product, SlotLayout FROM Win32_BaseBoard");

            foreach (ManagementObject o in searcher.Get())
            {
                infoLabel.Text += o["Manufacturer"] + "--" + o["Product"] + "--" + o["SlotLayout"];

                queries["motherboard"] = String.Format(
                                    "INSERT INTO motherboards(brand, model, slots)" +
                                    " VALUES(\"{0}\", \"{1}\", \"{2}\")",
                                    o["Manufacturer"], o["Product"], o["SlotLayout"]);
            }

            //----------------------------Video controller
            infoLabel.Text += "\nGPU: ";
            searcher = new ManagementObjectSearcher(
                "SELECT Name, AdapterRAM FROM Win32_VideoController");

            foreach (ManagementObject o in searcher.Get())
            {
                infoLabel.Text += o["Name"] + "--" + o["AdapterRAM"] + " bytes";

                double memory = Int64.Parse(o["AdapterRAM"].ToString()) / 1000000000;

                queries["graphics"] = String.Format(
                                    "INSERT INTO graphics_cards(model, memory)" +
                                    " VALUES(\"{0}\", {1})",
                                    o["Name"], memory);
            }

            //----------------------------Disk Drive
            infoLabel.Text += "\nHard drive: ";
            searcher =
                new ManagementObjectSearcher("SELECT Manufacturer, Model, Size FROM Win32_DiskDrive");

            foreach (ManagementObject o in searcher.Get())
            {
                infoLabel.Text += o["Manufacturer"] + "--" + o["Model"] + "--" + o["Size"] + " bytes";

                long size = Int64.Parse(o["Size"].ToString()) / 1000000000;

                queries["hard_drive"] = String.Format(
                                    "INSERT INTO internal_hard_drives(model, capacity)" +
                                    " VALUES(\"{0}\", {1})", o["Model"], size);
            }

            //----------------------------mouse
            infoLabel.Text += "\nPointing devices: ";
            searcher =
                new ManagementObjectSearcher("SELECT Manufacturer, Name FROM Win32_PointingDevice");

            foreach (ManagementObject o in searcher.Get())
            {
                infoLabel.Text += o["Manufacturer"] + "--" + o["Name"] + "\n";

                queries["mouse"] = String.Format(
                                    "INSERT INTO mouses(brand, model) VALUES(\"{0}\", \"{1}\")",
                                    o["Manufacturer"], o["Name"]);
            }

            //----------------------------Monitor
            infoLabel.Text += "Monitor: ";
            searcher =
                new ManagementObjectSearcher("SELECT * FROM Win32_DesktopMonitor");

            foreach (ManagementObject o in searcher.Get())
            {
                infoLabel.Text += o["MonitorManufacturer"] + "--" + o["Name"];

                queries["monitor"] = String.Format(
                                    "INSERT INTO monitors(model) VALUES(\"{0}\")",
                                    o["Name"]);
            }

            //----------------------------Keyboard
            infoLabel.Text += "\nKeyboard: ";
            searcher =
                new ManagementObjectSearcher("SELECT * FROM Win32_Keyboard");

            foreach (ManagementObject o in searcher.Get())
            {
                infoLabel.Text += o["Name"];

                queries["keyboard"] = String.Format(
                                    "INSERT INTO keyboards(model) VALUES(\"{0}\")", o["Name"]);
            }

            DriveInfo di = new DriveInfo("C");

            infoLabel.Text += "\n\nDisk C available free space / total space ";

            infoLabel.Text += di.AvailableFreeSpace + "/" + di.TotalSize + " bytes";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            infoLabel.Text = String.Empty;

            Info();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                timer1.Start();
            else timer1.Stop();
        }
    }
}
