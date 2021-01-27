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
        readonly MacroManager _mm;
        public FormMain()
        {
            InitializeComponent();

            var macros = new Dictionary<string, string>();
            macros.Add("directory", Path.GetDirectoryName(Application.ExecutablePath));
            macros.Add("fullpath", Application.ExecutablePath);
            macros.Add("filename", Path.GetFileName(Application.ExecutablePath));
            macros.Add("filenamewithoutext", Path.GetFileNameWithoutExtension(Application.ExecutablePath));
            macros.Add("ext", Path.GetExtension(Application.ExecutablePath));

            _mm = new MacroManager(macros);
            _mm.InputString = txtInput.Text;
            txtResult.Text = _mm.ResultString;
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {

            _mm.InputString = txtInput.Text;
            if (DialogResult.OK != _mm.ShowDialog())
                return;
            txtInput.Text = _mm.InputString;
            txtResult.Text = _mm.ResultString;
        }

        private void txtInput_TextChanged(object sender, EventArgs e)
        {
            _mm.InputString = txtInput.Text;
            txtResult.Text = _mm.ResultString;
        }
    }
}
