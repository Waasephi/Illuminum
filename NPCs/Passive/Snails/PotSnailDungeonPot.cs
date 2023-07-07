using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.NPCs.Passive.Snails
{
    public class PotSnailDungeonPot : ModProjectile
    {
        //public override void SetStaticDefaults() => DisplayName.SetDefault("Unicorn Spike");

        public override void SetDefaults()
        {
            Projectile.friendly = true;
            Projectile.ignoreWater = false;
            Projectile.tileCollide = true;
            Projectile.DamageType = DamageClass.Ranged;

            Projectile.height = 18;
            Projectile.width = 18;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 300;
            Projectile.aiStyle = 2;
        }
		/*public override void AI()
		{
			Projectile.ai[0] += 1f;
			if (Projectile.ai[0] >= 500f)       //how much time the projectile can travel before landing
			{
				Projectile.velocity.Y = Projectile.velocity.Y;    // projectile fall velocity
				Projectile.velocity.X = Projectile.velocity.X * 3f;    // projectile velocity
			}
		}*/
		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			Projectile.Kill();
			return false;
		}
		public override void Kill(int timeLeft)
		{
			SoundEngine.PlaySound(SoundID.Shatter, Projectile.position);
			for (int i = 0; i < 5; i++)
			{
				int d = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Bone);
				Main.dust[d].scale = 1f;
			}
            if (Projectile.owner == Main.myPlayer)
            {
                int item = 0;
                if (Main.rand.NextBool(15))
                {
                    item = Item.NewItem(Projectile.GetSource_DropAsItem(), Projectile.getRect(), ItemID.GoldCoin);
                }
                if (Main.rand.NextBool(20))
                {
                    item = Item.NewItem(Projectile.GetSource_DropAsItem(), Projectile.getRect(), ItemID.GoldenKey);
                }
                if (Main.rand.NextBool(192))
                {
                    Projectile.NewProjectile(Terraria.Entity.InheritSource(Projectile),
                    Projectile.position, Vector2.Zero, ProjectileID.CoinPortal, 0, 0, Projectile.owner);
                }
                // Sync the drop for multiplayer
                // Note the usage of Terraria.ID.MessageID, please use this!
                if (Main.netMode == NetmodeID.MultiplayerClient && item >= 0)
                {
                    NetMessage.SendData(MessageID.SyncItem, -1, -1, null, item, 1f);
                }
            }
        }

		public override bool PreAI()
		{
		    //Projectile.rotation += 0.1f;
			return true;
		}
	}
}