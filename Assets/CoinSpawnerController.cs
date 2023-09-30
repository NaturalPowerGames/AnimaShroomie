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
}
