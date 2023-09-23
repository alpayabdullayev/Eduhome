using System;

namespace Eduhome_again.Models
{
    public class Blog
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Image { get; set; }
        public string By { get; set; }

        public DateTime CreateTime { get; set; }
    }
}
