using System.Collections.Generic;
using UnityEngine;

public class DamageBehaviour : MonoBehaviour
{
    [SerializeField] private int damage;
    
    [SerializeField] private List<string> layersToDamage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        foreach (string layerToDamage in layersToDamage)
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer(layerToDamage))  
            {
                collision.gameObject.GetComponent<HealthBehaviour>().Hurt(damage);   
            }    
        }
    }
}