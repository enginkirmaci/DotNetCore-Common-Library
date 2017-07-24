namespace Common.Utilities.Converters
{
    public class DoubleConverter
    {
        public string ToString(double? value)
        {
            if (value.HasValue)
                return value.Value.ToString("0.##");

            return "0";
        }
    }
}