using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Illuminum.Items.Accessories.PreHM
{
	public class BloodyLens : ModItem //replace ItemName with the name of your accessory
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bloody Lens");
			Tooltip.SetDefault("When below half health, doubles your crit chance" +
                "\n'Glistening in the light'");
		}

		public override void UpdateAccessory(Player player, bool hideVisual) //Where it says "p" is the variable used to represent "player". In this case, every p stands for player. This is called when the accessory is on.
		{
			if (player.statLife <= player.statLifeMax2 / 2)
			{
				player.GetCritChance(DamageClass.Generic) *= 2;
			}
		}

		public override void SetDefaults()
		{
			Item.width = 14;
			Item.height = 22;
			Item.value = Item.buyPrice(gold: 2);
			Item.rare = ItemRarityID.Green;
			Item.accessory = true;
			Item.expert = false;
		}
	}
}