using System.Collections.Generic;

namespace ReaperKing.Generation.ARK.Data
{
    public class ModInterface
    {
        public readonly string Id;
        public readonly ModInfo Info;
        public List<ModInfo.Revision> Revisions => Info.Revisions;

        public ModInterface(string id)
        {
            Id = id;
            Info = DataManagerARK.Instance.LoadedMods[id];
        }
    }
}