using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Computer_accounting
{
    public partial class UpdateForm : Form
    {
        MySqlConnection conn;
        Computer computer;

        public UpdateForm(Computer computer, MySqlConnection conn)
        {
            InitializeComponent();

            this.computer = computer;
            this.conn = conn;

            comboBox1.SelectedIndex = 0;

            showControls();
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            try
            {
                switch (comboBox1.SelectedIndex)
                {
                    case 0:
                        {
                            MySqlCommand cmd = new MySqlCommand(String.Format(
                                        "INSERT INTO cpus(manufacturer, model, mounting) VALUES(\"{0}\", \"{1}\", \"{2}\")",
                                        textBox1.Text, textBox2.Text, textBox3.Text), conn);
                            cmd.ExecuteNonQuery();

                            long id = cmd.LastInsertedId;

                            computer.cpu_id = (int)id;
                            cmd = new MySqlCommand(String.Format(
                                "UPDATE computers SET cpu_id={0} WHERE id=\"{1}\"",
                                id, computer.id), conn);
                            cmd.ExecuteNonQuery();
                        }
                        break;
                    case 1:
                        {
                            double result1;
                            double result2;
                            if (!double.TryParse(textBox3.Text.Replace('.', ','), out result1)
                                && !String.IsNullOrEmpty(textBox3.Text))
                            {
                                errorProvider1.SetError(textBox3, "Must be a double");
                                return;
                            }
                            if (!double.TryParse(textBox4.Text.Replace('.', ','), out result2)
                                && !String.IsNullOrEmpty(textBox4.Text))
                            {
                                errorProvider1.SetError(textBox4, "Must be a double");
                                return;
                            }

                            MySqlCommand cmd = new MySqlCommand(String.Format(
                                "INSERT INTO memory(type, model, frequency, capacity)" +
                                " VALUES(\"{0}\", \"{1}\", {2}, {3})", textBox1.Text, textBox2.Text,
                                result1.ToString().Replace(',', '.'), result2.ToString().Replace(',', '.')), conn);
                            cmd.ExecuteNonQuery();

                            long id = cmd.LastInsertedId;

                            computer.memory_id = (int)id;
                            cmd = new MySqlCommand(String.Format(
                                "UPDATE computers SET memory_id={0} WHERE id=\"{1}\"",
                                id, computer.id), conn);
                            cmd.ExecuteNonQuery();
                        }
                        break;
                    case 2:
                        {
                            MySqlCommand cmd = new MySqlCommand(String.Format(
                                        "INSERT INTO motherboards(brand, model, sockets, slots)" +
                                        " VALUES(\"{0}\", \"{1}\", \"{2}\", \"{3}\")",
                                        textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text), conn);
                            cmd.ExecuteNonQuery();

                            long id = cmd.LastInsertedId;

                            computer.motherboard_id = (int)id;
                            cmd = new MySqlCommand(String.Format(
                                "UPDATE computers SET motherboard_id={0} WHERE id=\"{1}\"",
                                id, computer.id), conn);
                            cmd.ExecuteNonQuery();
                        }
                        break;
                    case 3:
                        {
                            double result;
                            if (!double.TryParse(textBox3.Text.Replace('.', ','), out result) 
                                && !String.IsNullOrEmpty(textBox3.Text))
                            {
                                errorProvider1.SetError(textBox3, "Must be a double");
                                return;
                            }

                            MySqlCommand cmd = new MySqlCommand(String.Format(
                                "INSERT INTO graphics_cards(brand, model, memory)" +
                                " VALUES(\"{0}\", \"{1}\", {2})",
                                textBox1.Text, textBox2.Text, textBox3.Text.Replace(',', '.')), conn);
                            cmd.ExecuteNonQuery();

                            long id = cmd.LastInsertedId;

                            computer.graphics_id = (int)id;
                            cmd = new MySqlCommand(String.Format(
                                "UPDATE computers SET graphics_id={0} WHERE id=\"{1}\"",
                                id, computer.id), conn);
                            cmd.ExecuteNonQuery();
                        }
                        break;
                    case 4:
                        {
                            int result;
                            if (!int.TryParse(textBox3.Text, out result) && !String.IsNullOrEmpty(textBox3.Text))
                            {
                                errorProvider1.SetError(textBox3, "Must be an int");
                                return;
                            }

                            MySqlCommand cmd = new MySqlCommand(String.Format(
                                "INSERT INTO internal_hard_drives(brand, model, capacity)" +
                                " VALUES(\"{0}\", \"{1}\", {2})",
                                textBox1.Text, textBox2.Text, textBox3.Text), conn);
                            cmd.ExecuteNonQuery();

                            long id = cmd.LastInsertedId;

                            computer.hard_drive_id = (int)id;
                            cmd = new MySqlCommand(String.Format(
                                "UPDATE computers SET hard_drive_id={0} WHERE id=\"{1}\"",
                                id, computer.id), conn);
                            cmd.ExecuteNonQuery();
                        }
                        break;
                    case 5:
                        {
                            MySqlCommand cmd = new MySqlCommand(String.Format(
                                        "INSERT INTO keyboards(brand, model) VALUES(\"{0}\", \"{1}\")",
                                        textBox1.Text, textBox2.Text), conn);
                            cmd.ExecuteNonQuery();

                            long id = cmd.LastInsertedId;

                            computer.keyboard_id = (int)id;
                            cmd = new MySqlCommand(String.Format(
                                "UPDATE computers SET keyboard_id={0} WHERE id=\"{1}\"",
                                id, computer.id), conn);
                            cmd.ExecuteNonQuery();
                        }
                        break;
                    case 6:
                        {
                            double result;
                            if (!double.TryParse(textBox3.Text.Replace('.', ','), out result)
                                && !String.IsNullOrEmpty(textBox3.Text))
                            {
                                errorProvider1.SetError(textBox3, "Must be a double");
                                return;
                            }

                            MySqlCommand cmd = new MySqlCommand(String.Format(
                                "INSERT INTO monitors(brand, model, display_size) VALUES(\"{0}\", \"{1}\", {2})",
                                textBox1.Text, textBox2.Text, result.ToString().Replace(',', '.')), conn);
                            cmd.ExecuteNonQuery();

                            long id = cmd.LastInsertedId;

                            computer.monitor_id = (int)id;
                            cmd = new MySqlCommand(String.Format(
                                "UPDATE computers SET monitor_id={0} WHERE id=\"{1}\"",
                                id, computer.id), conn);
                            cmd.ExecuteNonQuery();
                        }
                        break;
                    case 7:
                        {
                            MySqlCommand cmd = new MySqlCommand(String.Format(
                                        "INSERT INTO mouses(brand, model) VALUES(\"{0}\", \"{1}\")",
                                        textBox1.Text, textBox2.Text), conn);
                            cmd.ExecuteNonQuery();

                            long id = cmd.LastInsertedId;

                            computer.mouse_id = (int)id;
                            cmd = new MySqlCommand(String.Format(
                                "UPDATE computers SET mouse_id={0} WHERE id=\"{1}\"",
                                id, computer.id), conn);
                            cmd.ExecuteNonQuery();
                        }
                        break;

                    default: return;
                }
            }
            catch(MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message, "Error");
                return;
            }

            String today = String.Format("{0:yyyy-MM-dd}", DateTime.Today);

            MySqlCommand logcmd = new MySqlCommand(
                String.Format("INSERT INTO computers_log(computer_id, cpu_id, memory_id, motherboard_id, graphics_id," +
                " hard_drive_id, keyboard_id, monitor_id, mouse_id, date, operation) VALUES " +
                "(\"{0}\", {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, \"{9}\", \"update\")",
                computer.id, computer.cpu_id, computer.memory_id, computer.motherboard_id, computer.graphics_id,
                computer.hard_drive_id, computer.keyboard_id, computer.monitor_id, computer.mouse_id, today), conn);
            logcmd.ExecuteNonQuery();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            showControls();
        }

        private void showControls()
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    {
                        MySqlCommand cmd = new MySqlCommand(String.Format(
                            "SELECT cpus.manufacturer, cpus.model, cpus.mounting FROM cpus WHERE id={0}", 
                            computer.cpu_id), conn);

                        using (MySqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                textBox1.Text = dr.GetValue(0).ToString();
                                textBox2.Text = dr.GetValue(1).ToString();
                                textBox3.Text = dr.GetValue(2).ToString();
                            }
                        }

                        label1.Text = "Manufacturer";
                        label2.Text = "Model";
                        label3.Text = "Mounting";
                        label3.Visible = true;
                        textBox3.Visible = true;
                        label4.Visible = false;
                        textBox4.Visible = false;
                    }
                    break;
                case 1:
                    {
                        MySqlCommand cmd = new MySqlCommand(String.Format(
                            "SELECT memory.type, memory.model, memory.frequency, memory.capacity " +
                            "FROM memory WHERE id={0}" ,computer.memory_id), conn);

                        using (MySqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                textBox1.Text = dr.GetValue(0).ToString();
                                textBox2.Text = dr.GetValue(1).ToString();
                                textBox3.Text = dr.GetValue(2).ToString();
                                textBox4.Text = dr.GetValue(3).ToString();
                            }
                        }

                        label1.Text = "Type";
                        label2.Text = "Model";
                        label3.Text = "Frequency";
                        label4.Text = "Capacity, Gb";
                        label3.Visible = true;
                        textBox3.Visible = true;
                        label4.Visible = true;
                        textBox4.Visible = true;
                    }
                    break;
                case 2:
                    {
                        MySqlCommand cmd = new MySqlCommand(String.Format(
                            "SELECT brand, model, sockets, slots FROM motherboards WHERE id={0}",
                            computer.motherboard_id), conn);

                        using (MySqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                textBox1.Text = dr.GetValue(0).ToString();
                                textBox2.Text = dr.GetValue(1).ToString();
                                textBox3.Text = dr.GetValue(2).ToString();
                                textBox4.Text = dr.GetValue(3).ToString();
                            }
                        }

                        label1.Text = "Brand";
                        label2.Text = "Model";
                        label3.Text = "Sokets";
                        label4.Text = "Slots";
                        label3.Visible = true;
                        textBox3.Visible = true;
                        label4.Visible = true;
                        textBox4.Visible = true;
                    }
                    break;
                case 3:
                    {
                        MySqlCommand cmd = new MySqlCommand(String.Format(
                            "SELECT brand, model, memory FROM graphics_cards WHERE id={0}",
                            computer.graphics_id),conn);

                        using (MySqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                textBox1.Text = dr.GetValue(0).ToString();
                                textBox2.Text = dr.GetValue(1).ToString();
                                textBox3.Text = dr.GetValue(2).ToString();
                            }
                        }

                        label1.Text = "Brand";
                        label2.Text = "Model";
                        label3.Text = "Memory, Gb";
                        label3.Visible = true;
                        textBox3.Visible = true;
                        label4.Visible = false;
                        textBox4.Visible = false;
                    }
                    break;
                case 4:
                    {
                        MySqlCommand cmd = new MySqlCommand(String.Format(
                            "SELECT brand, model, capacity FROM internal_hard_drives WHERE id={0}",
                            computer.hard_drive_id), conn);

                        using (MySqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                textBox1.Text = dr.GetValue(0).ToString();
                                textBox2.Text = dr.GetValue(1).ToString();
                                textBox3.Text = dr.GetValue(2).ToString();
                            }
                        }

                        label1.Text = "Brand";
                        label2.Text = "Model";
                        label3.Text = "Capacity, Gb";
                        label3.Visible = true;
                        textBox3.Visible = true;
                        label4.Visible = false;
                        textBox4.Visible = false;
                    }
                    break;
                case 5:
                    {
                        MySqlCommand cmd = new MySqlCommand(String.Format(
                            "SELECT brand, model FROM keyboards WHERE id={0}", computer.keyboard_id), conn);

                        using (MySqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                textBox1.Text = dr.GetValue(0).ToString();
                                textBox2.Text = dr.GetValue(1).ToString();
                            }
                        }

                        label1.Text = "Brand";
                        label2.Text = "Model";
                        label3.Visible = false;
                        label4.Visible = false;
                        textBox3.Visible = false;
                        textBox4.Visible = false;
                    }
                    break;
                case 6:
                    {
                        MySqlCommand cmd = new MySqlCommand(String.Format(
                            "SELECT brand, model, display_size FROM monitors WHERE id={0}", computer.monitor_id), conn);

                        using (MySqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                textBox1.Text = dr.GetValue(0).ToString();
                                textBox2.Text = dr.GetValue(1).ToString();
                                textBox3.Text = dr.GetValue(2).ToString();
                            }
                        }

                        label1.Text = "Brand";
                        label2.Text = "Model";
                        label3.Text = "Display size, \"";
                        label3.Visible = true;
                        textBox3.Visible = true;
                        label4.Visible = false;
                        textBox4.Visible = false;
                    }
                    break;
                case 7:
                    {
                        MySqlCommand cmd = new MySqlCommand(String.Format(
                            "SELECT brand, model FROM mouses WHERE id={0}", computer.mouse_id), conn);

                        using (MySqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                textBox1.Text = dr.GetValue(0).ToString();
                                textBox2.Text = dr.GetValue(1).ToString();
                            }
                        }

                        label1.Text = "Brand";
                        label2.Text = "Model";
                        label3.Visible = false;
                        label4.Visible = false;
                        textBox3.Visible = false;
                        textBox4.Visible = false;
                    }
                    break;

                default: return;
            }
        }
    }
}
