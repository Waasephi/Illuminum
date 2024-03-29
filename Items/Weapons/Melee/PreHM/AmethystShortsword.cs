using Illuminum.Projectiles.Melee.PreHM;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Items.Weapons.Melee.PreHM
{
	public class AmethystShortsword : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Amethyst Shortsword");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.damage = 9;
			Item.knockBack = 5f;
			Item.useStyle = ItemUseStyleID.Rapier; // Makes the player do the proper arm motion
			Item.useAnimation = 15;
			Item.useTime = 15;
			Item.width = 32;
			Item.height = 32;
			Item.UseSound = SoundID.Item1;
			Item.DamageType = DamageClass.Melee;
			Item.autoReuse = false;
			Item.noUseGraphic = true; // The sword is actually a "projectile", so the item should not be visible when used
			Item.noMelee = true; // The projectile will do the damage and not the item

			Item.rare = ItemRarityID.Blue;
			Item.value = Item.sellPrice(silver: 10);

			Item.shoot = ModContent.ProjectileType<AmethystShortswordProjectile>(); // The projectile is what makes a shortsword work
			Item.shootSpeed = 2.4f; // This value bleeds into the behavior of the projectile as velocity, keep that in mind when tweaking values
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Amethyst, 5);
			recipe.AddIngredient(ItemID.CopperShortsword);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}