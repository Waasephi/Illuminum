using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Illuminum.Items.Accessories.HM
{
	public class CrystalGuilt : ModItem //replace ItemName with the name of your accessory
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crystal Guilt");
			Tooltip.SetDefault("Having max mana increases your magic damage by 50%" +
				"\n'Your sorrows resonate with this gem'");
		}

		public override void UpdateAccessory(Player player, bool hideVisual) //Where it says "p" is the variable used to represent "player". In this case, every p stands for player. This is called when the accessory is on.
		{
			if (player.statMana == player.statManaMax2)
			{
				player.GetDamage(DamageClass.Magic) *= 1.5f;
			}
		}

		public override void SetDefaults()
		{
			Item.width = 14;
			Item.height = 22;
			Item.value = Item.buyPrice(gold: 20);
			Item.rare = ItemRarityID.LightRed;
			Item.accessory = true;
			Item.expert = false;
		}
	}
}