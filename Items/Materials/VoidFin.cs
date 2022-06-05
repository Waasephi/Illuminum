using Illuminum.Tiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Illuminum.Items.Materials
{
	public class VoidFin : ModItem
	{
		public override void SetStaticDefaults() 
		{
			 DisplayName.SetDefault("Void Fin"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
		}

		public override void SetDefaults() 
		{
			Item.width = 44;
			Item.height = 38;
			Item.value = Item.sellPrice(silver: 10);
			Item.rare = ItemRarityID.Blue;
			Item.maxStack = 999;
		}
	}
}