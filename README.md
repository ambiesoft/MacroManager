# MacroManager
MacroManager transform macros put in the template string into a context value.

## How to use
1. Create an instance of MacroManager
```
MacroManager _mm = new MacroManager();
```
2. Set macros by SetMacro. First argument is the name of macro and second argument is its value.
```
_mm.SetMacro("directory", Path.GetDirectoryName(Application.ExecutablePath));
_mm.SetMacro("fullpath", Application.ExecutablePath);
_mm.SetMacro("filename", Path.GetFileName(Application.ExecutablePath));
_mm.SetMacro("filenamewithoutext", Path.GetFileNameWithoutExtension(Application.ExecutablePath));
```

3. Set input text
```
_mm.InputString = txtInput.Text;
```
The input text would be like **zip create "${directory}/${filenamewithoutext}.zip"**

4. Get resulted text
```
txtResult.Text = _mm.ResultString;
```

5. MacroManager can show a dialogbox to easyly edit the input text
```
private void btnDetail_Click(object sender, EventArgs e)
{
    _mm.InputString = txtInput.Text;
    if (DialogResult.OK != _mm.ShowDialog())
        return;
    txtInput.Text = _mm.InputString;
    txtResult.Text = _mm.ResultString;
}
```

