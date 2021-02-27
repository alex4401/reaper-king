/*!
 * This file is a part of the Poglin project, whose repository may be found at https://github.com/alex4401/ReaperKing.
 *
 * The project is free software: you can redistribute it and/or modify it under the terms of the GNU Affero General
 * Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option)
 * any later version.
 *
 * This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied
 * warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU Affero General Public License for more
 * details.
 *
 * You should have received a copy of the GNU Affero General Public License along with this program. If not, see
 * https://www.gnu.org/licenses/.
 */

using System.Collections.Generic;

using Xeno.Anhydrate;
using Xeno.Anhydrate.Models;
using Xeno.Core;

using Noglin.Ark;
using Noglin.Ark.Schemas;
using Poglin.Generation.ARK.Models;

namespace Poglin.Generation.ARK
{
    public abstract class ModDocument<T> : AnhydrateDocument<T>
        where T : AnhydrateModModel
    {
        protected ModSpecificationSchema Mod { get; }
        protected BuildConfigurationArk Configuration { get; private set; }

        public ModDocument(ModSpecificationSchema info)
        {
            Mod = info;
        }

        public override NavigationItem[] GetNavigation()
        {
            return new[]
            {
                new NavigationItem("Spawn Maps", Context.GetRootUri()),
                new NavigationItem("Workshop", "https://steamcommunity.com/sharedfiles/filedetails" +
                                                    $"/?id={Mod.Meta.WorkshopId}"),
                new NavigationItem("Standalone.Ini", Context.GetSubPath("/latest/ini.html"),
                                   Configuration.GenerateInis && Mod.Generation.GenerateInis),
            };
        }
        
        public override string GetOpenGraphsType() => "website";

        public override string GetOpenGraphsImage()
        {
            /*if (String.IsNullOrEmpty(Mod.OgImageResource))
            {
                return "";
            }

            string fileExtension = Path.GetExtension(Mod.OgImageResource);
            string fileName = Path.GetFileNameWithoutExtension(Mod.OgImageResource);
            
            return Context.CopyVersionedResource(Mod.OgImageResource,
                                                 $"/og_images/{fileName}-[hash]{fileExtension}");*/
            return "";
        }

        public override FooterInfo GetFooter()
            => new() 
            {
                CopyrightMessage = @"2020 <a href=""https://github.com/alex4401"">alex4401</a>",
                Paragraphs = new [] {
                    "This site is not affiliated with ARK: Survival Evolved or Wildcard Properties, LLC.",
                },
            };

        public override T GenerateModel()
        {
            return base.GenerateModel() with {
                Configuration = Configuration,
            };
        }

        public override DocumentGenerationResult Generate(SiteContext ctx)
        {
            Configuration = ctx.GetConfiguration<BuildConfigurationArk>();
            return base.Generate(ctx);
        }
    }
}