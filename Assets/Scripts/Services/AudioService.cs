using UnityEngine;
using System.Collections;

namespace MiniClip.Challenge.Service
{
	public class AudioService : MonoBehaviour
	{

		#region Gameplay Spesific
		public AudioClip shapePlaceSound;
		public AudioClip explosionSound;
		public AudioClip blockSpawnSound;
		#endregion

		#region Audio Sources Fields
		public AudioSource musicSource;
		public AudioSource soundSource;

		public AudioClip gameMusic;
		public AudioClip uiClick;
		public AudioClip winSound;
		public AudioClip loseSound;
		public AudioClip popUpOpen;
		public AudioClip popUpClose;

		#endregion




		#region Sound FX Methods
		public void PlayLoseSound()
		{
			StopGameMusic();
			soundSource.clip = loseSound;
			soundSource.Play();
		}

		public void PlayUIClick()
		{
			soundSource.clip = uiClick;
			soundSource.Play();
		}

		public void PlayWinSound()
		{
			StopGameMusic();
			soundSource.clip = winSound;
			soundSource.Play();
		}

		public void PlaySplashScreenSound()
		{

		}

		public void PlayPopUpOpenSound()
		{

		}

		public void PlayPopUpCloseSound()
		{

		}

		public void PlayShapePlaceSound()
		{
			soundSource.PlayOneShot(shapePlaceSound);
		}

		public void PlayExplosionSound()
		{
			soundSource.PlayOneShot(explosionSound);
		}

		public void PlayBlockSpawnSound()
		{
			soundSource.clip = blockSpawnSound;
			soundSource.Play();
		}

		public void SetSoundFxVolume(float value)
		{
			float temp = value + soundSource.volume;
			if (temp < 0 || temp > 1)
				return;
			else
				soundSource.volume += value;
		}
		#endregion

		#region Music Methods
		public void PlayGameMusic()
		{
			musicSource.clip = gameMusic;
			musicSource.Play();
		}

		public void StopGameMusic()
		{
			musicSource.Stop();
		}

		public void SetSoundMusicVolume(float value)
		{
			float temp = value + musicSource.volume;
			if (temp < 0 || temp > 1)
				return;
			else
				musicSource.volume += value;
		}
		#endregion

	}
}