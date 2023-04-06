using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Illuminum.Items.Accessories.PreHM
{
	public class CrystalTear : ModItem //replace ItemName with the name of your accessory
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crystal Tear");
			Tooltip.SetDefault("Having below 1/4th of your max mana doubles your mana regen" +
                "\n'Your cries resonate with this gem'");
		}

		public override void UpdateAccessory(Player player, bool hideVisual) //Where it says "p" is the variable used to represent "player". In this case, every p stands for player. This is called when the accessory is on.
		{
			if (player.statMana <= player.statManaMax2 / 4)
            {
				player.manaRegen *= 2;
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