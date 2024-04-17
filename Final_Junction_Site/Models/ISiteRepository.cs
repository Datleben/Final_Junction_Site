using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Junction_Site.Models
{
    public interface ISiteRepository
    {
        IEnumerable<Site> Sites { get; }
    }
}
