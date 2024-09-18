using UnityEngine;

public class Ovni : MonoBehaviour
{
    private Vector3 dir;
    private IAMovement mvb;

    // Start is called before the first frame update

    private void Start()
    {
        mvb = GetComponent<IAMovement>();
    }

    // Update is called once per frame
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