namespace Vidly_App.Models
{
    public class MembershipType
    {
        public int Id { get; set; }
        public string SignUpFee { get; set; }
        public int DurationInMonths { get; set; }
        public int DiscountRate { get; set; }
        public string Name { get; set; }

        public static readonly int unknown = 0;
        public static readonly int PayAsYouGo = 1;



    }

}