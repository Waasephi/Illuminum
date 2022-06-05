using Illuminum.Common.Systems;
using System.Drawing;
using Terraria;
using Terraria.ModLoader;

namespace Illuminum.Biomes.Voidlands
{
    public class VoidlandsSurfaceBiome : ModBiome
    {
        public override void SetStaticDefaults()
            => DisplayName.SetDefault("The Voidlands");

        public override SceneEffectPriority Priority
            => SceneEffectPriority.BiomeHigh;

        /* public override ModSurfaceBackgroundStyle SurfaceBackgroundStyle
             => ModContent.Find<ModSurfaceBackgroundStyle>("AAMod/InfernoSurfaceBgStyle");
         public override void SpecialVisuals(Player player)
         {
             if (Main.dayTime)
             {
                 player.ManageSpecialBiomeVisuals("AAMod:InfernoSurface", player.InModBiome(ModContent.GetInstance<InfernoSurfaceBiome>()));
                 player.ManageSpecialBiomeVisuals("AAMod:Darkness", false);
             }
             if (Main.UseHeatDistortion)
             {
                 player.ManageSpecialBiomeVisuals("HeatDistortion", true);
             }
             SkyManager.Instance.Activate("InfernoSky");
             Filters.Scene["AA:FogOverlay"]?.GetShader().UseOpacity(!Main.dayTime ? 0.10f : 0f).UseIntensity(1f).UseColor(Color.DimGray).UseImage(ModContent.Request<Texture2D>("AAMod/Assets/Textures/Noise/Perlin", AssetRequestMode.ImmediateLoad).Value);
             player.ManageSpecialBiomeVisuals("AA:FogOverlay", player.InModBiome(ModContent.GetInstance<InfernoSurfaceBiome>()));
             if (!Main.dayTime)
             {
                 player.ManageSpecialBiomeVisuals("AAMod:Darkness", player.InModBiome(ModContent.GetInstance<InfernoSurfaceBiome>()));
                 player.ManageSpecialBiomeVisuals("AAMod:InfernoSurface", false);
             }
         }
         public override void OnLeave(Player player)
         {
             SkyManager.Instance.Deactivate("InfernoSky");
             player.ManageSpecialBiomeVisuals("AAMod:InfernoSurface", false);
             player.ManageSpecialBiomeVisuals("AAMod:Darkness", false);
             player.ManageSpecialBiomeVisuals("HeatDistortion", false);
             player.ManageSpecialBiomeVisuals("AA:FogOverlay", false);
         }*/

        public override ModWaterStyle WaterStyle => ModContent.Find<ModWaterStyle>("Illuminum/VoidlandsWaterStyle");
        public override int Music => MusicLoader.GetMusicSlot(Mod, "Sounds/Music/Vacancy");

        public override string BestiaryIcon => "Assets/Textures/Bestiary/VoidlandsIcon";
        public override string BackgroundPath => "Assets/Textures/Map/VoidlandsMap";

        public override bool IsBiomeActive(Player player)
        {
            return (player.ZoneSkyHeight || player.ZoneOverworldHeight) && ModContent.GetInstance<TileCountSystem>().VoidlandsTileCount > 100;
        }
    }
}