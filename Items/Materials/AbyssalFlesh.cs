using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Illuminum.Items.Materials
{
	public class AbyssalFlesh : ModItem
	{
		public override void SetStaticDefaults() 
		{
			 DisplayName.SetDefault("Abyssal Flesh"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
		}

		public override void SetDefaults() 
		{
			Item.width = 16;
			Item.height = 16;
			Item.value = Item.sellPrice(silver: 20);
			Item.rare = ItemRarityID.Pink;
			Item.maxStack = 999;
		}
	}
}