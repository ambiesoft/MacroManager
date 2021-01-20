using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ambiesoft;
using System.IO;

namespace UserMacroManager
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            var macros = new Dictionary<string, string>();
            macros.Add("directory", Path.GetDirectoryName(Application.ExecutablePath));
            macros.Add("fullpath", Application.ExecutablePath);
            macros.Add("filename", Path.GetFileName(Application.ExecutablePath));
            macros.Add("filenamewithoutext", Path.GetFileNameWithoutExtension(Application.ExecutablePath));
            macros.Add("ext", Path.GetExtension(Application.ExecutablePath));

            var mm = new MacroManager(macros);
            mm.InputString = txtInput.Text;
            if (DialogResult.OK != mm.ShowDialog())
                return;
            txtInput.Text = mm.InputString;
        }
    }
}
