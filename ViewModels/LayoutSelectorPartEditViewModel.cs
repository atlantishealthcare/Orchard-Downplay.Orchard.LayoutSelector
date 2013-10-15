using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Downplay.Orchard.LayoutSelector.ViewModels
{
    public class LayoutSelectorPartEditViewModel
    {
        public string LayoutName { get; set; }

        public IEnumerable<String> AvailableLayouts { get; set; }

    }
}