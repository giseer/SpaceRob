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
    }

    public void ResetShip()
    {
        GetComponentInChildren<SpriteRenderer>().color = Color.white;
    }
    
    private void OnDisable()
    {
        newControls.onMove.RemoveListener(mover.Move);
        newControls.onShoot.RemoveListener(shooter.Shoot);
    }
}
