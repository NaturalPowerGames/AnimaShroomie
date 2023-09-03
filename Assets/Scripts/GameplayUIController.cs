using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class GameplayUIController : MonoBehaviour
{
	public TextMeshProUGUI coinText, healthText, announcementText;
	public Button coinSoundButton, spawnEnemyButton, spawnPatrolEnemy;
	private Coroutine announcementWait;

	private void Awake()
	{
		SetupButtons();
	}

	private void OnEnable()
	{
		GameplayEvents.OnPlayerHealthChanged += OnPlayerHealthChanged;
		GameplayEvents.OnCoinTotalChanged += OnCoinTotalChanged;
		UIEvents.OnAnnouncementRequested += OnAnnouncementRequested;
	}

	private void OnAnnouncementRequested(string announcement, float duration)
	{
		announcementText.text = announcement;
		if(announcementWait != null)
		{
			StopCoroutine(announcementWait);
		}
		announcementWait = StartCoroutine(RemoveAnnouncement(duration));
	}

	private IEnumerator RemoveAnnouncement(float duration)
	{
		yield return new WaitForSeconds(duration);
		announcementText.text = "";
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
		spawnPatrolEnemy.onClick.AddListener(() =>
		{
			SpawnEvents.OnPatrollingEnemyRequested?.Invoke(0, 0);
		});
	}

}
