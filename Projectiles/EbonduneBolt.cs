using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;

namespace Illuminum.Projectiles
{
	public class EbonduneBolt : ModProjectile
	{
		public float start = 0;

		public override void SetDefaults()
		{
			Projectile.width = 16;
			Projectile.height = 16;
			Projectile.friendly = true;
			Projectile.aiStyle = 0;
			Projectile.DamageType = DamageClass.Generic;
			Projectile.penetrate = 2;      //this is how many enemy this projectile penetrate before disappear
			Projectile.extraUpdates = 1;
			AIType = 507;
			Projectile.timeLeft = 1000;
			Main.projFrames[Projectile.type] = 1;
			Projectile.tileCollide = true;
			Projectile.ignoreWater = false;
		}

        public override void SetStaticDefaults()
		{
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 20;
			ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
		}

		public override void AI()
		{
			Player player = Main.player[Projectile.owner];

			if (Main.rand.NextBool(10))
			{
				var dust = Dust.NewDustDirect(Projectile.Center, 0, 0, DustID.PurpleTorch, -Projectile.velocity.X / 2f, -Projectile.velocity.Y / 2f);
				dust.noGravity = true;
				dust.fadeIn = 1f;
				dust.scale = 0.5f;

				Projectile.netUpdate = true;
			}

			if (Main.myPlayer == Projectile.owner && Projectile.ai[0] == 0f)
			{
				if (player.channel)
				{
					if (player.dead)
					{
						Projectile.Kill();
						return;
					}

					Projectile.localAI[0] += 1f;

					double deg = Projectile.ai[1];
					double rad = deg * (Math.PI / 180);
					double dist = 60;

					Projectile.position.X = player.Center.X - (int)(Math.Cos(rad) * dist) - Projectile.width / 2;
					Projectile.position.Y = player.Center.Y - (int)(Math.Sin(rad) * dist) - Projectile.height / 2;
					Projectile.rotation = (float)rad;

					Projectile.ai[1] += 7.5f;
					Projectile.tileCollide = false;
				}
				else if (Projectile.ai[0] == 0f)
				{
					Projectile.netUpdate = true;

					float Speed = 14f;
					Vector2 vectorToCursor = Main.MouseWorld - Projectile.Center;
					float distanceToCursor = vectorToCursor.Length();

					distanceToCursor = Speed / distanceToCursor;
					vectorToCursor *= distanceToCursor;

					Projectile.velocity = vectorToCursor;

					Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
					Projectile.tileCollide = true;
					Projectile.penetrate = 1;

					Projectile.timeLeft = 200;

					Projectile.ai[0] = 1f;
				}
			}
		}

		public override bool PreDraw(ref Color lightColor)
        {
                 
	
			for (int i = 1; i < Projectile.oldPos.Length; i++)
			{
				Projectile.oldPos[i] = Projectile.oldPos[i - 1] + (Projectile.oldPos[i] - Projectile.oldPos[i - 1]).SafeNormalize(Vector2.Zero) * MathHelper.Min(Vector2.Distance(Projectile.oldPos[i - 1], Projectile.oldPos[i]), start);
			}

			Main.spriteBatch.End();
			Main.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.Additive, null, null, null, null, Main.GameViewMatrix.ZoomMatrix);
			{
				Color col = Color.BlueViolet;
				col.A = 255;
				for (int i = 0; i < Projectile.oldPos.Length; i++)
				{
					Main.spriteBatch.Draw(TextureAssets.Projectile[Projectile.type].Value, Projectile.oldPos[i] + new Vector2(Projectile.width / 2, Projectile.height / 2) - Main.screenPosition,
					new Rectangle(0, 0, 16, 16), col, Projectile.rotation,
					new Vector2(16 * 0.5f, 16 * 0.5f), Vector2.Lerp(new Vector2(0.5f, 0.5f), new Vector2(0, 0), i / (float)Projectile.oldPos.Length), SpriteEffects.None, 0f);
				}

				Main.spriteBatch.Draw(TextureAssets.Projectile[Projectile.type].Value, Projectile.position + new Vector2(Projectile.width / 2, Projectile.height / 2) - Main.screenPosition,
				   new Rectangle(0, 0, 16, 16), col, Projectile.rotation,
				   new Vector2(16 * 0.5f, 16 * 0.5f), 1f, SpriteEffects.None, 0f);
				
			}
			return base.PreDraw(ref lightColor);
		}

		public override void PostDraw(Color drawColor)
		{
			Main.spriteBatch.End();
			Main.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null, Main.GameViewMatrix.ZoomMatrix);
		}

		public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
			Player player = Main.player[Projectile.owner];
			if (player.channel)
			{
				damage /= 2;
				knockback /= 4;
			}
		}

		public override void Kill(int timeLeft)
		{
			SoundEngine.PlaySound(SoundID.Item10, Projectile.position);

		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{                                                           // sound that the projectile make when hitting the terrain
			{
				Projectile.Kill();

				for (int i = 0; i < 6; i++)
                {
					Dust dust;
					Vector2 position = Projectile.Center;
					dust = Main.dust[Dust.NewDust(position, 0, 0, DustID.PurpleTorch, 0f, 0f, 0, new Color(255, 255, 255), 1f)];
					dust.noGravity = true;
					dust.scale = 0.5f;
				}

				SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
			}
			return false;
		}
	}
}