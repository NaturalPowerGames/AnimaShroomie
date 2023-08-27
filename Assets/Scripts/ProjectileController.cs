using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    private Vector3 direction;

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
