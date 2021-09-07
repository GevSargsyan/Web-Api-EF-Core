using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Contracts
{
    public class Homework
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Uri Link { get; set; }

    }
}
