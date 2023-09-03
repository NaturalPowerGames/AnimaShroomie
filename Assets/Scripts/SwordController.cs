using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordController : MonoBehaviour, IDealsDamageToEnemies, IKnockback
{
	public float damage;
	public Vector3 knockbackForce;
	public float Damage()
	{
		return damage;
	}

	public Vector3 KnockbackForce()
	{
		return knockbackForce;
	}
}
