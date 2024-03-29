using Terraria;
using Terraria.ModLoader;

namespace Illuminum.Dusts
{
	public class ForgottenGroveWaterSplash : ModDust
	{
		public override void OnSpawn(Dust dust)
		{
			dust.alpha = 170;
			dust.velocity *= 0.5f;
			dust.velocity.Y += 1f;
		}
	}
}