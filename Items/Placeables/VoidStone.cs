using Terraria.ModLoader;
using Terraria.ID;
using Illuminum.Tiles.Voidlands;

namespace Illuminum.Items.Placeables
{
	public class VoidStone : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 16;
			Item.height = 16;
			Item.maxStack = 999;
			Item.useTurn = true;
			Item.autoReuse = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.consumable = true;
			Item.value = 0;
			Item.createTile = ModContent.TileType<VoidStoneTile>();
		}
	}
}