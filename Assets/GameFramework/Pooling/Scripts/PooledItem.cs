using UnityEngine;

namespace MyCompany.GameFramework.Pooling
{
	public class PooledItem : MonoBehaviour
	{
		private ObjectPool objectPool;

		public void SetPool(ObjectPool objectPool)
		{
			this.objectPool = objectPool;
		}

		public void OnDisable()
		{
			objectPool.ReturnToPool(gameObject);
		}
	}
}
