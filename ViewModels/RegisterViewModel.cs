using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace THelpers.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name="電子郵件")]
        [DataType(DataType.EmailAddress)]
        public string? Email {get;set;}
        
        [Required]
        [Display(Name="密碼")]
        [DataType(DataType.Password)]
        public string? Password {get;set;}

        [NotMapped]
        [Required]
        [Display(Name="確認密碼")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage = "密碼不符合!")]
        public string? ConfirmPassword {get;set;}
    }
}