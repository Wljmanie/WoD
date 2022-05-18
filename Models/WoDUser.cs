using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace WoD.Models
{
    public class WoDUser : IdentityUser
    {
        [Required]
        [StringLength(50, ErrorMessage="The {0} must be at least {2} and no more than {1} characts long.", MinimumLength= 2)]
        [Display(Name = "Nickname")]
        public string NickName { get; set; }

        public byte[]? ImageData { get; set; }
        public string? ImageType { get; set; }

        public virtual ICollection<Vampire> Vampires { get; set; } = new HashSet<Vampire>();

    }
}
