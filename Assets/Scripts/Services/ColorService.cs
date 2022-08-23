using UnityEngine;
using System.Collections;

namespace MiniClip.Challenge.Service
{
	public class ColorService : MonoBehaviour
	{

		public ColorTheme activeTheme;

		public Color[] themePack_Pastel;
		public Color[] themePack_Gram;

		public Color TurnRandomColorFromTheme()
		{
			int rand = Random.Range(0, 6);
			Color temp;
			switch (activeTheme)
			{
				case ColorTheme.LIGHT:
					temp = themePack_Pastel[rand];
					break;
				case ColorTheme.DARK:
					temp = themePack_Gram[rand];
					break;
				default:
					temp = Color.black;
					break;
			}

			return temp;
		}
	}
}
