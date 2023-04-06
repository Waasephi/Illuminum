using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Illuminum.Items.Accessories.HM
{
	public class StardustEmblem : ModItem //replace ItemName with the name of your accessory
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Stardust Emblem");
			Tooltip.SetDefault("A proof of mastery." +
                "\n+25% Summon Damage.");
		}

		public override void UpdateAccessory(Player player, bool hideVisual) //Where it says "p" is the variable used to represent "player". In this case, every p stands for player. This is called when the accessory is on.
		{
			player.GetDamage(DamageClass.Summon) *= 1.25f;
		}

		public override void SetDefaults()
		{
			Item.width = 36;
			Item.height = 36;
			Item.value = Item.sellPrice(gold: 20);
			Item.rare = ItemRarityID.Lime;
			Item.accessory = true;
			Item.expert = false;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.SummonerEmblem);
			recipe.AddIngredient(Mod, "StardustCore");
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.Register();
		}
	}
}