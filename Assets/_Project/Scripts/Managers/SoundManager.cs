using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public static SoundManager _instance;
	
	public AudioMixer mixer;

	public SoundGroup[] sounds;

	
	
	
	public static SoundManager instance
	{
		get
		{
			if (SoundManager._instance == null)
			{
				SoundManager._instance = UnityEngine.Object.FindObjectOfType<SoundManager>();
			}
			return SoundManager._instance;
		}
	}

	public void PlayClip(string SoundName, float pos)
	{
		for (int i = 0; i < this.sounds.Length; i++)
		{
			if (this.sounds[i].soundName == SoundName && Time.unscaledTime - this.sounds[i].timeSinceLastPlay > 0.05f)
			{
				Sfx component = PoolManager.instance.GetObject("Sfx", base.transform.position, Quaternion.identity).GetComponent<Sfx>();
				component.InitSfx(this.sounds[i].clips[UnityEngine.Random.Range(0, this.sounds[i].clips.Length)], UnityEngine.Random.Range(this.sounds[i].pitchRange.x, this.sounds[i].pitchRange.y), this.sounds[i].vol, pos, this.sounds[i].mixer);
				this.sounds[i].timeSinceLastPlay = Time.unscaledTime;
			}
		}
	}

	public void PlayClipPitched(string SoundName, float pos, float pitch)
	{
		for (int i = 0; i < this.sounds.Length; i++)
		{
			if (this.sounds[i].soundName == SoundName)
			{
				//Sfx component = PoolManager.instance.GetObject("Sfx", base.transform.position, Quaternion.identity).GetComponent<Sfx>();
				//component.InitSfx(this.sounds[i].clips[UnityEngine.Random.Range(0, this.sounds[i].clips.Length)], pitch, this.sounds[i].vol, pos, this.sounds[i].mixer);
			}
		}
	}

	public void PlayClipNoPan(string SoundName)
	{
		for (int i = 0; i < this.sounds.Length; i++)
		{
			if (this.sounds[i].soundName == SoundName && Time.unscaledTime - this.sounds[i].timeSinceLastPlay > 0.05f)
			{
				//Sfx component = PoolManager.instance.GetObject("Sfx", base.transform.position, Quaternion.identity).GetComponent<Sfx>();
				//component.InitSfxNoPan(this.sounds[i].clips[UnityEngine.Random.Range(0, this.sounds[i].clips.Length)], UnityEngine.Random.Range(this.sounds[i].pitchRange.x, this.sounds[i].pitchRange.y), this.sounds[i].vol, this.sounds[i].mixer);
				//this.sounds[i].timeSinceLastPlay = Time.unscaledTime;
			}
		}
	}
}
