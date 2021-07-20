namespace FitForLife.Web.ViewModels.Classes
{
    using FitForLife.Data.Models;
    using FitForLife.Services.Mapping;

    public class DetailsClassViewModel: IMapFrom<Class>
    {
        public int Int { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
        public string PictureUrl { get; set; }

        
    }
}
