using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Illuminum.Items.Accessories.PreHM
{
	public class AllSeeingEye : ModItem //replace ItemName with the name of your accessory
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Adventurer's Locket");
			/* Tooltip.SetDefault("Filled with hopes and dreams." +
                "\n+5% Movement Speed, and increased luck."); */
		}

		public override void UpdateAccessory(Player player, bool hideVisual) //Where it says "p" is the variable used to represent "player". In this case, every p stands for player. This is called when the accessory is on.
		{
			player.nightVision = true;
			player.biomeSight = true;
			player.dangerSense = true;
			player.CanSeeInvisibleBlocks = true;
            player.AddBuff(BuffID.Hunter, 2);
            player.AddBuff(BuffID.Spelunker, 2);
        }

		public override void SetDefaults()
		{
			Item.width = 20;
			Item.height = 22;
			Item.value = Item.buyPrice(gold: 10, silver: 50);
			Item.rare = ItemRarityID.Orange;
			Item.accessory = true;
			Item.expert = false;
		}
	}
}