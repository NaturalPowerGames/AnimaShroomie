using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CoinData : ScriptableObject
{
    [LabeledArray(typeof(CoinType))]
    public GameObject[] coins;
    public int amountToSpawn;
}
