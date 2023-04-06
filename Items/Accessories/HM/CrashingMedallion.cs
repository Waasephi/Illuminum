using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Items.Accessories.HM
{
	public class CrashingMedallion : ModItem //replace ItemName with the name of your accessory
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crashing Medallion");
			Tooltip.SetDefault("Removes all flight time, but greatly boosts defensive stats" +
                "\n'Become the immovable object'");
		}

		public override void UpdateAccessory(Player player, bool hideVisual) //Where it says "p" is the variable used to represent "player". In this case, every p stands for player. This is called when the accessory is on.
		{
			player.wingTimeMax *= 0;
			player.endurance *= 1.4f;
			player.statDefense += 20;
		}

		public override void SetDefaults()
		{
			Item.width = 30;
			Item.height = 42;
			Item.value = Item.buyPrice(gold: 50);
			Item.rare = ItemRarityID.LightPurple;
			Item.accessory = true;
			Item.expert = false;
		}
	}
}