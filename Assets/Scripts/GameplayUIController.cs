using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class GameplayUIController : MonoBehaviour
{
	public TextMeshProUGUI coinText, healthText;
	public Button coinSoundButton, spawnEnemyButton;

	private void Awake()
	{
		SetupButtons();
	}

	private void OnEnable()
	{
		GameplayEvents.OnPlayerHealthChanged += OnPlayerHealthChanged;
		GameplayEvents.OnCoinTotalChanged += OnCoinTotalChanged;
	}

	private void OnCoinTotalChanged(int total)
	{
		coinText.text = total.ToString();
	}

	private void OnPlayerHealthChanged(int health)
	{
		healthText.text = health.ToString();
	}

	private void SetupButtons()
	{
		coinSoundButton.onClick.AddListener(() =>
		{
			GameplayEvents.OnSFXRequested?.Invoke(SFX.Coin);
			GameplayEvents.OnCoinPickedUp?.Invoke(1);
		});
		spawnEnemyButton.onClick.AddListener(() =>
		{
			SpawnEvents.OnEnemySpawnRequested?.Invoke(0);
		});
	}

}
