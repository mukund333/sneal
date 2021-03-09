using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class AudioMixerController : MonoBehaviour
{
	public AudioMixer masterMixer;
	public float sfxLvl;
	public float musicLvl;
	
	public bool isActive=false;
	
  
    void Update()
    {
			if(isActive == true)
			{
				ClearVolume();
			}
    }
	
	public void SetSfxLevel(float sfxLvl)
	{
		masterMixer.SetFloat("soundEffectVol",sfxLvl);
	}
	
	public void SetMusicLevel(float musicLvl)
	{
		masterMixer.SetFloat("musicVol",musicLvl);
	}
	
	public void ClearVolume()
	{
		masterMixer.ClearFloat("musicVol");
	}
}
