﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(AudioSource))]
public class SFXManager : MonoBehaviour
{
	public bool isPlayer;

	AudioSource audioSource;
	public AudioClip[] clips;
	public string type;
	List<AudioSource> sources;
	[Range(0, 1)] public float chance = 1;

	[HideInInspector] public bool canPlayHappy;

	private void Awake()
	{
		audioSource = gameObject.GetComponent<AudioSource>();
		sources = new List<AudioSource>();
		canPlayHappy = true;
	}

	[ContextMenu("RemoveAllAudioSource")]
	public void RemoveAllAudioSource()
	{
		var audioSources = GetComponents<AudioSource>();
		for (int i = GetComponents<AudioSource>().Length - 1; i > 0; --i)
		{
			DestroyImmediate(audioSources[i]);
		}
	}

	[ExecuteAlways]
	public void Update()
	{

		if (sources != null)
		{
			for (int i = sources.Count - 1; i >= 0; i--)

			{
				if (sources[i] == null)
				{
					sources.RemoveAt(i);
					continue;
				}

				if (!sources[i].isPlaying)
				{
					Destroy(sources[i]);
					sources.RemoveAt(i);
				}
			}
		}
	}

	/// <summary>
	/// Play an SFX sound
	/// </summary>
	/// <param name="chance"> the chance of playing == > MUST be between (0,1)</param>
	public void SfxPlay(bool useChance = true, int random = -1, bool loop = false, bool hasRandomPitch = false)
	{
		if (useChance && UnityEngine.Random.Range(0f, 1f) > chance)
			return;

		else
			PlaySoundEffect(random, loop, hasRandomPitch);
	}


	public void SfxPlayDefault()
	{
		PlaySoundEffect(0, false, false);
	}

	public void PlaySFXRandom(bool loop = false, bool pitch = false)
	{
		if (UnityEngine.Random.Range(0f, 1f) > chance)
			return;

		PlaySoundEffect(-1, loop, pitch);

	}

	//public void PlayMoveSFX()
	//{
	//	if (isPlayer && GameManager.instance.player.isAlive)
	//		PlaySoundEffect(0, false);
	//}
	public void PlayPlayerSFX(bool loop = false)
	{
		if (isPlayer)
			PlaySoundEffect(-1, loop, false);
		else
			PlaySoundEffect(-1, loop, true);
	}

	
	public void PlayHappySFX()
	{
		if (isPlayer)
			return;
		if(canPlayHappy)
			PlaySoundEffect(-1, false, true);
	}
	/// <summary>
	/// 
	/// </summary>
	/// <param name="index"></param>
	public void PlaySFXOnValueChanged(int index)
	{
		PlaySoundEffect(index);
	}

	#region Tools

	/// <summary>
	/// Stop Soundeffect 
	/// </summary>
	/// <param name="random"> The index of Audio clip in List</param>
	public void SfxStop(int random)
	{
		if (sources.Count > 0)
		{
			/*foreach (var item in sources)
			{
				if (item == null)
					continue;
				if (item.clip == clips[random])
				{
					sources.Remove(item);
					Destroy(item);
				}
			}*/
			for (int i = sources.Count - 1; i >= 0; i--)
			{
				if (sources[i] == null)
					continue;
				if(sources[i].clip == clips[random])
                {
					Destroy(sources[i]);
					sources.RemoveAt(i);
                }
			}
		}
		
	}
	public void SfxStopDefault()
    {
		if (sources.Count > 0)
		{
			/*foreach (var item in sources)
			{
				if (item == null)
					continue;
				else
				{
					sources.Remove(item);
					Destroy(item);
				}
			}*/
			for (int i = sources.Count - 1; i >= 0; i--)
			{
				if (sources[i] == null)
					continue;
				else
				{
					Destroy(sources[i]);
					sources.RemoveAt(i);
				}
			}
		}
	}


	/// <summary>
	/// 
	/// </summary>
	/// <param name="random"></param>
	/// <param name="loop"></param>
	public void PlaySoundEffect(int random, bool loop = false,bool randomPitch = false)
	{
		if (clips.Length > 0)
		{
			if (random == -1)
			{
				AudioSource newSource = gameObject.AddComponent<AudioSource>();
				newSource.loop = loop;
				newSource.playOnAwake = false;
				newSource.outputAudioMixerGroup = audioSource.outputAudioMixerGroup;
				newSource.spatialBlend = audioSource.spatialBlend;
				newSource.maxDistance = audioSource.maxDistance * 3;
				newSource.volume = audioSource.volume;
				newSource.rolloffMode = AudioRolloffMode.Linear;
				if (randomPitch)
					newSource.pitch = (UnityEngine.Random.Range(-2, 2) > 0)
						? audioSource.pitch - (audioSource.pitch * UnityEngine.Random.Range(0, 0.2f))
						: audioSource.pitch + (audioSource.pitch * UnityEngine.Random.Range(0, 0.2f));
				else
					newSource.pitch = audioSource.pitch;
				newSource.clip = clips[UnityEngine.Random.Range(0, clips.Length)];

				sources.Add(newSource);
				newSource.Play();
			}
			else
			{
				AudioSource newSource = gameObject.AddComponent<AudioSource>();
				newSource.loop = loop;
				newSource.playOnAwake = false;
				newSource.outputAudioMixerGroup = audioSource.outputAudioMixerGroup;
				newSource.spatialBlend = audioSource.spatialBlend;
				newSource.maxDistance = audioSource.maxDistance * 3;
				newSource.volume = audioSource.volume;
				newSource.rolloffMode = AudioRolloffMode.Linear;
				if (randomPitch)
					newSource.pitch = (UnityEngine.Random.Range(-2, 2) > 0)
						? audioSource.pitch - (audioSource.pitch * UnityEngine.Random.Range(0, 0.2f))
						: audioSource.pitch - (audioSource.pitch * UnityEngine.Random.Range(0, 0.2f));
				else
					newSource.pitch = audioSource.pitch; 
				newSource.clip = clips[random];

				newSource.Play();
				sources.Add(newSource);
			}
		}
	}
	#endregion
}