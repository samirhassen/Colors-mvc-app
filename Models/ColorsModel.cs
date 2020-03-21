using System.ComponentModel.DataAnnotations;

namespace Colors_store.Models
{
    public class ColorsModel : ViewModelBase
    {
        [Display(Name = "Color")]
        public string Color { get; set; }
        [Display(Name = "Color Code")]
        public string ColorCode { get; set; }
        [Display(Name = "Additional Info")]
        public string Info { get; set; }
    }
}
