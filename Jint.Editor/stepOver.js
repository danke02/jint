
//test step over debug
function fn1()
{
  fn2();  
  print("fn1");
  print("fn1");
  print("fn1");
  print("fn1");
  abc = 3451;
  print("fn1");

  return;
}

function fn2()
{
  fn3();  
  print("fn2");
  print("fn2");
  abc = 3452;
  print("fn2");
  print("fn2");
  print("fn2");
  

  return;
}

function fn3()
{
  print("fn3");
  print("fn3");
  print("fn3");
  abc = 3453;
  print("fn3");
  print("fn3");
  return;
}

var abc = 123;

fn1();

print("done");