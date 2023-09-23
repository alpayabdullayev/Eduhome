using Eduhome_again.Models;
using System.Collections.Generic;

namespace Eduhome_again.ViewModels
{
    public class HomeVM
    {
        public List<Slider> Sliders { get; set; }
        public List<Service> Services { get; set; }

        public About Abouts { get; set; }
    }
}
