using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Illuminum.Projectiles.Magic.PreHM;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using Microsoft.Xna.Framework;

namespace Illuminum.Items.Weapons.Magic.PreHM
{
	public class PinkJellyWand : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Pink Jelly Wand");
			Tooltip.SetDefault("Shoots balls of gel that explode into electricity");
			Item.staff[Item.type] = true;
		}

		public override void SetDefaults()
		{
			Item.damage = 20;
			Item.DamageType = DamageClass.Magic;
			Item.width = 50;
			Item.height = 50;
			Item.useTime = 45;
			Item.useAnimation = 45;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 2;
			Item.value = Item.sellPrice(silver: 40);
			Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item43;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<PinkJellyBall>();
			Item.shootSpeed = 10f;
			Item.mana = 12;
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