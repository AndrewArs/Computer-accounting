using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Computer_accounting
{
    public partial class ConnectForm : Form
    {
        public MySqlConnection conn;
        String database = "computer_accounting";

        public ConnectForm()
        {
            InitializeComponent();

            toolTip.SetToolTip(textBoxServer, "Enter server to connect");
            toolTip.SetToolTip(textBoxPassword, "Enter your password if you have one");

            textBoxServer.Validating += TextBoxServer_Validating;
            textBoxUID.Validating += TextBoxUID_Validating;

            errorProviderServer.SetIconAlignment(textBoxServer, ErrorIconAlignment.MiddleRight);
            errorProviderUID.SetIconAlignment(textBoxUID, ErrorIconAlignment.MiddleRight);
        }

        private void TextBoxUID_Validating(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty((sender as TextBox).Text))
                errorProviderUID.SetError(textBoxUID, "Enter your username");
        }

        private void TextBoxServer_Validating(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty((sender as TextBox).Text))
                errorProviderServer.SetError(textBoxServer, "Enter server to connect");
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            String connString = String.Format(
                "SERVER={0}; UID={1}; PASSWORD={2}; DATABASE={3};Convert Zero Datetime=True;charset=utf8;",
                textBoxServer.Text, textBoxUID.Text, textBoxPassword.Text, database);

            

            conn = new MySqlConnection(connString);

            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                return;
            }

            this.DialogResult = DialogResult.OK;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
