using UnityEngine;

public class DeadLineScreenBorder : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] ScreenLimits screenLimits;
    private BoxCollider2D boxCollider;

    [Header("DeadLine Values")] 
    [SerializeField] private float deadLineBorderOffsetFromScreen; 
    
    private void Awake()
    {
        boxCollider = GetComponentInChildren<BoxCollider2D>();
    }

    private void Start()
    {
        screenLimits.ResizeCollider2DToScreenSize(boxCollider, deadLineBorderOffsetFromScreen, deadLineBorderOffsetFromScreen);
    }

    public void CleanEnemiesOnScreen()
    {
        boxCollider.enabled = false;
        boxCollider.enabled = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Boost") && !other.CompareTag("player"))
        {
            Destroy(other.gameObject);
        }
    }
}
