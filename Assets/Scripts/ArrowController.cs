using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour, IDealsDamageToEnemies
{
    public float damage;

	public float Damage()
	{
		return damage;
	}
}
