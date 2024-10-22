using Microsoft.AspNetCore.Mvc;

namespace Asmaa.Pl.Areas.DashBord.ViewModels.MainHomeVM
{
    public class MainHomeCreateVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public IFormFile Image { get; set; }
        public string? ImageName { get; set; }
    }
}
