using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Downplay.Orchard.LayoutSelector.Models;
using Orchard.ContentManagement.Drivers;
using Orchard;
using Downplay.Orchard.LayoutSelector.Services;
using Orchard.ContentManagement;
using Downplay.Orchard.LayoutSelector.ViewModels;

namespace Downplay.Orchard.LayoutSelector.Drivers
{
    public class LayoutSelectorPartDriver : ContentPartDriver<LayoutSelectorPart> {
        private readonly ILayoutSelectorService _layoutService;
        private readonly IWorkContextAccessor _workContextAccessor;

        protected override string Prefix
        {
            get
            {
                return "LayoutSelector";
            }
        }

        public LayoutSelectorPartDriver(IWorkContextAccessor workContextAccessor, ILayoutSelectorService layoutService)
        {
            _workContextAccessor = workContextAccessor;
            _layoutService = layoutService;
        }

        //DISPLAY
        protected override DriverResult Display(LayoutSelectorPart part, string displayType, dynamic shapeHelper)
        {
            if (!String.IsNullOrWhiteSpace(part.LayoutName) && displayType == "Detail")
            {
                // Get WorkContext
                var wc = _workContextAccessor.GetContext();
                // Add the alternate name to Layout's Metadata. Double underscore '__' translate to a hyphen '-' in the file name.
                // TODO: This might be better done from a handler; and it'd be nice to allow switching Content and other templates
                wc.Layout.Metadata.Alternates.Add("Layout__"+part.LayoutName);
            }

            return ContentShape("Parts_LayoutSelector_SummaryAdmin", () =>
                    shapeHelper.Parts_LayoutSelector_SummaryAdmin(LayoutName: part.LayoutName));

            // The part itself displays nothing (empty DriverResult)
            return new DriverResult();
        }

        //GET
        protected override DriverResult Editor(LayoutSelectorPart part, dynamic shapeHelper)
        {
            return Editor(part, null, shapeHelper);
        }

        //POST
        protected override DriverResult Editor(LayoutSelectorPart part, IUpdateModel updater, dynamic shapeHelper)
        {
            // Create a ViewModel for the editor template
            var model = new LayoutSelectorPartEditViewModel()
            {
                LayoutName = part.LayoutName,
                // Available layout names
                AvailableLayouts = _layoutService.GetLayouts().ToList()
            };

            // Attempt update from POST
            if (updater != null)
            {
                updater.TryUpdateModel(part, Prefix, null, null);
            }

            // Editor display factory
            return ContentShape("Parts_LayoutSelector_Edit",
                     () => shapeHelper.EditorTemplate(
                         TemplateName: "Parts/LayoutSelector",
                         Model: model,
                         Prefix: Prefix));
        }
    }
}
