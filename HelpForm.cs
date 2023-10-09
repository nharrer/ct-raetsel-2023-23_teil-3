using System.Diagnostics;

namespace AlienDecryptor {
    public partial class HelpForm : Form {
        public HelpForm() {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e) {
            Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            var ps = new ProcessStartInfo("https://www.heise.de/select/ct/2023/23/2325106080475356764") {
                UseShellExecute = true,
                Verb = "open"
            };
            Process.Start(ps);
        }
    }
}
