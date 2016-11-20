using System;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace Computer_accounting
{
    public partial class AddForm : Form
    {
        MySqlConnection conn;
        int globalIndex = 0;
        Button buttonFinish = new Button();
        Button buttonPrev = new Button();
        Dictionary<String, String> queries = new Dictionary<string, string>();

        public AddForm(MySqlConnection conn)
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

            createControls();
            showControls(true);

            groupBox1.Enabled = false;
        }

        private void createControls()
        {
            buttonFinish.Location = buttonNext.Location;
            buttonFinish.Text = "Finish";
            buttonFinish.Size = buttonNext.Size;
            buttonFinish.Click += buttonFinish_Click;
            buttonFinish.Visible = false;

            buttonPrev.Location = new Point(12, buttonNext.Location.Y);
            buttonPrev.Text = "Prev";
            buttonPrev.Visible = false;
            buttonPrev.Click += buttonPrev_Click;

            Controls.AddRange(new Control[] { buttonFinish, buttonPrev });
        }

        private void buttonPrev_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            globalIndex--;
            showControls(true);
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();

            try
            {
                switch (globalIndex)
                {
                    case 0:
                        {
                            queries["cpu"] = "";
                            if (checkBoxNew.Checked)
                            {
                                queries["cpu"] = String.Format(
                                    "INSERT INTO cpus(manufacturer, model, mounting) VALUES(\"{0}\", \"{1}\", \"{2}\")",
                                    textBox1.Text, textBox2.Text, textBox3.Text);
                            }
                            else
                            {
                                queries["cpu"] = ((ComboboxItem)comboBox1.SelectedItem).ID.ToString();

                            }
                        }
                        break;
                    case 1:
                        {
                            queries["memory"] = "";
                            if (checkBoxNew.Checked)
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

                                queries["memory"] = String.Format(
                                    "INSERT INTO memory(type, model, frequency, capacity)" +
                                    " VALUES(\"{0}\", \"{1}\", {2}, {3})", textBox1.Text, textBox2.Text,
                                    result1.ToString().Replace(',', '.'), result2.ToString().Replace(',', '.'));
                            }
                            else
                            {
                                queries["memory"] = ((ComboboxItem)comboBox1.SelectedItem).ID.ToString();

                            }
                        }
                        break;
                    case 2:
                        {
                            queries["motherboard"] = "";
                            if (checkBoxNew.Checked)
                            {
                                queries["motherboard"] = String.Format(
                                    "INSERT INTO motherboards(brand, model, sockets, slots)" +
                                    " VALUES(\"{0}\", \"{1}\", \"{2}\", \"{3}\")",
                                    textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);
                            }
                            else
                            {
                                queries["motherboard"] = ((ComboboxItem)comboBox1.SelectedItem).ID.ToString();
                            }
                        }
                        break;
                    case 3:
                        {
                            queries["graphics"] = "";
                            if (checkBoxNew.Checked)
                            {
                                double result;
                                if (!double.TryParse(textBox3.Text.Replace('.', ','), out result)
                                    && !String.IsNullOrEmpty(textBox3.Text))
                                {
                                    errorProvider1.SetError(textBox3, "Must be a double");
                                    return;
                                }

                                queries["graphics"] = String.Format(
                                    "INSERT INTO graphics_cards(brand, model, memory)" +
                                    " VALUES(\"{0}\", \"{1}\", {2})",
                                    textBox1.Text, textBox2.Text, textBox3.Text.Replace(',', '.'));
                            }
                            else
                            {
                                queries["graphics"] = ((ComboboxItem)comboBox1.SelectedItem).ID.ToString();

                            }
                        }
                        break;
                    case 4:
                        {
                            queries["hard_drive"] = "";
                            if (checkBoxNew.Checked)
                            {
                                int result;
                                if (!int.TryParse(textBox3.Text, out result) && !String.IsNullOrEmpty(textBox3.Text))
                                {
                                    errorProvider1.SetError(textBox3, "Must be an int");
                                    return;
                                }

                                queries["hard_drive"] = String.Format(
                                    "INSERT INTO internal_hard_drives(brand, model, capacity)" +
                                    " VALUES(\"{0}\", \"{1}\", {2})",
                                    textBox1.Text, textBox2.Text, textBox3.Text);
                            }
                            else
                            {
                                queries["hard_drive"] = ((ComboboxItem)comboBox1.SelectedItem).ID.ToString();

                            }
                        }
                        break;
                    case 5:
                        {
                            queries["keyboard"] = "";
                            if (checkBoxNew.Checked)
                            {
                                queries["keyboard"] = String.Format(
                                    "INSERT INTO keyboards(brand, model) VALUES(\"{0}\", \"{1}\")",
                                    textBox1.Text, textBox2.Text);
                            }
                            else
                            {
                                queries["keyboard"] = ((ComboboxItem)comboBox1.SelectedItem).ID.ToString();

                            }
                        }
                        break;
                    case 6:
                        {
                            queries["monitor"] = "";
                            if (checkBoxNew.Checked)
                            {
                                double result;
                                if (!double.TryParse(textBox3.Text.Replace('.', ','), out result)
                                    && !String.IsNullOrEmpty(textBox3.Text))
                                {
                                    errorProvider1.SetError(textBox3, "Must be a double");
                                    return;
                                }

                                queries["monitor"] = String.Format(
                                    "INSERT INTO monitors(brand, model, display_size) VALUES(\"{0}\", \"{1}\", {2})",
                                    textBox1.Text, textBox2.Text, result.ToString().Replace(',', '.'));
                            }
                            else
                            {
                                queries["monitor"] = ((ComboboxItem)comboBox1.SelectedItem).ID.ToString();

                            }
                        }
                        break;
                    case 7:
                        {
                            queries["mouse"] = "";
                            if (checkBoxNew.Checked)
                            {
                                queries["mouse"] = String.Format(
                                    "INSERT INTO mouses(brand, model) VALUES(\"{0}\", \"{1}\")",
                                    textBox1.Text, textBox2.Text);
                            }
                            else
                            {
                                queries["mouse"] = ((ComboboxItem)comboBox1.SelectedItem).ID.ToString();

                            }
                            showControls(false);
                            return;
                        }
                    default: return;
                }
            }
            catch (NullReferenceException)
            {
                return;
            }

            globalIndex++;
            showControls(true);
        }

        private void buttonFinish_Click(object sender, EventArgs e)
        {
            buttonNext_Click(null, null);
            long[] indexes = new long[8];
            int i = 0;

            foreach (KeyValuePair<String, String> pair in queries)
            {
                int result;
                if (!int.TryParse(pair.Value, out result))
                {
                    try
                    {
                        MySqlCommand cmd1 = new MySqlCommand(pair.Value, conn);
                        cmd1.ExecuteNonQuery();
                        indexes[i] = cmd1.LastInsertedId;
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error");
                        globalIndex = i;
                        showControls(true);
                    }
                }
                else indexes[i] = result;
                i++;
            }

            MySqlCommand cmd;
            try
            {
                cmd = new MySqlCommand(
                    String.Format("INSERT INTO computers(id, cpu_id, memory_id, motherboard_id, graphics_id," +
                    " hard_drive_id, keyboard_id, monitor_id, mouse_id) VALUES " +
                    "(\"{0}\", {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8})",
                    textBoxID.Text, indexes[0], indexes[1], indexes[2], indexes[3],
                    indexes[4], indexes[7], indexes[5], indexes[6]), conn);
                cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }

            String today = String.Format("{0:yyyy-MM-dd}", DateTime.Today);

            cmd = new MySqlCommand(
                String.Format("INSERT INTO computers_log(computer_id, cpu_id, memory_id, motherboard_id, graphics_id," +
                " hard_drive_id, keyboard_id, monitor_id, mouse_id, date, operation) VALUES " +
                "(\"{0}\", {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, \"{9}\", \"add\")",
                textBoxID.Text, indexes[0], indexes[1], indexes[2], indexes[3],
                indexes[4], indexes[7], indexes[5], indexes[6], today), conn);
            cmd.ExecuteNonQuery();

            this.DialogResult = DialogResult.OK;
        }

        private void checkBoxNew_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxNew.Checked == true)
                groupBox1.Enabled = true;
            else groupBox1.Enabled = false;
        }

        private void showControls(bool erase)
        {
            if (erase)
            {
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
            }

            if (globalIndex >= 1)
                buttonPrev.Visible = true;
            else buttonPrev.Visible = false;

            if (globalIndex == 7)
            {
                buttonFinish.Visible = true;
                buttonNext.Visible = false;
            }
            else
            {
                buttonFinish.Visible = false;
                buttonNext.Visible = true;
            }

            comboBox1.Items.Clear();

            switch (globalIndex)
            {
                case 0:
                    {
                        MySqlCommand cmd = new MySqlCommand(
                            "SELECT cpus.id, cpus.manufacturer, cpus.model FROM cpus", conn);

                        using (MySqlDataReader dr = cmd.ExecuteReader())
                        {
                            while(dr.Read())
                            {
                                comboBox1.Items.Add(new ComboboxItem(dr.GetInt32(0),
                                    dr.GetString(1) + " " + dr.GetString(2)));  
                            }
                        }

                        labelStep.Text = "CPU";
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
                        MySqlCommand cmd = new MySqlCommand(
                            "SELECT memory.id, memory.type, memory.model FROM memory", conn);

                        using (MySqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                comboBox1.Items.Add(new ComboboxItem(dr.GetInt32(0),
                                    dr.GetString(1) + " " + dr.GetString(2)));
                            }
                        }

                        labelStep.Text = "Memory";
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
                        MySqlCommand cmd = new MySqlCommand(
                            "SELECT motherboards.id, motherboards.brand, motherboards.model FROM motherboards", conn);

                        using (MySqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                comboBox1.Items.Add(new ComboboxItem(dr.GetInt32(0),
                                    dr.GetString(1) + " " + dr.GetString(2)));
                            }
                        }

                        labelStep.Text = "Motherboard";
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
                        MySqlCommand cmd = new MySqlCommand(
                            "SELECT graphics_cards.id, graphics_cards.brand, graphics_cards.model FROM graphics_cards",
                            conn);

                        using (MySqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                comboBox1.Items.Add(new ComboboxItem(dr.GetInt32(0),
                                    dr.GetString(1) + " " + dr.GetString(2)));
                            }
                        }

                        labelStep.Text = "Graphics card";
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
                        MySqlCommand cmd = new MySqlCommand(
                            "SELECT internal_hard_drives.id, internal_hard_drives.brand, internal_hard_drives.model" + 
                            " FROM internal_hard_drives",
                            conn);

                        using (MySqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                comboBox1.Items.Add(new ComboboxItem(dr.GetInt32(0),
                                    dr.GetString(1) + " " + dr.GetString(2)));
                            }
                        }

                        labelStep.Text = "Hard drive";
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
                        MySqlCommand cmd = new MySqlCommand(
                            "SELECT keyboards.id, keyboards.brand, keyboards.model FROM keyboards", conn);

                        using (MySqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                comboBox1.Items.Add(new ComboboxItem(dr.GetInt32(0),
                                    dr.GetString(1) + " " + dr.GetString(2)));
                            }
                        }

                        labelStep.Text = "Keyboard";
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
                        MySqlCommand cmd = new MySqlCommand(
                            "SELECT monitors.id, monitors.brand, monitors.model FROM monitors", conn);

                        using (MySqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                comboBox1.Items.Add(new ComboboxItem(dr.GetInt32(0),
                                    dr.GetString(1) + " " + dr.GetString(2)));
                            }
                        }

                        labelStep.Text = "Monitor";
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
                        MySqlCommand cmd = new MySqlCommand(
                            "SELECT mouses.id, mouses.brand, mouses.model FROM mouses", conn);

                        using (MySqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                comboBox1.Items.Add(new ComboboxItem(dr.GetInt32(0),
                                    dr.GetString(1) + " " + dr.GetString(2)));
                            }
                        }

                        labelStep.Text = "Mouse";
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
