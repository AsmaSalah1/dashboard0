using Microsoft.AspNetCore.Mvc;

namespace Asmaa.Pl.Areas.DashBord.ViewModels
{
    public class LastProductCreateVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public IFormFile Image { get; set; }
        public string? ImageName { get; set; }
        public bool IsDeleted { get; set; }
    }
}
