using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class SoundGroup 
{

		public string soundName;

		public AudioClip[] clips;

		public AudioMixerGroup mixer;

		[Range(0f, 1f)]
		public float vol = 1f;

		public Vector2 pitchRange;

		public float timeSinceLastPlay;
}
