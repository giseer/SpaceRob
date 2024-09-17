using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostDoubleShoot : Boost
{
    protected override void ApplyBoost()
    {
        lastShipHitted.GetComponentInChildren<ShootingBehavior>().doubleShootActivated = true;
        
        base.ApplyBoost();
    }

    protected override void RemoveBoost()
    {
        lastShipHitted.GetComponentInChildren<ShootingBehavior>().doubleShootActivated = false;
        
        base.RemoveBoost();
    }
}
