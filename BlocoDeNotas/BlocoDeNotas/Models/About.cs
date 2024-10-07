using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlocoDeNotas.Models
{
    public class About
    {

        public string Title { get; set; }
        public string Version { get; set; }
        public string Description { get; set; }
        public string MoreInfoURL { get; set; }

        public About()
        {
            Title = AppInfo.Name;
            Version = AppInfo.VersionString;
            Description = "Saga App foi feito para escritores";
            MoreInfoURL = "https://google.com.br";
        }
    }
}
