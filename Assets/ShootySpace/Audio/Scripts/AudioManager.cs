using System.Collections.Generic;
using UnityEngine;

namespace MyCompany.ShootySpace.Audio
{
	public class AudioManager
	{
		private Dictionary<string, AudioSource> audioSources = new Dictionary<string, AudioSource>();

		/// <summary>
		/// Adds or replaces the provided AudioSource at key "name"
		/// </summary>
		/// <param name="name">Name of the audio source</param>
		/// <param name="source">The AudioSource to store for later use</param>
		public void AddAudioSource(string name, AudioSource source)
		{
			audioSources[name] = source;
		}

		/// <summary>
		/// Play the passed in audio clip via the selected audio source.
		/// </summary>
		/// <param name="source">The name of the audio source to play the sound through.</param>
		/// <param name="clip">The audio clip to play.</param>
		public void Play(string source, AudioClip clip)
		{
			AudioSource audioSource;
			if (!audioSources.TryGetValue(source, out audioSource))
			{
				Debug.LogFormat("No audio source named {0} could be found", source);
				return;
			}

			audioSource.clip = clip;
			audioSource.Play();
		}
	}
}
