
// requires:
//   _engine = new Engine(cfg => cfg.AllowClr(typeof(System.Windows.Forms.MessageBox).Assembly));
//

// the following does not work because can not access enums
var winForms = importNamespace('System.Windows.Forms');

var message = "Hello from jint, press Yes to print a message";
var caption = "Jint Message Box";
var buttons = winForms.MessageBoxButtons.YesNo;

// Displays the MessageBox.

var result = winForms.MessageBox.Show(message, caption, buttons);

if(result == winForms.DialogResult.Yes)
{
  print("pressed Yes");
}

// the following works
//var winForms = importNamespace('System.Windows.Forms');

//winForms.MessageBox.Show('Hello from jint - javascript');
