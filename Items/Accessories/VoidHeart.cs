using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Illuminum.Items.Accessories
{
	public class VoidHeart : ModItem //replace ItemName with the name of your accessory
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Void Heart");
			Tooltip.SetDefault("It is incredibly painful to hold." +
                "\nIncreases your damage by 50% and increases your Life Regeneration by 4." +
                "\nYou lose 200 max life.");
		}

		public override void UpdateAccessory(Player player, bool hideVisual) //Where it says "p" is the variable used to represent "player". In this case, every p stands for player. This is called when the accessory is on.
		{
			player.statLifeMax2 -= 200;
			if(player.statLifeMax2 <= 200)
            {
				player.statLifeMax2 = 1;
				
			}
			player.GetDamage(DamageClass.Generic) *= 1.5f;
			player.lifeRegen += 4;
		}

		public override void SetDefaults()
		{
			Item.width = 34;
			Item.height = 32;
			Item.value = Item.sellPrice(gold: 10);
			Item.rare = ItemRarityID.Cyan;
			Item.accessory = true;
			Item.expert = false;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(Mod, "HoneyHeart");
			recipe.AddIngredient(Mod, "HeartofGaia");
			recipe.AddIngredient(Mod, "AbyssalFlesh", 40);
			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.Register();
		}
	}
}