using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Illuminum.Items.Accessories.PreHM
{
	public class LivingWoodHilt : ModItem //replace ItemName with the name of your accessory
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Living Wood Hilt");
			Tooltip.SetDefault("Easy to attach and detach!" +
                "\n+2% Melee Speed.");
		}

		public override void UpdateAccessory(Player player, bool hideVisual) //Where it says "p" is the variable used to represent "player". In this case, every p stands for player. This is called when the accessory is on.
		{
			player.GetAttackSpeed(DamageClass.Melee) *= 1.02f;
		}

		public override void SetDefaults()
		{
			Item.width = 32;
			Item.height = 22;
			Item.value = Item.sellPrice(silver: 15);
			Item.rare = ItemRarityID.Blue;
			Item.accessory = true;
			Item.expert = false;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Wood, 15);
			recipe.AddTile(TileID.LivingLoom);
			recipe.Register();
		}
	}
}