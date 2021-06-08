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
        readonly MacroManager _mm = new MacroManager();
        public FormMain()
        {
            InitializeComponent();

            _mm.SetMacro("directory", Path.GetDirectoryName(Application.ExecutablePath));
            _mm.SetMacro("fullpath", Application.ExecutablePath);
            _mm.SetMacro("filename", Path.GetFileName(Application.ExecutablePath));
            _mm.SetMacro("filenamewithoutext", Path.GetFileNameWithoutExtension(Application.ExecutablePath));
            _mm.SetMacro("ext", Path.GetExtension(Application.ExecutablePath));

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
