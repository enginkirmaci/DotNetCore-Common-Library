namespace Common.Entities.Constants
{
    public class RegularExp
    {
        public const string EMAILMASK = @"(?<=[\w]{1})[\w-\._\+%]*(?=[\w]{1}@)";
        public const string FIRSTLASTNAMEMATCH = @"^(?<first>\w+)(?: (?<middle>\w+))? (?<last>\w+)$";

        #region Validators

        public const string CELLPHONE = @"^05([0-9]{9})";
        public const string PHONE = @"^0([0-9]{10})";
        public const string HOUR = @"^([0-9]|0[0-9]|1[0-9]|2[0-3]):[0-5][0-9]$";

        #endregion Validators
    }
}