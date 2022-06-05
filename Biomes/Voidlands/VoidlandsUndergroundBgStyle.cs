using Terraria.ModLoader;

namespace Illuminum.Biomes.Voidlands
{
	public class VoidlandsUndergroundBgStyle : ModUndergroundBackgroundStyle
	{
		public override void FillTextureArray(int[] textureSlots)
		{
			textureSlots[0] = BackgroundTextureLoader.GetBackgroundSlot("Illuminum/Assets/Textures/Backgrounds/Voidlands/VoidlandsUndergroundBackground1");
			textureSlots[1] = BackgroundTextureLoader.GetBackgroundSlot("Illuminum/Assets/Textures/Backgrounds/Voidlands/VoidlandsUndergroundBackground");
			textureSlots[2] = BackgroundTextureLoader.GetBackgroundSlot("Illuminum/Assets/Textures/Backgrounds/Voidlands/VoidlandsCavernBackground1");
			textureSlots[3] = BackgroundTextureLoader.GetBackgroundSlot("Illuminum/Assets/Textures/Backgrounds/Voidlands/VoidlandsCavernBackground");
		}
	}
}