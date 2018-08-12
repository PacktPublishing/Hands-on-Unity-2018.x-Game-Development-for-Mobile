using MyCompany.GameFramework.Pooling;
using MyCompany.ShootySpace.Abilities.Interfaces;
using MyCompany.ShootySpace.Audio;
using UnityEngine;

namespace MyCompany.ShootySpace.Abilities
{
    public class ShootAbility : IPlayerAbility
    {
        private Transform projectileSpawnLocation;
        private ObjectPool projectilePool;
        
        public ShootAbility(Transform projectileSpawnLocation, ObjectPool projectilePool)
        {
            this.projectileSpawnLocation = projectileSpawnLocation;
            this.projectilePool = projectilePool;
        }
        
        public void Use()
        {
            projectilePool.InstantiateFromPool(projectileSpawnLocation);
        }
    }
}
