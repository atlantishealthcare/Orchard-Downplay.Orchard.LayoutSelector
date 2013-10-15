using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.ContentManagement.Handlers;
using Downplay.Orchard.LayoutSelector.Models;
using Orchard.Data;

namespace Downplay.Orchard.LayoutSelector.Handlers
{
    public class LayoutSelectorPartHandler : ContentHandler
    {
        public LayoutSelectorPartHandler(IRepository<LayoutSelectorPartRecord> repository)
        {
            Filters.Add(StorageFilter.For(repository));
        }
    }
}