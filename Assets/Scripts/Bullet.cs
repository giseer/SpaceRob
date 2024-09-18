using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 dir;
    private IAMovement mvb;

    private void Start()
    {
        mvb = GetComponentInChildren<IAMovement>();
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
}