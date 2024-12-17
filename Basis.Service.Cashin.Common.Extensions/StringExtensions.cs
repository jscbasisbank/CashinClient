using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Basis.Service.Cashin.Common.Extensions
{
    public static class StringExtensions
    {
        private const string AutoGeneratePrefix = "VTB";


        private static String GeorgianAlphabet = @"ÀÁÂÃÄÅÆÈÉÊËÌÍÏÐÑÒÓÔÖ×ØÙÚÛÜÝÞßàáãä";
        private static String EnglishAlphabet = @"abgdevzTiklmnopJrstufqRySCcZwWxjh";


        //Converts georgian to english
        public static string ConvertToEnglish(string Georgian)
        {
            String GeorgianAlphabet = @"აბგდევზთიკლმნოპჟრსტუფქღყშჩცძწჭხჯჰ";
            string[] EnglishAlphabet = { "a", "b", "g", "d", "e", "v", "z", "t", "i", "k", "l", "m", "n", "o", "p", "zh", "r", "s", "t", "u", "f", "k", "g", "k", "sh", "ch", "ts", "dz", "ts", "tch", "kh", "j", "h" };

            if (Georgian == null)
                return null;

            if (Georgian.Length <= GeorgianAlphabet.Length)
            {
                for (int i = 0; i < Georgian.Length; i++)
                {
                    int Index = GeorgianAlphabet.IndexOf(Georgian[i].ToString(), StringComparison.Ordinal);

                    if (Index != -1)
                    {
                        Georgian = Georgian.Replace(Georgian[i].ToString(), EnglishAlphabet[Index]);
                    }
                }
            }
            else
            {
                for (int i = 0; i < GeorgianAlphabet.Length; i++)
                {
                    Georgian = Georgian.Replace(GeorgianAlphabet[i].ToString(), EnglishAlphabet[i]);
                }
            }

            return Georgian;
        }

        public static string ConvertFromGeorgian(string Georgian)
        {
            if (Georgian == null)
                return null;

            if (Georgian.Length <= GeorgianAlphabet.Length)
            {
                for (int i = 0; i < Georgian.Length; i++)
                {
                    int Index = GeorgianAlphabet.IndexOf(Georgian[i].ToString(), StringComparison.Ordinal);

                    if (Index != -1)
                    {
                        Georgian = Georgian.Replace(Georgian[i], EnglishAlphabet[Index]);
                    }
                }
            }
            else
            {
                for (int i = 0; i < GeorgianAlphabet.Length; i++)
                {
                    Georgian = Georgian.Replace(GeorgianAlphabet[i], EnglishAlphabet[i]);
                }
            }

            return Georgian;
        }

        public static string ConvertToGeorgian(string English)
        {
            if (English == null)
                return null;

            if (English.Length <= EnglishAlphabet.Length)
            {
                for (int i = 0; i < English.Length; i++)
                {
                    int Index = GeorgianAlphabet.IndexOf(English[i].ToString(), StringComparison.Ordinal);

                    if (Index != -1)
                    {
                        English = English.Replace(English[i], GeorgianAlphabet[Index]);
                    }
                }
            }
            else
            {
                for (int i = 0; i < EnglishAlphabet.Length; i++)
                {
                    English = English.Replace(EnglishAlphabet[i], GeorgianAlphabet[i]);
                }
            }

            return English;
        }

        public static string ConvertToUnicode(string Georgian)
        {
            if (Georgian != null)
            {
                String UnicodeAlphabet = "";
                for (int i = 0; i < GeorgianAlphabet.Length; i++)
                {
                    UnicodeAlphabet += Convert.ToChar(i + 4304);
                }

                if (Georgian.Length <= GeorgianAlphabet.Length)
                {
                    for (int i = 0; i < Georgian.Length; i++)
                    {
                        int Index = GeorgianAlphabet.IndexOf(Georgian[i].ToString(), StringComparison.Ordinal);

                        if (Index != -1)
                        {
                            Georgian = Georgian.Replace(Georgian[i], UnicodeAlphabet[Index]);
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < GeorgianAlphabet.Length; i++)
                    {
                        Georgian = Georgian.Replace(GeorgianAlphabet[i], UnicodeAlphabet[i]);
                    }
                }
            }
            return Georgian;
        }

        public static string ConvertFromUnicode(string Georgian)
        {
            if (Georgian != null)
            {

                String UnicodeAlphabet = "";
                for (int i = 0; i < GeorgianAlphabet.Length; i++)
                {
                    UnicodeAlphabet += Convert.ToChar(i + 4304);
                }

                if (Georgian.Length <= GeorgianAlphabet.Length)
                {
                    for (int i = 0; i < Georgian.Length; i++)
                    {
                        int Index = UnicodeAlphabet.IndexOf(Georgian[i].ToString(), StringComparison.Ordinal);

                        if (Index != -1)
                        {
                            Georgian = Georgian.Replace(UnicodeAlphabet[Index], GeorgianAlphabet[Index]);
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < GeorgianAlphabet.Length; i++)
                    {
                        Georgian = Georgian.Replace(UnicodeAlphabet[i], GeorgianAlphabet[i]);
                    }
                }
            }
            return Georgian;
        }

        public static string ConvertString(string strValue)
        {
            string answer = strValue;
            foreach (Match mt in Regex.Matches(strValue, @"(&#)(\d+)(;)"))
            {
                string symb = ConvertNumericCharCodes(mt);
                answer = answer.Replace(mt.ToString(), symb);
            }
            answer = answer.Replace("&lt;", "<");
            answer = answer.Replace("&quot;", "\"");
            answer = answer.Replace("&gt;", ">");
            answer = answer.Replace("&apos;", "'");
            answer = answer.Replace("&amp;", "&");
            return answer;
        }

        public static string SafeString(string strValue)
        {
            string answer = strValue;
            answer = answer.Replace("&", "&amp;");
            answer = answer.Replace("<", "&lt;");
            answer = answer.Replace("\"", "&quot;");
            answer = answer.Replace(">", "&gt;");
            answer = answer.Replace("'", "&apos;");
            return answer;
        }

        /// <summary>
        /// Quotes strings for SQL
        /// </summary>
        /// <param name="strValue">Initial unquoted string</param>
        /// <returns>Quoted safe SQL string</returns>
        static public string SqlQuoted(string strValue)
        {
            return SqlQuoted(strValue, false);
        }

        static public string SqlQuoted(string strValue, bool isUTF)
        {
            if (strValue == null)
                return "NULL";

            string retStr = "";
            foreach (char chr in strValue)
            {
                if (chr == '\'') retStr += chr; // Doubles <'> (single quote) sign
                retStr += chr;
            }
            string prefix = "";
            if (isUTF)
            {
                prefix = "N'";
            }
            else
            {
                prefix = "'";
            }
            retStr = prefix + retStr + "'";
            return retStr;
        }

        /// <summary>
        /// Converts DATE to string format, applicable for Stored Procedure parameters
        /// </summary>
        /// <param name="dateValue">Date to convert</param>
        /// <returns>Converted date</returns>
        public static string SqlDateQuoted(System.DateTime? dateValue)
        {
            if (dateValue == null)
                return "NULL";

            string dateStr = String.Format("{0}/{1}/{2}",
                dateValue.Value.Month,
                dateValue.Value.Day,
                dateValue.Value.Year);
            return SqlQuoted(dateStr);
        }

        /// <summary>
        /// Converts DATE to string format, applicable for rowfilter
        /// </summary>
        /// <param name="dateValue">Date to convert</param>
        /// <returns>Converted date</returns>

        public static string SqlDateSharpQuoted(System.DateTime? dateValue)
        {
            if (dateValue == null)
                return "NULL";

            string dateStr = String.Format("{0}/{1}/{2}",
                dateValue.Value.Month,
                dateValue.Value.Day,
                dateValue.Value.Year);
            return "#" + dateStr + "#";
        }


        /// <summary>
        /// Convert DateTime to string in format yyyy-MM-dd HH:mm:ss
        /// </summary>
        /// <param name="dateValue"></param>
        /// <returns>Returns NULL if vaue is null or is equal of DateTime.MinValue or DateTime.MaxValue</returns>
        public static string SqlDateTimeQuoted(System.DateTime? dateValue)
        {
            if (dateValue == null || dateValue == DateTime.MinValue || dateValue == DateTime.MaxValue)
                return "NULL";
            DateTime dt = Convert.ToDateTime(dateValue);
            string dateStr = dt.ToString("yyyy-MM-dd HH:mm:ss");
            return SqlQuoted(dateStr);
        }

        /// <summary>
        /// Converts DATE to string format, 
        /// applicable for SQL-server,
        /// WITHOUT quotes
        /// </summary>
        /// <param name="dateValue">Date to convert</param>
        /// <returns>Converted date</returns>
        public static string SqlDate(System.DateTime dateValue)
        {
            string dateStr =
                dateValue.Month.ToString() + "/"
                + dateValue.Day.ToString() + "/"
                + dateValue.Year.ToString();
            return dateStr;
        }


        public static bool CheckExpr(System.Text.RegularExpressions.Regex RegExpr, string Str, bool CanBeEmpty)
        {
            if (Str.Length == 0)
            {
                if (CanBeEmpty) return true;
                else return false;
            }
            else
            {
                MatchCollection mc = RegExpr.Matches(Str);
                if (mc.Count == 1 && mc[0].Length == Str.Length)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }


        //-------------------------------------------
        //Date/Time Specifications 
        //ODBC defines a universal format for specifying date and time values. 
        //If you need to include a literal date or time value inside a SQL statement, 
        //always use this format. The formats for date, time, and date/time values are as follows:   
        //Value Format                           Example 
        //Date       {d 'yyyy-mm-dd'}       { d '1995-06-20' } 
        //Time       {t 'hh:mm:ss'}          { t '15:34:08' } 
        //-------------------------------------------   
        /// <summary> 
        /// Converts a Microsoft Date into a ODBC compliant date string {d '2003-03-19'} 
        /// </summary> 
        /// <param name="theDate">Microsoft System.DateTime that you want converted into the Date string</param> 
        /// <returns>string like {d '2003-03-19'}</returns> 
        static public string ConvertDateToODBCString(System.DateTime theDate)
        {
            return "{d '" + theDate.Date.ToString("yyyy-MM-dd") + "'}";
        }

        /// <summary> 
        /// Converts a Microsoft Date into a ODBC compliant time string {t 'HH:MM:SS'} 
        /// </summary> 
        /// <param name="theDate">Microsoft System.DateTime that you want converted into the Time string</param> 
        /// <returns>string like {t '23:59:59'}</returns> 
        static public string ConvertTimeToODBCString(System.DateTime theDate)
        {
            return "{t '" + theDate.ToString("HH:mm:ss") + "'}";
        }

        static public string Base64Encode(String str)
        {
            return (Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(str)));
        }

        static public string base64Decode(string str)
        {
            return (System.Text.Encoding.ASCII.GetString(System.Convert.FromBase64String(str)));
        }

        public static string JSString(string source)
        {
            return source.Replace("'", "");
        }

        private static string ConvertNumericCharCodes(Match m)
        {
            // Finds the numeric character code
            ushort usCode = (ushort)Int32.Parse(Regex.Replace(m.ToString(), @"(&#)(\d+)(;)", "$2"));

            if (usCode > 129 && usCode < 160)
            {
                switch (usCode)
                {
                    case 130:
                        usCode = 8218;
                        break;
                    case 131:
                        usCode = 402;
                        break;
                    case 132:
                        usCode = 8222;
                        break;
                    case 133:
                        usCode = 8230;
                        break;
                    case 134:
                        usCode = 8224;
                        break;
                    case 135:
                        usCode = 8225;
                        break;
                    case 136:
                        usCode = 710;
                        break;
                    case 137:
                        usCode = 8240;
                        break;
                    case 138:
                        usCode = 352;
                        break;
                    case 139:
                        usCode = 8249;
                        break;
                    case 140:
                        usCode = 338;
                        break;
                    case 145:
                        usCode = 8216;
                        break;
                    case 146:
                        usCode = 8217;
                        break;
                    case 147:
                        usCode = 8220;
                        break;
                    case 148:
                        usCode = 8221;
                        break;
                    case 149:
                        usCode = 8226;
                        break;
                    case 150:
                        usCode = 8211;
                        break;
                    case 151:
                        usCode = 8212;
                        break;
                    case 152:
                        usCode = 732;
                        break;
                    case 153:
                        usCode = 8482;
                        break;
                    case 154:
                        usCode = 353;
                        break;
                    case 155:
                        usCode = 8250;
                        break;
                    case 156:
                        usCode = 339;
                        break;
                    case 159:
                        usCode = 376;
                        break;
                }
            }
            return (((char)usCode).ToString());
        }

        /// <summary>
        /// The procedure to convert date from MMYY or MM/YY format to YYMM format
        /// </summary>
        /// <param name="UserEnteredMMYY">The format from Credit Card </param>
        /// <returns>The date in format YYMM</returns>
        public static string CardExpirationDateYYMM(string UserEnteredMMYY)
        {
            string _strDate;
            _strDate = UserEnteredMMYY.Replace("/", "");
            _strDate = _strDate.Replace("\\", "");
            _strDate = _strDate.Substring(2, 2) + _strDate.Substring(0, 2);
            return _strDate;
        }

        /// <summary>
        /// The procedure to convert date from MM\YY or MM/YY format to MMYY format
        /// </summary>
        /// <param name="UserEnteredMMYY">The format from Credit Card </param>
        /// <returns>The date in format MMYY</returns>
        public static string CardExpirationDateMMYY(string UserEnteredMMYY)
        {
            string _strDate;
            _strDate = UserEnteredMMYY.Replace("/", "");
            _strDate = _strDate.Replace("\\", "");
            //_strDate = _strDate.Substring(2, 2) + _strDate.Substring(0, 2);
            return _strDate;
        }

        /// <summary>
        /// The procedure to remove spaces from entered by user Card Number
        /// </summary>
        /// <param name="UserEnteredCardNumber">entered by user Card Number</param>
        /// <returns>CardNumber without spaces</returns>
        public static string CardNumberWithoutBlanks(string UserEnteredCardNumber)
        {
            string _strNumber;
            _strNumber = UserEnteredCardNumber.Replace(" ", "");
            return _strNumber;
        }

        /// <summary>
        /// Converts given string to Bytes Array
        /// </summary>
        /// <param name="str"> Input string to convert</param>
        /// <returns>Array of bytes</returns>
        public static byte[] StrToByteArray(string str)
        {
            System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
            return encoding.GetBytes(str);
        }

        /// <summary>
        /// Converts given unicode string to Bytes Array
        /// </summary>
        /// <param name="str"> Input string to convert</param>
        /// <returns>Array of bytes</returns>
        public static byte[] UnicodeStrToByteArray(string str)
        {
            System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
            return encoding.GetBytes(str);
        }

        /// <summary>
        /// Removes nondigit symbols from phone numbers
        /// </summary>
        /// <param name="phoneNumber">input phone number</param>
        /// <returns>correct phone number</returns>
        public static string CorrectPhoneNumber(string phoneNumber)
        {
            string phoneNumberCorrect = phoneNumber;
            foreach (char ch in phoneNumber)
            {
                if (!Char.IsDigit(ch))
                    phoneNumberCorrect.Replace(ch.ToString(), "");
            }
            return phoneNumberCorrect;
        }

        public static string CheckNull(object param)
        {
            if (param == null)
                return "NULL";

            if (param is string)
                return SqlQuoted((string)param);

            if (param is bool)
                return (((bool)param) ? 1 : 0).ToString();

            if (param is DateTime)
                return SqlDateQuoted((DateTime)param);

            if (param is Enum)
                return ((int)param).ToString();

            return param.ToString();
        }

        public static string CheckNull(object param, object defaultValue)
        {
            if (param != null && defaultValue != null && param.GetType() != defaultValue.GetType())
                throw new Exception("Parameters \"param\" and \"defaultValue\" must have the same types");

            return (param == null) ? defaultValue.ToString() : CheckNull(param);
        }


        public static string FirstCharToUpper(this string input)
        {
            if (String.IsNullOrEmpty(input))
                throw new ArgumentException("Argument Exception!");
            return input.First().ToString().ToUpper() + input.Substring(1);
        }

        /// <summary>
        /// თუ გადმოცემული მნიშვნელობა არის VTB000000, მეთოდი დააბრუნებს VTB000001. ანუ ერთით გაზრდის მნიშვნელობას
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string GetNextValue(this string input)
        {
            return String.Format(AutoGeneratePrefix + "{0:D6}", Convert.ToInt32(input.Substring(AutoGeneratePrefix.Length)) + 1);
        }
    }
}
