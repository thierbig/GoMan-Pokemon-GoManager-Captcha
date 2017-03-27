using System.Drawing;
using System.Windows.Forms;

namespace PokemonFeeder
{
    public static class Prompt
    {
        public static string ShowDialog(string text, string caption, string defaultValue = "")
        {
            Form prompt = new Form
            {
                Width = 500,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen
            };

            Label textLabel = new Label() { AutoSize = true, Location = new Point(13, 13), Text = text };
            TextBox textBox = new TextBox() { Location = new Point(16, 41), Size = new Size(186, 20) };
            textBox.Text = defaultValue;


            Button confirmation = new Button() { Text = "OK", DialogResult = DialogResult.OK, Size = new Size(75, 23), Location = new Point(15, 67) };
            Button cancel = new Button() { Text = "Cancel", DialogResult = DialogResult.Cancel, Size = new Size(75, 23), Location = new Point(127, 67) };

            confirmation.Click += (sender, e) => { prompt.Close(); };
            cancel.Click += (sender, e) => { prompt.Close(); };

            prompt.AcceptButton = confirmation;
            prompt.AutoScaleDimensions = new SizeF(6F, 13F);
            prompt.AutoScaleMode = AutoScaleMode.Font;
            prompt.ClientSize = new Size(214, 100);
            prompt.Text = caption;

            prompt.Controls.Add(textLabel);
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(cancel);

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : string.Empty;
        }
    }
}
