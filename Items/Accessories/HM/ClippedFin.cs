using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Items.Accessories.HM
{
	public class ClippedFin : ModItem //replace ItemName with the name of your accessory
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Clipped Fin");
			/* Tooltip.SetDefault("+25% movement speed when wet." +
                "\nIncreases your movement capabilities." +
                "\n'I'm not going fast enough'"); */
		}

		public override void UpdateAccessory(Player player, bool hideVisual) //Where it says "p" is the variable used to represent "player". In this case, every p stands for player. This is called when the accessory is on.
		{
			if (player.wet)
			{
				player.moveSpeed *= 1.25f;
				player.maxRunSpeed += 1.75f;
			}
			if (player.HasBuff(BuffID.Wet))
			{
				player.moveSpeed *= 1.20f;
				player.maxRunSpeed += 1.70f;
			}
		}

		public override void SetDefaults()
		{
			Item.width = 32;
			Item.height = 32;
			Item.value = Item.buyPrice(gold: 50);
			Item.rare = ItemRarityID.LightPurple;
			Item.accessory = true;
			Item.expert = false;
		}
	}
}