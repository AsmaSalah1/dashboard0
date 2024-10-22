namespace Asmaa.Pl.Areas.DashBord.ViewModels.FeaturesVM
{
    public class FeaturesCreateVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IFormFile Image { get; set; }
        public string? ImageName { get; set; }
    }
}
