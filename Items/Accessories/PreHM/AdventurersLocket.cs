using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Illuminum.Items.Accessories.PreHM
{
	public class AdventurersLocket : ModItem //replace ItemName with the name of your accessory
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Adventurer's Locket");
			/* Tooltip.SetDefault("Filled with hopes and dreams." +
                "\n+5% Movement Speed, and increased luck."); */
		}

		public override void UpdateAccessory(Player player, bool hideVisual) //Where it says "p" is the variable used to represent "player". In this case, every p stands for player. This is called when the accessory is on.
		{
			player.moveSpeed *= 1.05f;
			player.luck += 0.5f;
		}

		public override void SetDefaults()
		{
			Item.width = 20;
			Item.height = 22;
			Item.value = Item.buyPrice(gold: 1, silver: 50);
			Item.rare = ItemRarityID.Blue;
			Item.accessory = true;
			Item.expert = false;
		}
	}
}