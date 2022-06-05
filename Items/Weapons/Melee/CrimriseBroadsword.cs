using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Items.Weapons.Melee
{
	public class CrimriseBroadsword : ModItem
	{
		public override void SetStaticDefaults() 
		{
			 DisplayName.SetDefault("Crimrise Broadsword"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("Gives Regeneration on hit." +
                "\nGives Bleeding to targets hit.");
		}

		public override void SetDefaults() 
		{
			Item.damage = 23;
			Item.DamageType = DamageClass.Melee;
			Item.width = 50;
			Item.height = 50;
			Item.useTime = 22;
			Item.useAnimation = 22;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 6;
			Item.value = Item.sellPrice(silver: 45);
			Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = false;
			Item.scale = 1.2f;
		}

		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			// Add the Onfire buff to the NPC for 1 second when the weapon hits an NPC
			// 60 frames = 1 second
			player.AddBuff(BuffID.Regeneration, 10 * 60);
			target.AddBuff(BuffID.Bleeding, 4 * 60);
		}

        public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(Mod, "VialofEvil", 8);
			recipe.AddIngredient(ItemID.Sandstone, 75);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}