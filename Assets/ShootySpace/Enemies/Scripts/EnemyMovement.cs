using UnityEngine;

namespace MyCompany.ShootySpace.Enemies
{
	public class EnemyMovement : MonoBehaviour
	{
		[SerializeField] private Vector3 movementDirection;
		[SerializeField] private float movementSpeed;
		private Camera camera;
		private Vector3 lowerBoundMarker;

		private void Update()
		{
			camera = Camera.main;
			transform.Translate(movementDirection * movementSpeed * Time.deltaTime);
			lowerBoundMarker = new Vector3(0, 0, camera.transform.position.y);
			CheckBounds();
		}

		private void CheckBounds()
		{
			if (transform.position.z < camera.ScreenToWorldPoint(lowerBoundMarker).z)
			{
				
			}
		}
	}
}
