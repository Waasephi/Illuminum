using System;
using Terraria.ModLoader;
using Illuminum.Tiles.Voidlands;

namespace Illuminum.Common.Systems
{
    public class TileCountSystem : ModSystem
    {
        public int VoidlandsTileCount { get; set; }

        public override void ResetNearbyTileEffects()
        {
            VoidlandsTileCount = 0;
        }

        public override void TileCountsAvailable(ReadOnlySpan<int> tileCounts)
        {
            VoidlandsTileCount = tileCounts[ModContent.TileType<VoidStoneTile>()];
        }  
    }
}