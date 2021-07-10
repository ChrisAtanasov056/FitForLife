namespace FitForLife.Web.ViewModels.Classes
{
    using AutoMapper;
    using FitForLife.Data.Models;
    using FitForLife.Services.Mapping;

    public class ClassViewModel : IMapFrom<Class>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string PictureUrl { get; set; }

        public int MaxClients { get; set; }
    }
    
}
