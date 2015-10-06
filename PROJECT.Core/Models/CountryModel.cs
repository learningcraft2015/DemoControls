
namespace PROJECT.Core.Models
{
   public class CountryModel
    {
        public int CountryID { get; set; }
        public string CountryName { get; set; }
        public int CountryStatus { get; set; }



        public CountryModel()
        {
            CountryName = string.Empty;
        }
    }

   
}
