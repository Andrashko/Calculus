public class SimpsonMethod : IQuadrature
{
    public double Calculate(Func<double, double> Function, double Start, double End, int StepsCount)
    {
        StepsCount *= 2;
        double sum = Function(Start) + Function(End);
        double step = (End - Start) / StepsCount;
        for (int i = 1; i < StepsCount; i++)
        {
            double x = Start + i * step;
            if (i % 2 == 0)
            {
                sum += 2 * Function(x);
            }
            else
            {
                sum += 4 * Function(x);
            }
        }
        return step / 3 * sum;
    }
}