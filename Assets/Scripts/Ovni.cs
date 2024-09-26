using UnityEngine;

public class Ovni : MonoBehaviour
{
    [HideInInspector] public Vector3 dir;
    private IAMovement mvb;

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
}