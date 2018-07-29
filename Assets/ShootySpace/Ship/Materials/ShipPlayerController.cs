using MyCompany.GameFramework.InputManagement.Interfaces;
using MyCompany.ShootySpace.InputManagement;
using UnityEngine;

public class ShipPlayerController : MonoBehaviour
{
	[SerializeField]
	private Transform playerTransform;
	private Vector3 input;
	private IInputManager inputManager;
	
	void Start ()
	{
		inputManager = new PlayerInputManager(
			new PlayerInputBindings(),
			new MouseFollowInputHandler(Camera.main)
			);
	}

	void Update()
	{
		input = inputManager.GetMouseVector();
		input.z = input.y;
		input.y = 0;
		playerTransform.transform.position = input;
	}
}
