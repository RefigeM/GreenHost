using System.ComponentModel.DataAnnotations;

namespace GreenHost.ViewModels.MemberVMs
{
    public class MemberUpdateVM
    {
        [Required, MaxLength(64)]
        public string FullName { get; set; }
        public IFormFile Image { get; set; }
        public int DepartmentId { get; set; }
    }
}
