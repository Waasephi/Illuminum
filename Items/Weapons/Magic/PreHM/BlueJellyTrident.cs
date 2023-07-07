using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Illuminum.Projectiles.Magic.PreHM;

namespace Illuminum.Items.Weapons.Magic.PreHM
{
	public class BlueJellyTrident : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Blue Jelly Trident");
			// Tooltip.SetDefault("Shoots bouncing balls of electrified gel");
			Item.staff[Item.type] = true;
		}

		public override void SetDefaults()
		{
			Item.damage = 24;
			Item.DamageType = DamageClass.Magic;
			Item.width = 50;
			Item.height = 50;
			Item.useTime = 40;
			Item.useAnimation = 40;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 2;
			Item.value = Item.sellPrice(silver: 40);
			Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item43;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<BlueJellyBall>();
			Item.shootSpeed = 10f;
			Item.mana = 8;
			Item.noMelee = true;
		}
	}
}