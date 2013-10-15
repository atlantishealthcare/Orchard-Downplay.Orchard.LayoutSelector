using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Downplay.Orchard.LayoutSelector.Services
{
    public class DefaultLayoutAlternatesProvider : ILayoutAlternatesProvider
    {
        public IEnumerable<string> GetLayouts()
        {
            yield return "Default";
        }
    }
}