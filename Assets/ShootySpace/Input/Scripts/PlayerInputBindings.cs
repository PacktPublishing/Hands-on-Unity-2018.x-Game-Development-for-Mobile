using MyCompany.GameFramework.InputManagement;
using UnityEngine;

namespace MyCompany.ShootySpace.InputManagement
{
	/// <summary>
	/// Binds a keycode to an action identifier/name.
	/// </summary>
	public class PlayerInputBindings : InputBindings 
	{
		protected override void SetupBindings()
		{
			base.SetupBindings();
			keyBindings.Add("shoot", KeyCode.Mouse0);
		}
	}
}
