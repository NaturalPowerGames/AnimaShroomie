using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public int totalCoins = 0;

	private void OnEnable()
	{
		GameplayEvents.OnCoinPickedUp += OnCoinPickedUp;
	}

	private void OnCoinPickedUp(int amount)
	{
		totalCoins += amount;
		GameplayEvents.OnCoinTotalChanged?.Invoke(totalCoins);
	}
}
