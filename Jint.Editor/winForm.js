var winForms = importNamespace('System.Windows.Forms');
var winDrawing = importNamespace('System.Drawing');

function doit()
{
  print("doit");
  winForms.MessageBox.Show("Example dialog: called doit()");
}

function close()
{
  print("close");
  winForms.MessageBox.Show("Example dialog: called close()");
  frm.Close();
}

function main()
{
  frm = new winForms.Form();
  frm.Text = "Example dialog";

  var btn = new winForms.Button();
  btn.Text = "Test";
  btn.Location = new winDrawing.Point(20, 20);
  frm.Controls.Add(btn);
  btn.add_Click(doit);

  var clsbtn = new winForms.Button();
  clsbtn.Text = "Close";
  clsbtn.Location = new winDrawing.Point(20, 60);
  frm.Controls.Add(clsbtn);
  clsbtn.add_Click(close);

  frm.ShowDialog();
}

var frm;

main();