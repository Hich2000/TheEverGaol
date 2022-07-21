using TheSauce.Assets.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using System;

namespace TheSauce.Assets.Projectiles
{
	internal class BlackHoleStar : ModProjectile
	{

		public int circleSpeed = 1;

		public override void SetDefaults()
		{
			Projectile.width = 22;
			Projectile.height = 24;
			Projectile.friendly = true;
			Projectile.penetrate = 5;
			Projectile.timeLeft = 600;
		}

        public override void AI()
        {
			Vector2 starCenter = Projectile.Center;


			bool xInRange = (starCenter.X <= Projectile.ai[0] + 20) && (starCenter.X >= Projectile.ai[0] - 20);
			bool yInRange = (starCenter.Y <= Projectile.ai[1] + 20) && (starCenter.Y >= Projectile.ai[1] - 20);

			if (xInRange && yInRange)
            {
				Projectile.Kill();
            }
        }

    }
}
