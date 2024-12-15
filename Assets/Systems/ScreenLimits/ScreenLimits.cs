using UnityEngine;

public class ScreenLimits : MonoBehaviour
{
    BoxCollider2D boxCollider;

    private void Awake()
    {
        boxCollider = GetComponentInChildren<BoxCollider2D>();
        ResizeCollider2DToScreenSize(boxCollider);
    }

    public void ResizeCollider2DToScreenSize(BoxCollider2D boxColliderToResize, float ofsetX = 0, float ofsetY = 0)
    {
        if (Camera.main == null)
        {
            Debug.LogError("Camera.main is null");
            return;
        }

        Camera mainCamera = Camera.main;
        
        Vector2 topLeft = mainCamera.ViewportToWorldPoint(new Vector2(0, 1));
        Vector2 bottomRight = mainCamera.ViewportToWorldPoint(new Vector2(1, 0));
        
        boxColliderToResize.size = new Vector2(
            (bottomRight.x - topLeft.x) + ofsetX,
            (topLeft.y - bottomRight.y) + ofsetY);
    }

    public Vector2 GetScreenLimitsSize()
    {
        return boxCollider.size;
    }
}
