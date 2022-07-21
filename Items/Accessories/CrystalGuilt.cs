using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Illuminum.Items.Accessories
{
	public class CrystalGuilt : ModItem //replace ItemName with the name of your accessory
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crystal Guilt");
			Tooltip.SetDefault("Your sorrows resonate with this gem." +
                "\nDoubles Mana Regeneration.");
		}

		public override void UpdateAccessory(Player player, bool hideVisual) //Where it says "p" is the variable used to represent "player". In this case, every p stands for player. This is called when the accessory is on.
		{
			player.manaRegen *= 2;
		}

		public override void SetDefaults()
		{
			Item.width = 14;
			Item.height = 22;
			Item.value = Item.buyPrice(gold: 30);
			Item.rare = ItemRarityID.LightRed;
			Item.accessory = true;
			Item.expert = false;
		}
	}
}