using Terraria;
using Terraria.ModLoader;
using System;
using Terraria.DataStructures;

namespace TheSauce.Assets.Projectiles
{
    public class BlackHoleEffect : ModProjectile
    {

        public static BlackHoleEffect currentInstance = null;

        public override void SetDefaults()
        {
            Projectile.width = 150;
            Projectile.height = 125;
            Projectile.friendly = true;
            Projectile.penetrate = int.MaxValue;
            Projectile.timeLeft = 800;
            Projectile.damage = 0;
            Projectile.alpha = 200;
        }

        public override void AI()
        {
            Projectile.rotation += 0.1f;
        }

        public override void OnSpawn(IEntitySource source)
        {
            base.OnSpawn(source);

            if (currentInstance != null)
            {
                currentInstance.Projectile.Kill();
                currentInstance = this;
            }
            else
            {
                currentInstance = this;
            }
        }

        public override void Kill(int timeLeft = 0)
        {
            base.Kill(0);
            currentInstance = null;
        }
    }
}