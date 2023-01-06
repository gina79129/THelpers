using System.ComponentModel.DataAnnotations;
namespace THelpers.ViewModels
{
    public class CountryEnumViewModel
    {
        public CountryEnumViewModel? EnumerateCountry {get;set;}
    }
    public enum CountryEnum{
        [Display(Name="美國")]
        USA=10,
        [Display(Name ="日本")]
        Japan=20,
        Canada=30,
        France=40,
        Germany=50
    }
}