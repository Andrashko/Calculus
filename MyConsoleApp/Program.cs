Func<double, double> f = x => Math.Sin(x);
double a = 0;
double b = 2 * Math.PI / 3;
double e = 1e-6;


IQuadrature quadrature = null;
Console.WriteLine("Виберіть метод інтегрування: \n 1 - Лівих прямокутників \n 2 - Правих прямокутникі \n 3 - Сімпсона");
int choise = int.Parse(Console.ReadLine());
switch (choise)
{
    case 1:
        quadrature = new LeftBar();
        break;
    case 2:
        quadrature = new RightBar();
        break;
    case 3:
        quadrature = new SimpsonMethod();
        break;
}

NumericalIntegrationMethod method1 = new MontecarloMethod(f);
NumericalIntegrationMethod method2 = new RungeMethod(f, quadrature);
Console.WriteLine($"Інтеграл функції sin(x) методом Монте Карло на  [{a};{b}] з точністю { Math.Sqrt(e)} рівний {method1.Integrate(a, b, e)}");
Console.WriteLine($"Інтеграл функції sin(x) Методом Рунге на  [{a};{b}] з точністю {e} рівний {method2.Integrate(a, b, e)}");