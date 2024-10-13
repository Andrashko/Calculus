public class RightBar : IQuadrature
{
    public double Calculate(Func<double, double> Function, double Start, double End, int StepsCount)
    {
        double sum = 0;
        double step = (End - Start) / StepsCount;
        for (int i = 1; i <= StepsCount; i++)
        {
            double x = Start + i * step;
            sum += Function(x);
        }
        return step * sum;
    }
}