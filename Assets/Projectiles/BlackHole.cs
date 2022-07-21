using TheSauce.Assets.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using System;

namespace TheSauce.Assets.Projectiles
{
    internal class BlackHole : ModProjectile
    {

		public float radius = 800;

		public static int maxInstances = 1;
		public static BlackHole[] blackHoleInstances = new BlackHole[maxInstances];
		public Random spawnRandomizer = new Random();

		public override void SetDefaults()
		{
			Projectile.width = 100;
			Projectile.height = 100;
			Projectile.friendly = true;
			Projectile.penetrate = 1000;
			Projectile.timeLeft = 600;
			Projectile.ai[0] = 0;
		}

        public override void AI()
        {
			Projectile.ai[0] = (Projectile.ai[0]+1)%30;

			if (Projectile.ai[0] == 0)
            {
				float angle = (float)(2.0 * Math.PI * spawnRandomizer.NextDouble());

				Vector2 spawnPosition = Projectile.Center;

				spawnPosition.X = (float)(spawnPosition.X + (Math.Cos(angle) * radius));
				spawnPosition.Y = (float)(spawnPosition.Y + (Math.Sin(angle) * radius));

				Projectile.NewProjectile(Projectile.InheritSource(Projectile), spawnPosition, Vector2.Zero, ModContent.ProjectileType<BlackHoleStar>(), 5, 0, Projectile.owner);
			}
        }

		public override void Kill(int timeLeft = 0)
		{
			base.Kill(0);
			blackHoleInstances[0] = null;
		}

		public override void OnSpawn(IEntitySource source)
        {
            base.OnSpawn(source);
			if (blackHoleInstances[0] != null)
            {
				blackHoleInstances[0].Projectile.Kill();
				blackHoleInstances[0] = this;
			} else
            {
                blackHoleInstances[0] = this;
            }
        }

    }
}
