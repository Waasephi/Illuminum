using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Illuminum.Projectiles.Magic.HM;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using Microsoft.Xna.Framework;

namespace Illuminum.Items.Weapons.Magic.HM
{
	public class GreenJellyStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Green Jelly Staff");
			Tooltip.SetDefault("Shoots bouncing balls of electrified gel that explode into electricity");
			Item.staff[Item.type] = true;
		}

		public override void SetDefaults()
		{
			Item.damage = 48;
			Item.DamageType = DamageClass.Magic;
			Item.width = 66;
			Item.height = 66;
			Item.useTime = 30;
			Item.useAnimation = 30;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 2;
			Item.value = Item.sellPrice(gold: 2);
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item43;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<GreenJellyBall>();
			Item.shootSpeed = 12f;
			Item.mana = 16;
			Item.noMelee = true;
		}
		public override bool PreDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, ref float rotation, ref float scale, int whoAmI)
		{
			Texture2D texture = TextureAssets.Item[Item.type].Value;
			Texture2D textureGlow = ModContent.Request<Texture2D>(Item.ModItem.Texture + "_Glow").Value;
			Rectangle frame;
			if (Main.itemAnimations[Item.type] != null)
				frame = Main.itemAnimations[Item.type].GetFrame(texture, Main.itemFrameCounter[whoAmI]);
			else
				frame = texture.Frame();

			Vector2 origin = frame.Size() / 2f;

			spriteBatch.Draw(texture, Item.Center - Main.screenPosition, frame, lightColor, rotation, origin, scale, SpriteEffects.None, 0f);
			spriteBatch.Draw(textureGlow, Item.Center - Main.screenPosition, frame, Color.White, rotation, origin, scale, SpriteEffects.None, 0f);

			return false;
		}
	}
}