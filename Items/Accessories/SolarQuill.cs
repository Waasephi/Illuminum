using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Items.Accessories
{
	public class SolarQuill : ModItem //replace ItemName with the name of your accessory
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Solar Quill");
			Tooltip.SetDefault("Gives +15% Damage during the day." +
                "\nA quill from ancient times... Who would write with a rock?");
		}

		public override void UpdateAccessory(Player player, bool hideVisual) //Where it says "p" is the variable used to represent "player". In this case, every p stands for player. This is called when the accessory is on.
		{
			if (Main.dayTime)
			{
				player.GetDamage(DamageClass.Generic) *= 1.15f;
			}
		}

		public override void SetDefaults()
		{
			Item.width = 32;
			Item.height = 32;
			Item.value = Item.buyPrice(gold: 50);
			Item.value = Item.sellPrice(gold: 20);
			Item.rare = ItemRarityID.LightPurple;
			Item.accessory = true;
			Item.expert = false;
		}
	}
}