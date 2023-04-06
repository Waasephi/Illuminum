using Illuminum.Projectiles.Melee.PreHM;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Items.Weapons.Melee.PreHM
{
	public class AmberShortsword : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Amber Shortsword");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.damage = 13;
			Item.knockBack = 5f;
			Item.useStyle = ItemUseStyleID.Rapier; // Makes the player do the proper arm motion
			Item.useAnimation = 16;
			Item.useTime = 16;
			Item.width = 32;
			Item.height = 32;
			Item.UseSound = SoundID.Item1;
			Item.DamageType = DamageClass.Melee;
			Item.autoReuse = false;
			Item.noUseGraphic = true; // The sword is actually a "projectile", so the item should not be visible when used
			Item.noMelee = true; // The projectile will do the damage and not the item

			Item.rare = ItemRarityID.Blue;
			Item.value = Item.sellPrice(silver: 20);

			Item.shoot = ModContent.ProjectileType<AmberShortswordProjectile>(); // The projectile is what makes a shortsword work
			Item.shootSpeed = 2.4f; // This value bleeds into the behavior of the projectile as velocity, keep that in mind when tweaking values
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Amber, 5);
			recipe.AddIngredient(ItemID.IronShortsword);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();

			Recipe recipe2 = CreateRecipe();
			recipe2.AddIngredient(ItemID.Amber, 5);
			recipe2.AddIngredient(ItemID.LeadShortsword);
			recipe2.AddTile(TileID.Anvils);
			recipe2.Register();
		}
	}
}