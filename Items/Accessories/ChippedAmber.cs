using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Illuminum.Items.Accessories
{
	public class ChippedAmber : ModItem //replace ItemName with the name of your accessory
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Chipped Amber");
			Tooltip.SetDefault("It is smooth to the touch... Except for the chipped part..." +
                "\n+5% Summon Damage.");
		}

		public override void UpdateAccessory(Player player, bool hideVisual) //Where it says "p" is the variable used to represent "player". In this case, every p stands for player. This is called when the accessory is on.
		{
			player.GetDamage(DamageClass.Summon) *= 1.05f;
		}

		public override void SetDefaults()
		{
			Item.width = 16;
			Item.height = 22;
			Item.value = Item.sellPrice(silver: 20);
			Item.rare = ItemRarityID.Blue;
			Item.accessory = true;
			Item.expert = false;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Amber, 7);
			recipe.AddTile(TileID.Sawmill);
			recipe.Register();
		}
	}
}