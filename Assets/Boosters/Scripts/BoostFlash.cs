public class BoostFlash : Boost
{
    private float previousSpeed;

    protected override void ApplyBoost()
    {
            previousSpeed = lastShipHitted.GetComponentInChildren<MovementBehaviour>().speed;

            lastShipHitted.GetComponentInChildren<MovementBehaviour>().speed *= 1.5f;
            
            base.ApplyBoost();
    }

    protected override void RemoveBoost()
    {
        lastShipHitted.GetComponentInChildren<MovementBehaviour>().speed = previousSpeed;
        
        base.RemoveBoost();
    }
}
