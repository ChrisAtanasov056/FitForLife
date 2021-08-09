namespace FitForLife.Web.ViewModels.Users
{
    using FitForLife.Data.Models;
    using System.Collections.Generic;

    public class AllClientsViewModel
    {
        public List<ClientTrainer> Clients { get; set; } = new List<ClientTrainer>();
    }
}
