using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.ContentManagement.Records;

namespace Downplay.Orchard.LayoutSelector.Models
{
    public class LayoutSelectorPartRecord : ContentPartRecord
    {
        public virtual string LayoutName { get; set; }
    }
}