public class BoostFlash : Boost
{
    private float previousSpeed;

    protected override void ApplyBoost()
    {
            previousSpeed = lastShipHitted.GetComponentInChildren<Mover>().speed;

            lastShipHitted.GetComponentInChildren<Mover>().speed *= 2f;
            
            base.ApplyBoost();
    }

    protected override void RemoveBoost()
    {
        lastShipHitted.GetComponentInChildren<Mover>().speed = previousSpeed;
        
        base.RemoveBoost();
    }
}
