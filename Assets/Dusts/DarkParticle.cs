using Terraria;
using Terraria.ModLoader;

namespace TheSauce.Assets.Dusts
{
	public class DarkParticle : ModDust
	{
		public override void OnSpawn(Dust dust)
		{
			dust.noGravity = true;
			dust.alpha = 0;
		}

		public override bool Update(Dust dust)
		{
			dust.rotation += 0.1f;
			dust.alpha += 10;
			if (dust.alpha > 200)
            {
				dust.active = false;
            }
			return false;
		}
	}
}