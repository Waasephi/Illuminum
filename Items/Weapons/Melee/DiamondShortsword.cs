using Illuminum.Projectiles;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Items.Weapons.Melee
{
	public class DiamondShortsword : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Diamond Shortsword");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.damage = 19;
			Item.knockBack = 6f;
			Item.useStyle = ItemUseStyleID.Rapier; // Makes the player do the proper arm motion
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 13;
			Item.useAnimation = 13;
			Item.UseSound = SoundID.Item1;
			Item.DamageType = DamageClass.Melee;
			Item.autoReuse = true;
			Item.noUseGraphic = true; // The sword is actually a "projectile", so the item should not be visible when used
			Item.noMelee = true; // The projectile will do the damage and not the item

			Item.rare = ItemRarityID.Blue;
			Item.value = Item.sellPrice(silver: 40);

			Item.shoot = ModContent.ProjectileType<DiamondShortswordProjectile>(); // The projectile is what makes a shortsword work
			Item.shootSpeed = 2.8f; // This value bleeds into the behavior of the projectile as velocity, keep that in mind when tweaking values
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Diamond, 5);
			recipe.AddIngredient(ItemID.PlatinumShortsword);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}