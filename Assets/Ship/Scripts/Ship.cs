using UnityEngine;

public class Ship : MonoBehaviour
{
    [SerializeField] private NewControls newControls;
    [SerializeField] private Shooter shooter;
    [SerializeField] private Mover mover;

    private void OnEnable()
    {
        newControls.onMove.AddListener(mover.Move);
        newControls.onShoot.AddListener(shooter.Shoot);
        
        // Vector3 postrans = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.5f));
        // postrans.z = 0;
        // transform.position = postrans;
        
    }
    
    private void OnDisable()
    {
        newControls.onMove.RemoveListener(mover.Move);
        newControls.onShoot.RemoveListener(shooter.Shoot);
    }
}
