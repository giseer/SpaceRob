using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBehaviour : MonoBehaviour
{
    public float damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<HealthBehaviour>().Hurt(damage);
        //Destroy(collision.gameObject);
    }

}

