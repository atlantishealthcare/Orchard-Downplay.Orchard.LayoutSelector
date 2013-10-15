using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard;

namespace Downplay.Orchard.LayoutSelector.Services
{
    public interface ILayoutSelectorService : IDependency
    {
        IEnumerable<string> GetLayouts();
    }
}