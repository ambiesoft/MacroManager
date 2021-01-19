using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserMacroManager
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            _ = Ambiesoft.MacroManager.One();
        }
    }
}
