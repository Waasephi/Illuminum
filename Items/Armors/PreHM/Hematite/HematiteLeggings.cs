using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Items.Armors.PreHM.Hematite
{
	[AutoloadEquip(EquipType.Legs)]
	public class HematiteLeggings : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Hematite Leggings");
			Tooltip.SetDefault("+10% Movement Speed");
		}

		public override void SetDefaults()
		{
			Item.width = 22;
			Item.height = 18;
			Item.value = Item.sellPrice(silver: 15);
			Item.rare = ItemRarityID.Green;
			Item.defense = 5;
		}

		public override void UpdateEquip(Player player)
		{
			player.moveSpeed *= 1.1f;
			//player.statManaMax2 += 20;
			//player.maxMinions+=2;
			//player.AddBuff(BuffID.Shine, 2);
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(Mod, "HematiteChunk", 15);
			recipe.AddTile(Mod, "CursedForge");
			recipe.Register();
		}
	}
}