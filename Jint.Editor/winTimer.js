var winForms = importNamespace('System.Windows.Forms');

function doit()
{
    print("timer fired");
}

var timer = new winForms.Timer();
timer.add_Tick(doit);

timer.Interval = 1000;
timer.Start();
