using System.ComponentModel.DataAnnotations;

namespace Angular_colors.Models
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
