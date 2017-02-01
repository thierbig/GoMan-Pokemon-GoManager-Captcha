using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Goman_Plugin.Helpers;

namespace Goman_Plugin.Modules.Authentication
{
    internal partial class AuthenticationUi : Form
    {
        public AuthenticationUi()
        {
            InitializeComponent();
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SendMessage(IntPtr hWnd, int msg, int wParam,
            [MarshalAs(UnmanagedType.LPWStr)] string lParam);

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(AuthenticationSettings.Username))
            {
                MessageBox.Show(this, "Enter a username",
                    "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(AuthenticationSettings.Password))
            {
                MessageBox.Show(this, "Enter a password",
                    "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            pbRefresh.Visible = true;
            btnSubmit.Enabled = false;

            var methodResult = await GomanHttpHelper.Authentication.Ping();

            pbRefresh.Visible = false;
            btnSubmit.Enabled = true;

            if (methodResult.Error != null)
                MessageBox.Show(this, methodResult.Error.Message + "\n" + methodResult.Error.StackTrace,
                    "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                DialogResult = DialogResult.OK;
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            AuthenticationSettings.Username = txtUsername.Text;
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            AuthenticationSettings.Password = txtPassword.Text;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtUsername.Text = AuthenticationSettings.Username;
            txtPassword.Text = AuthenticationSettings.Password;

            SendMessage(txtUsername.Handle, 5377, 0, "username");
            SendMessage(txtPassword.Handle, 5377, 0, "password");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://goman.io/my-account/");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}