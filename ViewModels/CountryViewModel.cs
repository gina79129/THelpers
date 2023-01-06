using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace THelpers.ViewModels
{
    public class CountryViewModel
    {
        [Required]
        public string? Country {get;set;}
        public List<SelectListItem> Countries {get;} = new List<SelectListItem>
        {
            new SelectListItem { Text = "USA", Value="US"},
            new SelectListItem { Text = "Canada", Value="CA"},
            new SelectListItem { Text = "Japan", Value="JP"}
        };
        
    }
}