using MyCompany.GameFramework.Pooling;
using UnityEngine;

namespace MyCompany.ShootySpace.Enemies
{
	public class EnemySpawnController : MonoBehaviour
	{
		private ObjectPool enemyPool;

		private void Awake()
		{
			enemyPool = new ObjectPool(Resources.Load<GameObject>("enemy"), 5);
		}
	}
}
