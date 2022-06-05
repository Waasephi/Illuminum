using Illuminum.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Items.Weapons.Melee
{
	public class GraniteCore : ModItem
	{
		public override void SetStaticDefaults()
		{
			// These are all related to gamepad controls and don't seem to affect anything else
			ItemID.Sets.Yoyo[Item.type] = true;
			ItemID.Sets.GamepadExtraRange[Item.type] = 15;
			ItemID.Sets.GamepadSmartQuickReach[Item.type] = true;
			DisplayName.SetDefault("Granite Core");
			Tooltip.SetDefault("Shoots an electric laser at the cursor.");
		}

		public override void SetDefaults()
		{
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.width = 34;
			Item.height = 32;
			Item.useAnimation = 25;
			Item.useTime = 25;
			Item.shootSpeed = 13f;
			Item.knockBack = 2.5f;
			Item.damage = 20;
			Item.rare = ItemRarityID.Blue;
			Item.DamageType = DamageClass.Melee;
			Item.channel = true;
			Item.noMelee = true;
			Item.noUseGraphic = true;

			Item.UseSound = SoundID.Item1;
			Item.value = Item.sellPrice(silver: 65);
			Item.shoot = ModContent.ProjectileType<GraniteCoreProjectile>();
		}
	}
}