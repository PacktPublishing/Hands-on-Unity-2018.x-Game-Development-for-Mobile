using System.Collections.Generic;
using UnityEngine;

namespace MyCompany.GameFramework.Pooling
{
	public class ObjectPool
	{
		private Stack<GameObject> pooledItems;
		
		private GameObject prefab;
		private bool shouldAutoResize;
		
		public ObjectPool(GameObject prefab, int size, bool shouldAutoResize = false)
		{
			this.prefab = prefab;
			this.shouldAutoResize = shouldAutoResize;

			PopulatePool(size, prefab);
		}
		
		private void PopulatePool(int size, GameObject gameObject)
		{
			pooledItems = new Stack<GameObject>();
			for (int i = 0; i < size; ++i)
			{
				GameObject go = GameObject.Instantiate(gameObject);
				PooledItem pooledItem = go.AddComponent<PooledItem>();
				pooledItem.SetPool(this);
				go.SetActive(false);
				pooledItems.Push(go);
			}
		}

		public GameObject InstantiateFromPool(Transform postion)
		{
			GameObject next = null;
			if (pooledItems.Count > 0)
			{
				next = pooledItems.Pop();
				next.transform.position = postion.position;
				next.SetActive(true);
				return next;
			}

			if (!shouldAutoResize)
			{
				return null;
			}
			next = GameObject.Instantiate(prefab, postion.position, Quaternion.identity);
			PooledItem item = next.AddComponent<PooledItem>();
			item.SetPool(this);
			return next;
		}

		public void ReturnToPool(GameObject go)
		{
			go.transform.position = Vector3.zero;
			pooledItems.Push(go);
		}
	}
}
