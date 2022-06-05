using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Items.Accessories
{
	public class CrackedBeak : ModItem //replace ItemName with the name of your accessory
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cracked Beak");
			Tooltip.SetDefault("+2 Minion Slots." +
                "\nHas a faint magic energy.");
		}

		public override void UpdateAccessory(Player player, bool hideVisual) //Where it says "p" is the variable used to represent "player". In this case, every p stands for player. This is called when the accessory is on.
		{
			player.maxMinions += 2;
		}

		public override void SetDefaults()
		{
			Item.width = 20;
			Item.height = 16;
			Item.value = Item.buyPrice(gold: 75);
			Item.rare = ItemRarityID.Lime;
			Item.accessory = true;
			Item.expert = false;
		}
	}
}