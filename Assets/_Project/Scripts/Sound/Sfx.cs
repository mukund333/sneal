using System.Collections;
using UnityEngine;
using UnityEngine.Audio;


    public class Sfx : MonoBehaviour
    {
		public AudioSource source;

		public Transform cameraTransform;

		private void Awake()
		{
			this.source = base.GetComponent<AudioSource>();
			this.cameraTransform = UnityEngine.Object.FindObjectOfType<CameraFollow>().transform;
		}
		
		

		public void InitSfx(AudioClip sfx, float pitch, float vol, float pos, AudioMixerGroup audioMixerGroup)
		{
			this.source.clip = sfx;
			this.source.pitch = pitch;
			this.source.panStereo = (pos - this.cameraTransform.position.x) / 250f;
			this.source.outputAudioMixerGroup = audioMixerGroup;
			this.source.volume = vol;
			this.source.Play();
			base.StartCoroutine(this.Disable(sfx.length));
		}

		public void InitSfxNoPan(AudioClip sfx, float pitch, float vol, AudioMixerGroup audioMixerGroup)
		{
			this.source.clip = sfx;
			this.source.pitch = pitch;
			this.source.outputAudioMixerGroup = audioMixerGroup;
			this.source.volume = vol;
			this.source.Play();
			base.StartCoroutine(this.Disable(sfx.length));
		}

		private IEnumerator Disable(float time)
		{
			yield return new WaitForSeconds(time);
			base.gameObject.SetActive(false);
			yield break;
		}

	}
