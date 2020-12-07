namespace TEK.Core.Helpers
{
    public static class HospitalHelper
    {
        public static string BuildPatientCode(string code, string hospitalCode)
        {
            var hospitalCodeFormat = string.Format("{0}.", hospitalCode);
            var isSetPrefix = code.Contains(hospitalCodeFormat);
            if (!isSetPrefix)
            {
                code = hospitalCodeFormat + code;
            }

            return code;
        }
    }
}
