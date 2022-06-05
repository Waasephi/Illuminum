using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Illuminum.Biomes.Voidlands
{
	public class VoidlandsWaterStyle : ModWaterStyle
	{

		public override int ChooseWaterfallStyle() => Find<ModWaterfallStyle>("Illuminum/VoidlandsWaterfallStyle").Slot;

		public override int GetSplashDust() => Find<ModDust>("Illuminum/VoidlandsWaterSplash").Type;

		public override int GetDropletGore() => Find<ModGore>("Illuminum/VoidlandsWaterDroplet").Type;

		public override Color BiomeHairColor()
		{
			return Color.Gray;
		}
	}
}