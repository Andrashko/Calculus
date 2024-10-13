Func<double, double> f = x => Math.Sin(x);
double a = 0;
double b = 2*Math.PI/3;
double e = 1e-6;
NumericalIntegrationMethod method1 = new MontecarloMethod(f);
NumericalIntegrationMethod method2 = new RungeMethod(f, new SimpsonMethod());


Console.WriteLine(method1.Integrate(a, b, e));
Console.WriteLine(method2.Integrate(a, b, e));