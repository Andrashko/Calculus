
class MontecarloMethod : NumericalIntegrationMethod
{
    public MontecarloMethod(Func<double, double> Function) : base(Function) { }

    private Random _random = new Random();

    private double RandomRange(double min, double max)
    {
        return min + (max - min) * _random.NextDouble();
    }
    public override double Integrate(double Start, double End, double Epsilon)
    {
        double minValue = Math.Min(_function(Start), _function(End));
        double maxValue = Math.Max(_function(Start), _function(End));
        int count = (int)Math.Ceiling(1 / Epsilon);
        int countPositive = 0;
        int countNegative = 0;
        int countPositiveIn = 0;
        int countNegativeIn = 0;
        for (int i = 0; i < count; i++)
        {
            double x = RandomRange(Start, End);
            double y = RandomRange(minValue, maxValue);
            double value = _function(x);
            if (y >= 0)
            {
                countPositive++;
                if (y <= value)
                    countPositiveIn++;
            }
            else
            {
                countNegative++;
                if (y >= value)
                {
                    countNegativeIn++;
                }
            }
            if (value > maxValue)
                maxValue = value;
            if (value < minValue)
                minValue = value;
        }

        double positiveSquare = (End - Start) * maxValue;
        double negativeSquare = (End - Start) * minValue;
        if (minValue >= 0)
        {
            positiveSquare = (End - Start) * (maxValue - minValue);
            return positiveSquare * countPositiveIn / countPositive;
        }
        if (maxValue <= 0)
        {
            negativeSquare = (End - Start) * (maxValue - minValue);
            return negativeSquare * countNegativeIn / countNegative;
        }

        return positiveSquare * countPositiveIn / countPositive + negativeSquare * countNegativeIn / countNegative;
    }
}