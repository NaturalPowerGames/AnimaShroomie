using UnityEngine;

public class CoinSpawnerController : MonoBehaviour
{
    public CoinData coinData;

	private void Awake()
	{
		SpawnCoin(CoinType.Blue);
	}

	private void SpawnCoin(CoinType coinType)
	{
		Instantiate(coinData.coins[(int)coinType]);
	}

	//Playerprefs showcase
	private void CollectCoin(int amount)
	{
		if (PlayerPrefs.HasKey("coins"))
		{
			int coinAmount = PlayerPrefs.GetInt("coins");
			PlayerPrefs.SetInt("coins", coinAmount + amount);
		}
		else
		{
			PlayerPrefs.SetInt("coins", amount);
		}
		//keys
		PlayerPrefs.SetString("username", "name" /*inputText.text*/); //first scene
		//text.text = PlayerPrefs.GetString("username"); //second scene
	}
}
