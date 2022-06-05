using Illuminum.Projectiles;
using Illuminum.Items.Materials;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Items.Weapons.Melee
{
	public class QuartzShortsword : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Quartz Shortsword");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.damage = 17;
			Item.knockBack = 5f;
			Item.useStyle = ItemUseStyleID.Rapier; // Makes the player do the proper arm motion
			Item.useAnimation = 16;
			Item.useTime = 16;
			Item.width = 38;
			Item.height = 38;
			Item.UseSound = SoundID.Item1;
			Item.DamageType = DamageClass.Melee;
			Item.autoReuse = false;
			Item.noUseGraphic = true; // The sword is actually a "projectile", so the item should not be visible when used
			Item.noMelee = true; // The projectile will do the damage and not the item

			Item.rare = ItemRarityID.Blue;
			Item.value = Item.sellPrice(silver: 30);

			Item.shoot = ModContent.ProjectileType<QuartzShortswordProjectile>(); // The projectile is what makes a shortsword work
			Item.shootSpeed = 2.6f; // This value bleeds into the behavior of the projectile as velocity, keep that in mind when tweaking values
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<QuartzIngot>(), 7);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}