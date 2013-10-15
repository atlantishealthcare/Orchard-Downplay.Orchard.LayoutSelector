using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard;

namespace Downplay.Orchard.LayoutSelector.Services
{
    public interface ILayoutAlternatesProvider : IDependency
    {
        IEnumerable<string> GetLayouts();
    }
}