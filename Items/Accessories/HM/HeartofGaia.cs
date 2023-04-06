using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Illuminum.Items.Accessories.HM
{
	public class HeartofGaia : ModItem //replace ItemName with the name of your accessory
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Heart of Gaia");
			Tooltip.SetDefault("The Heart of the god of the Earth." +
                "\nGreatly boosts your Health and Regeneration.");
		}

		public override void UpdateAccessory(Player player, bool hideVisual) //Where it says "p" is the variable used to represent "player". In this case, every p stands for player. This is called when the accessory is on.
		{
			player.statLifeMax2 += 80;
			player.lifeRegen += 3;
		}

		public override void SetDefaults()
		{
			Item.width = 34;
			Item.height = 32;
			Item.value = Item.buyPrice(gold: 30);
			Item.rare = ItemRarityID.Lime;
			Item.accessory = true;
			Item.expert = false;
		}
	}
}