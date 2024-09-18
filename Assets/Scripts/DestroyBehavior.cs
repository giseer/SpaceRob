using UnityEngine;

public class DestroyBehavior : MonoBehaviour
{
    public GameObject explosionPrefab;


    public void DestroyObject()
    {
        if (explosionPrefab != null) Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }


    public void DisableObject()
    {
        if (explosionPrefab != null) Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        gameObject.SetActive(false);
    }
}