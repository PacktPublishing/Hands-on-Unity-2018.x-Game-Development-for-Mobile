using MyCompany.GameFramework.InputManagement.Interfaces;
using UnityEngine;

namespace MyCompany.ShootySpace.InputManagement
{
	/// <summary>
	/// Input handler for mouse (or in our case, touch) input.
	/// Implements the IMouseInputHandler, and provides all the specific business logic
	/// for making this input type work properly.
	/// </summary>
	public class MouseFollowInputHandler : IMouseInputHandler
	{
		private Camera referenceCamera;
		
		private float verticalBound;
		private float horizontalBound;
		
		private Vector3 rawTouchInput;
		
		public MouseFollowInputHandler(Camera referenceCamera)
		{
			this.referenceCamera = referenceCamera;
			SetBounds();
		}

		private void SetBounds()
		{
			float screenHeight = referenceCamera.pixelHeight;
			float screenWidth = referenceCamera.pixelWidth;

			horizontalBound = referenceCamera.ScreenToWorldPoint(new Vector3(screenWidth, 0, referenceCamera.farClipPlane)).x;
			verticalBound = referenceCamera.ScreenToWorldPoint(new Vector3(0, screenHeight, referenceCamera.farClipPlane)).z;
		}
		
		public Vector2 GetRawPosition()
		{
			return Input.mousePosition;
		}

		public Vector2 GetInput()
		{
			// X
			rawTouchInput = GetRawPosition();
			rawTouchInput.x = rawTouchInput.x / referenceCamera.pixelWidth;
			rawTouchInput.x = Mathf.Lerp(-horizontalBound, horizontalBound, rawTouchInput.x);
			
			// Z -- We convert y to Z because our camera is facingh down, not forward.
			rawTouchInput.y = rawTouchInput.y / referenceCamera.pixelHeight;
			rawTouchInput.y = Mathf.Lerp(-verticalBound, verticalBound, rawTouchInput.y);
			return rawTouchInput;
		}
	}
}
