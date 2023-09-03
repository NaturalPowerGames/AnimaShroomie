using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour, IDealsDamageToEnemies
{
    private Vector3 direction;
    public float damage;
    public float Damage()
    {
        return damage;
    }

    private void Update()
    {
        transform.position += direction * 0.1f;
    }

    public void Initialize(Vector3 rotation, Vector3 direction)
	{
        transform.localEulerAngles = rotation;
        this.direction = direction;
        Destroy(gameObject, 1f);
	}

	
}
