using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ambiesoft
{
    public partial class MacroManager : Form
    {
        readonly Dictionary<string, string> macros_;
        public MacroManager(Dictionary<string, string> macros)
        {
            macros_ = macros;
            InitializeComponent();
			UpdateList();
        }
		public MacroManager() : this(new Dictionary<string, string>())
		{ }

		public string InputString
        {
			get { return txtInput.Text; }
            set {
				txtInput.Text = value;
				Deploy();
			}
        }
		public string ResultString
        {
			get { return txtResult.Text; }
            set { txtResult.Text = value; }
        }

		void Deploy()
		{
			try
			{
				string ret = Deploy(txtInput.Text);
				txtResult.Text = ret;
			}
			catch (Exception ex)
			{
				txtResult.Text = ex.Message;
			}
		}

		public void UpdateList()
        {
			lvMacros.Items.Clear();
			foreach( string key in macros_.Keys)
            {
				ListViewItem item = new ListViewItem();
				item.Text = key;

				ListViewItem.ListViewSubItem i2 = new ListViewItem.ListViewSubItem();
				i2.Text = macros_[key];
				item.SubItems.Add(i2);

				lvMacros.Items.Add(item);
            }
        }
		System.Char nextc(string s, int i)
		{
			if (i < 0)
				return '\0';
			if (s.Length <= (i + 1))
				return '\0';

			return s[i + 1];
		}

		private string Deploy(string input)
		{
			string ret = string.Empty;
			for (int i = 0; i < input.Length; ++i)
			{
				if (input[i] == '$')
				{
					if (nextc(input, i) == '$')
					{
						i += 1;
						ret += '$';
						continue;
					}
					else if (nextc(input, i) == '{')
					{
						// macro
						int index = input.IndexOf('}', i);
						if (index >= 0)
						{
							// found '}'
							string macro = input.Substring(i + 2, index - i - 2);
							if (macros_.ContainsKey(macro))
							{
								ret += macros_[macro];
								i = index;
								continue;
							}
							else
							{
								// macro not found
								throw new Exception(String.Format("Macro '{0}' not found",
									macro));
							}
						}
						else
						{
							// } not found
							throw new Exception(string.Format("Macro deploy error at {0}", i));
						}
					}
					else
					{
						// $ but not $ or {
						throw new Exception(string.Format("Macro deploy error at {0}", i));
					}
				}
				ret += input[i];
			}
			return ret;

		}
		public static int One() { return 1; }

        private void txtInput_Validated(object sender, EventArgs e)
        {

        }

        private void txtInput_Validating(object sender, CancelEventArgs e)
        {

        }

    

        private void lvMacros_MouseDoubleClick(object sender, MouseEventArgs e)
        {
			if (lvMacros.SelectedItems.Count == 0)
				return;
			string textToInsert = lvMacros.SelectedItems[0].Text;
			// txtInput.Text.Insert(txtInput.SelectionStart, textToInsert);
			int pos = txtInput.SelectionStart + txtInput.SelectionLength;
			string toPaste = "${" + textToInsert + "}";
			txtInput.Paste(toPaste);

			int newPos = pos + toPaste.Length;
			txtInput.Select(newPos, 0);
			
			txtInput.Focus();
        }

		public string SetMacro(string macro, string value)
        {
			string ret = macros_.ContainsKey(macro) ? macros_[macro] : null;
			macros_[macro] = value;
			UpdateList();
			return ret;
        }
		public void ClearMacros()
        {
			macros_.Clear();
			UpdateList();
        }

        private void txtInput_TextChanged(object sender, EventArgs e)
        {
			Deploy();
        }
    }
}
