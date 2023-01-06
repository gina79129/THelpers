using System.ComponentModel.DataAnnotations;

namespace THelpers.ViewModels
{
    public class FeedBackViewModel
    {
        [Display(Name="顧客Email")]
        [DataType(DataType.EmailAddress)]
        public string? Email {get;set;}

        [Display(Name ="顧客意見")]
        public string? Opinion{get;set;}
    }
}