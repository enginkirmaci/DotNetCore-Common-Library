namespace Common.Utilities.Converters
{
    public class Converter
    {
        public static DateTimeConverter DateTime = new DateTimeConverter();
        public static TrDateTimeConverter TrDateTime = new TrDateTimeConverter();
        public static IntConverter Int = new IntConverter();
        public static StringConverter String = new StringConverter();
        public static DoubleConverter Double = new DoubleConverter();
    }
}