// requires:
//   _engine = new Engine(cfg => cfg.AllowClr(typeof(System.Windows.Forms.MessageBox).Assembly));
//

var winForms = importNamespace('System.Windows.Forms');

winForms.MessageBox.Show('Hello from jint - javascript');
