using System;

namespace Common.Utilities.Converters
{
    public class IntConverter
    {
        public DateTime ToDateTime(int epochSeconds, bool useAsUTC = false)
        {
            if (useAsUTC)
            {
                //Piece of shit coding
                return new DateTime(1970, 1, 1).AddSeconds(epochSeconds);
            }
            return new DateTime(1970, 1, 1).AddSeconds(epochSeconds).ToLocalTime();
        }

        static public string ToStorageSize(long Bytes)
        {
            string filesize;
            if (Bytes >= 1073741824)
            {
                decimal size = decimal.Divide(Bytes, 1073741824);
                filesize = string.Format("{0:##.##} GB", size);
            }
            else if (Bytes >= 1048576)
            {
                decimal size = decimal.Divide(Bytes, 1048576);
                filesize = string.Format("{0:##.##} MB", size);
            }
            else if (Bytes >= 1024)
            {
                decimal size = decimal.Divide(Bytes, 1024);
                filesize = string.Format("{0:##.##} KB", size);
            }
            else if (Bytes > 0 & Bytes < 1024)
            {
                decimal size = Bytes;
                filesize = string.Format("{0:##.##} Bytes", size);
            }
            else
            {
                filesize = "0 Bytes";
            }
            return filesize;
        }
    }
}