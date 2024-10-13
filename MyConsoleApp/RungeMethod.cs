class RungeMethod : NumericalIntegrationMethod
{
    public IQuadrature QuadratureMethod { get; set; }
    public RungeMethod(Func<double, double> Function, IQuadrature QuadratureMethod) : base(Function)
    {
        this.QuadratureMethod = QuadratureMethod;
    }

    public override double Integrate(double Start, double End, double Epsilon)
    {
        double previousValue;
        double currentValue = double.PositiveInfinity;
        int stepCount = 1;
        do
        {
            previousValue = currentValue;
            currentValue = QuadratureMethod.Calculate(_function, Start, End, stepCount);
            stepCount *= 2;
        } while (Math.Abs(previousValue - currentValue) > Epsilon);
        return currentValue;
    }
}