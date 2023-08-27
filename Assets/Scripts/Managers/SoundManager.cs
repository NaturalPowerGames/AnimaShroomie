using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource SFXAudioSource;
	public AudioClip[] clips;

	private void Awake()
	{
        SFXAudioSource = GetComponent<AudioSource>();
	}

	private void OnEnable()
	{
		GameplayEvents.OnSFXRequested += OnCoinSoundFXRequested;
	}

	private void OnDisable()
	{
		GameplayEvents.OnSFXRequested -= OnCoinSoundFXRequested;
	}

	private void OnCoinSoundFXRequested(SFX sfx)
	{
		SFXAudioSource.PlayOneShot(clips[(int)sfx]);
	}
}
