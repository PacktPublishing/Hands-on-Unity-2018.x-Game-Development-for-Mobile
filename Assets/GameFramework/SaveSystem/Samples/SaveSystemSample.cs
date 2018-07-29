using UnityEngine;

namespace MyCompany.GameFramework.SaveSystem.Samples
{
	public class SaveSystemSample : MonoBehaviour
	{
#pragma warning disable 0414
		private SaveSystem saver;
#pragma warning restore 0414
		
		private void Awake()
		{
			saver = new SaveSystem(new DefaultFileWriter(), new DefaultFileReader());
			/* Test for saving */
//			string o = "hello";
//			saver.Save(o);
			
			/* Test for loading */
//			string s = saver.Load<string>();
//			Debug.Log(s);
		}
	}
}
