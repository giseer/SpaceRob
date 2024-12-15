using UnityEngine;
using UnityEngine.Events;

public class Asteroid : MonoBehaviour
{
    private Vector3 dir;

    private IAMovement mvb;
    
    [HideInInspector] public UnityEvent<Asteroid> OnAsteroidDestroyed;

    private void Start()
    {
        mvb = GetComponent<IAMovement>();
    }
    
    private void Update()
    {
        mvb.Move(dir);
    }

    public void SetDirection(Vector3 d)
    {
        dir = d;
        dir.Normalize();
    }

    private void OnDestroy()
    {
        OnAsteroidDestroyed.Invoke(this);
    }
}