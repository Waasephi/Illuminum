using Illuminum.Tiles;
using Terraria.ModLoader;
using Terraria.ID;

namespace Illuminum.Items.Placeables
{
	public class FrigidConstructTrophy : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 30;
			Item.height = 30;
			Item.maxStack = 99;
			Item.useTurn = true;
			Item.autoReuse = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.consumable = true;
			Item.value = 50000;
			Item.rare = ItemRarityID.Blue;
			Item.createTile = ModContent.TileType<BossTrophy>();
			Item.placeStyle = 0;
		}
	}
}