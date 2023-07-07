using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Illuminum.Items.Accessories.HM
{
	public class CharmOfRemorse : ModItem //replace ItemName with the name of your accessory
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Charm of Remorse");
			/* Tooltip.SetDefault("Having max mana increases magic damage by 60%, having below 1/3rd mana doubles your mana regen" +
                "\n'Your guilt resonates with this gem'"); */
		}

		public override void UpdateAccessory(Player player, bool hideVisual) //Where it says "p" is the variable used to represent "player". In this case, every p stands for player. This is called when the accessory is on.
		{
			if (player.statMana == player.statManaMax2)
			{
				player.GetDamage(DamageClass.Magic) *= 1.6f;
			}

			if (player.statMana <= player.statManaMax2 / 3)
			{
				player.manaRegen *= 2;
			}
		}

		public override void SetDefaults()
		{
			Item.width = 14;
			Item.height = 22;
			Item.value = Item.sellPrice(gold: 25);
			Item.rare = ItemRarityID.LightRed;
			Item.accessory = true;
			Item.expert = false;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(Mod, "CrystalTear");
			recipe.AddIngredient(Mod, "CrystalGuilt");
			recipe.AddIngredient(ItemID.ChlorophyteBar, 5);
			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.Register();
		}
	}
}