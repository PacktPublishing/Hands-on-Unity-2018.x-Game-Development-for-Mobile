using System.Collections;
using UnityEngine;

namespace MyCompany.ShootySpace.Projectiles
{
	public class Projectile : MonoBehaviour
	{
		[SerializeField] private Vector3 direction;
		[SerializeField] private float speed;
		[SerializeField] private float lifeTime;

		private void OnEnable()
		{
			StartCoroutine(SelfDestruct());
		}

		private void Update()
		{
			transform.Translate(direction * speed * Time.deltaTime);
		}
		
		private void OnTriggerEnter(Collider other)
		{
			gameObject.SetActive(false);
		}

		private IEnumerator SelfDestruct()
		{
			yield return new WaitForSeconds(lifeTime);
			gameObject.SetActive(false);
		}
	}
}
