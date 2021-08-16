namespace FitForLife.Web.ViewModels.Classes
{
    
    using FitForLife.Data.Models;
    using FitForLife.Services.Mapping;
    using System.Collections.Generic;

    public class ClassViewModel :  IMapFrom<Class>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string PictureUrl { get; set; }

        public ICollection<FitForLifeUser> Trainers { get; set; }

        public ICollection<Event> Events { get; set; }

        public int MaxClients { get; set; }

    }
    
}
