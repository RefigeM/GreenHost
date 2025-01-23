using System.ComponentModel.DataAnnotations;

namespace GreenHost.ViewModels.DepartmentVMs
{
    public class DepartmentCreateVM
    {
        [Required, MaxLength(64, ErrorMessage = "can't be more than 64.")]
        public string Name { get; set; }
    }
}
