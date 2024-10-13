abstract class NumericalIntegrationMethod
{
    protected Func<double,double> _function;
    public NumericalIntegrationMethod(Func<double, double> Function){
        _function = Function;
    }

    public abstract double Integrate(double Start, double End, double Epsilon);
}