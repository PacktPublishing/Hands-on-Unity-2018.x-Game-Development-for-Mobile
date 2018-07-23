using System;
using System.Collections.Generic;
using MyCompany.GameFramework.InputManagement;
using MyCompany.GameFramework.InputManagement.Interfaces;
using UnityEngine;

namespace MyCompany.ShootySpace.InputManagement
{
	/// <summary>
	/// Wraps all the different input mechanisms.
	/// Provides a mechanism to check all inputBindings.
	/// Also provides a way to bind an action to an InputBinding.
	/// </summary>
	public class PlayerInputManager : IInputManager 
	{
		protected InputBindings inputBindings;
		protected IMouseInputHandler touchInputHandler;
		protected Dictionary<string, Action> actionMap = new Dictionary<string, Action>();

		public PlayerInputManager(InputBindings inputBindings, IMouseInputHandler touchInputHandler)
		{
			this.inputBindings = inputBindings;
			this.touchInputHandler = touchInputHandler;
		}
		
		public void AddActionToBinding(string binding, Action action)
		{
			actionMap.Add(binding, action);
		}

		public float GetAxis(string axisName)
		{
			throw new NotImplementedException();
		}

		public bool GetButton(string buttonName)
		{
			throw new NotImplementedException();
		}

		public Vector2 GetMouseVector()
		{
			return touchInputHandler.GetInput();
		}
		
		public void CheckForInput()
		{
			foreach (var kvp in inputBindings.KeyBindings)
			{
				if (Input.GetKeyDown(kvp.Value))
				{
					Action action;
					actionMap.TryGetValue(kvp.Key, out action);
					if (action != null)
					{
						action.Invoke();
					}
				}
			}
		}
	}
}
