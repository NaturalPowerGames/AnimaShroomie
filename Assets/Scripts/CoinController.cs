using System;
using UnityEngine;

public class CoinController : MonoBehaviour
{
	public Coin coinInfo;

	private void OnTriggerEnter(Collider other)
	{
		if (other.GetComponent<PlayerController>() != null)
		{
			PickupCoin();
		}
	}

	private void PickupCoin()
	{
		//something with coinInfo.CurrencyAmount
		GameplayEvents.OnCoinPickedUp?.Invoke(coinInfo.CurrencyAmount);
		GameplayEvents.OnSFXRequested?.Invoke(coinInfo.CoinSFX);
	}
}
