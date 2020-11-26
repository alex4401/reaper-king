using ReaperKing.Anhydrate.Models;
using ReaperKing.Core;
using ReaperKing.Generation.ARK.Data;
using ReaperKing.Generation.ARK.Models;

namespace ReaperKing.Generation.ARK
{
    public class ModHomeGenerator : ModContentGenerator
    {
        public ModHomeGenerator(ModInfo arkMod) : base(arkMod)
        { }
        
        public override PageGenerationResult Generate(SiteContext ctx)
        {
            return new()
            {
                Name = "index",
                Template = "/ARKMods/Home",
                Model = new ModHomeModel(ctx)
                {
                    SectionName = Mod.Name,
                    DocumentTitle = "Spawn Maps",
                    HeaderIconClass = "icon-mod",
                    Navigation = GetNavigation(ctx),
                    
                    ModInfo = Mod,
                    Maps = DataManagerARK.Instance.LoadedMaps,
                },
            };
        }

    }
}