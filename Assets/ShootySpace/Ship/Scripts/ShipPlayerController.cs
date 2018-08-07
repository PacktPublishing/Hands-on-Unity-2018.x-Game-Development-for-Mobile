using MyCompany.GameFramework.Pooling;
using MyCompany.ShootySpace.Abilities;
using MyCompany.ShootySpace.Abilities.Interfaces;
using MyCompany.ShootySpace.InputManagement;
using UnityEngine;

namespace MyCompany.ShootySpace.Ship
{
	public class ShipPlayerController : MonoBehaviour
	{
		// Serialized members
		[SerializeField] private Transform playerTransform;
	
		// Private members
		private Vector3 input;
		private PlayerInputManager inputManager;
		private IPlayerAbility shootAbility;
	
		void Start ()
		{
			//Setup Input
			inputManager = new PlayerInputManager(
				new PlayerInputBindings(),
				new MouseFollowInputHandler(Camera.main)
			);
		
			//Setup Shooting
			ObjectPool pool = new ObjectPool(Resources.Load<GameObject>("projectile"), 20, true);
			shootAbility = new ShootAbility(transform, pool);
			inputManager.AddActionToBinding("shoot", OnShoot);
		}

		private void OnShoot()
		{
			shootAbility.Use();
		}

		void Update()
		{
			inputManager.CheckForInput();
			input = inputManager.GetMouseVector();
			input.z = input.y;
			input.y = 0;
			playerTransform.transform.position = input;
		}
	}
}
