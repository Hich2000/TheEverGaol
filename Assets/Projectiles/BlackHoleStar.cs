using TheSauce.Assets.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using System;
using Terraria.ModLoader.Assets;

namespace TheSauce.Assets.Projectiles
{

	internal class BlackHoleStar : ModProjectile
	{
		public float spiralModifier = 1.0f;

		public override void SetDefaults()
		{
			Projectile.width = 22;
			Projectile.height = 24;
			Projectile.friendly = true;
			Projectile.penetrate = 5;
			Projectile.timeLeft = 9999;
			Projectile.tileCollide = false;
			Projectile.light = 1f;
		}

        public override void AI()
        {
			Vector2 blackHoleCenter = new Vector2(Projectile.ai[0], Projectile.ai[1]);
			Vector2 starCenter = Projectile.Center;
			//angle in radian
			double angleToblackHole = blackHoleCenter.AngleTo(starCenter);
			//√[(x₂ - x₁)² + (y₂ - y₁)²] 
			double distanceToBlackHole = Math.Sqrt(Math.Pow((starCenter.X - blackHoleCenter.X), 2) + Math.Pow((blackHoleCenter.Y - starCenter.Y), 2));
			double modifiedDistance = distanceToBlackHole - spiralModifier;
			spiralModifier += 0.3f;

			//change the angle and set the new center of the star projectile
			double newAngle = angleToblackHole + 0.06f;
			float newAngleCos = (float)Math.Cos(newAngle);
			float newAngleSin = (float)Math.Sin(newAngle);

            float newCenterX = (float)(blackHoleCenter.X + (newAngleCos * modifiedDistance));
            float newCenterY = (float)(blackHoleCenter.Y + (newAngleSin * modifiedDistance));
            Projectile.Center = new Vector2(newCenterX, newCenterY);


            //Console.WriteLine("distanceToBlackHole: " + distanceToBlackHole);
            //Console.WriteLine("\n");




			//check if star has entered the center of the black hole
			bool xInRange = (starCenter.X <= Projectile.ai[0] + 20) && (starCenter.X >= Projectile.ai[0] - 20);
			bool yInRange = (starCenter.Y <= Projectile.ai[1] + 20) && (starCenter.Y >= Projectile.ai[1] - 20);

			if (xInRange && yInRange)
			{
				Projectile.Kill();
			}
        }
	}
}
