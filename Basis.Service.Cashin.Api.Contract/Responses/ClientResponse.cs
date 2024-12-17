namespace Basis.Service.Cashin.Api.Contract.Responses
{
    /// <summary>
    /// კლიენტის ინფორმაცია
    /// </summary>
    public class ClientResponse
    {
        /// <summary>
        /// ბანკი კლიენტის ნომერი. ამით ხდება ანგარიშების გამოძახება ტრანზაქციის რეგისტრაცია
        /// </summary>
        public int ClientNo { get; set; }

        /// <summary>
        /// ფიზიკურის შემთხვევაში სრული სახელი გვარი. იურიდიულის შემთხვევაში კომპანის სახელი(ქართულად)
        /// </summary>
        public string NameKa { get; set; }

        /// <summary>
        /// ფიზიკურის შემთხვევაში სრული სახელი გვარი. იურიდიულის შემთხვევაში კომპანის სახელი(ინგლისურად)
        /// </summary>
        public string NameEn { get; set; }


        public decimal? RemainingDailyLimit { get; set; }


    }
}
