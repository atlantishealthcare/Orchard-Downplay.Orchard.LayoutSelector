using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.ContentManagement;

namespace Downplay.Orchard.LayoutSelector.Models
{
    public class LayoutSelectorPart : ContentPart<LayoutSelectorPartRecord>
    {

        public string LayoutName
        {
            get { return Record.LayoutName; }
            set { Record.LayoutName = value; }
        }

    }
}