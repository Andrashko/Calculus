interface IQuadrature
{
    double Calculate(Func<double, double> Function, double Start, double End, int StepsCount);
}