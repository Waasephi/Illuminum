using Illuminum.Common.Systems;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Illuminum.Biomes.Voidlands
{
    public class VoidlandsUndergroundBiome : ModBiome
    {
        public override void SetStaticDefaults()
            => DisplayName.SetDefault("Voidlands");

        public override SceneEffectPriority Priority
            => SceneEffectPriority.BiomeHigh;

        public override ModWaterStyle WaterStyle => ModContent.Find<ModWaterStyle>("Illuminum/VoidlandsWaterStyle");

       // public override ModUndergroundBackgroundStyle UndergroundBackgroundStyle
       //    => ModContent.Find<ModUndergroundBackgroundStyle>("Illuminum/Biomes/VoidlandsUndergroundBgStyle");

        public override int Music => MusicLoader.GetMusicSlot(Mod, "Sounds/Music/Vacancy");

        public override string BestiaryIcon => "Assets/Textures/Bestiary/VoidlandsIcon";
        public override string BackgroundPath => "Assets/Textures/Map/VoidlandsMap";
        public override Color? BackgroundColor => base.BackgroundColor;

        public override bool IsBiomeActive(Player player)
        {
            return (player.ZoneRockLayerHeight || player.ZoneDirtLayerHeight) && ModContent.GetInstance<TileCountSystem>().VoidlandsTileCount > 100;
        }
    }
}