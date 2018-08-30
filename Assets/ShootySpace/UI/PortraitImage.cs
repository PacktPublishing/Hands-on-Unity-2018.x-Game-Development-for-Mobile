using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;

namespace MyCompany.ShootySpace.UI
{
	public class PortraitImage : MonoBehaviour
	{
		private string address = "IconA";

		private void Start()
		{
			Image img = GetComponent<Image>();
			Sprite s = null;
			Addressables.Instantiate<Sprite>(address).Completed += (o) =>
			{
				s = o.Result;
				img.sprite = s;
			};
		}
	}
}
