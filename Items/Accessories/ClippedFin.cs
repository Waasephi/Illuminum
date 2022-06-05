using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Items.Accessories
{
	public class ClippedFin : ModItem //replace ItemName with the name of your accessory
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Clipped Fin");
			Tooltip.SetDefault("+50% Movement Speed." +
                "\nIncreases your movement capabilities." +
                "\nThin but durable.");
		}

		public override void UpdateAccessory(Player player, bool hideVisual) //Where it says "p" is the variable used to represent "player". In this case, every p stands for player. This is called when the accessory is on.
		{
			player.moveSpeed *= 1.5f;
			player.maxRunSpeed += 2.5f;
		}

		public override void SetDefaults()
		{
			Item.width = 32;
			Item.height = 32;
			Item.value = Item.buyPrice(gold: 75);
			Item.value = Item.sellPrice(gold: 25);
			Item.rare = ItemRarityID.LightPurple;
			Item.accessory = true;
			Item.expert = false;
		}
	}
}