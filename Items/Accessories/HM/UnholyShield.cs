using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Items.Accessories.HM
{
	[AutoloadEquip(EquipType.Shield)]
	public class UnholyShield : ModItem //replace ItemName with the name of your accessory
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Unholy Shield");
			Tooltip.SetDefault("Grants Immunity to knockback" +
                "\n+5% Damage Reduction");
		}

		public override void UpdateAccessory(Player player, bool hideVisual) //Where it says "p" is the variable used to represent "player". In this case, every p stands for player. This is called when the accessory is on.
		{
			player.noKnockback = true;
			player.statDefense += 3;
			player.endurance += 0.05f;
		}

		public override void SetDefaults()
		{
			Item.width = 22;
			Item.height = 20;
			Item.value = Item.sellPrice(gold: 2);
			Item.rare = ItemRarityID.Green;
			Item.accessory = true;
			Item.defense = 3;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(Mod,"VialofEvil", 10);
			recipe.AddIngredient(ItemID.SoulofNight, 20);
			recipe.AddIngredient(ItemID.Shackle);
			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.Register();
		}
	}
}