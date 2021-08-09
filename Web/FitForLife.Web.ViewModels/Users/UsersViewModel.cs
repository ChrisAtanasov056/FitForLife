namespace FitForLife.Web.ViewModels.Users
{
    using FitForLife.Data.Models;
    using FitForLife.Services.Mapping;
    using System.Collections.Generic;

    public class UsersViewModel : IMapFrom<ClientTrainer>
    {
        public virtual FitForLifeUser Client { get; set; }

    }
}
