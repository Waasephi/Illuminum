using Illuminum.Items.Materials.HM;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Items.Armors.HM.Angelite
{
	[AutoloadEquip(EquipType.Legs)]
	public class AngeliteGreaves : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Angelite Greaves");
			Tooltip.SetDefault("+14% Movement Speed");
		}

		public override void SetDefaults()
		{
			Item.width = 22;
			Item.height = 18;
			Item.value = 1000;
			Item.rare = ItemRarityID.Blue;
			Item.defense = 13;
		}

		public override void UpdateEquip(Player player)
		{
			player.moveSpeed *= 1.14f;
			//player.statManaMax2 += 20;
			//player.maxMinions+=2;
			//player.AddBuff(BuffID.Shine, 2);
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<RefinedAngelite>(), 15);
			recipe.AddTile(Mod, "AngeliteAltar");
			recipe.Register();
		}
	}
}