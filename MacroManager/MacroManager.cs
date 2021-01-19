using System;
using System.Collections.Generic;
using System.Text;

namespace Ambiesoft
{
    public class MacroManager
    {
        readonly Dictionary<string,string> macros_;
        public MacroManager(Dictionary<string, string> macros)
        {
            macros_ = macros;
        }

		System.Char nextc(string s, int i)
		{
			if (i < 0)
				return '\0';
			if (s.Length <= (i + 1))
				return '\0';

			return s[i + 1];
		}

		public string Deploy(string input)
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
							if(macros_.ContainsKey(macro))
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
    }
}
