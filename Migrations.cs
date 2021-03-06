﻿using System;
using System.Collections.Generic;
using System.Data;
using Orchard.ContentManagement.Drivers;
using Orchard.ContentManagement.MetaData;
using Orchard.ContentManagement.MetaData.Builders;
using Orchard.Core.Contents.Extensions;
using Orchard.Data.Migration;
using Downplay.Orchard.LayoutSelector.Models;

namespace Downplay.Orchard.LayoutSelector
{
    public class Migrations : DataMigrationImpl
    {
        public int Create()
        {
            SchemaBuilder.CreateTable("LayoutSelectorPartRecord", table => table

                // Tells the content engine that this will always be attached to a content record (and there's no need to add a primary key field)
                .ContentPartRecord()
                // Create the layout column
                .Column<string>("LayoutName"));

            // Make our part *attachable to any form of content item*
            ContentDefinitionManager.AlterPartDefinition(
                typeof(LayoutSelectorPart).Name, cfg => cfg.Attachable());

            // Let the migrations system know that this was migration #1; numbers go up sequentially for subsequent migrations!
            return 1;
        }
    }
}