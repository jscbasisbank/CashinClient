namespace Basis.Service.Cashin.Common.Extensions
{
    public static class MoneyExtensions 
    {
        public static int ToTetri(this Decimal data)
        {
            return Convert.ToInt32(Math.Truncate(100 * data));
        }


        public static decimal ToLari(this Int32 data)
        {
            var debt = Convert.ToDecimal(data);

            return debt / 100;
        }
    }
}