using UnityEngine;

public class CameraChecker : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        var postrans = Camera.main.WorldToViewportPoint(transform.position);
        if (postrans.x < -0.5 || postrans.x > 1.5 || postrans.y < -0.5 || postrans.y > 1.5)
            Destroy(gameObject);
    }

    // Update is called once per frame
    private void Update()
    {
    }
}