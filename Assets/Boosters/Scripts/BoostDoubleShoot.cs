using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostDoubleShoot : Boost
{
    protected override void ApplyBoost()
    {
        lastShipHitted.GetComponentInChildren<Shooter>().doubleShootActivated = true;
        
        base.ApplyBoost();
    }

    protected override void RemoveBoost()
    {
        lastShipHitted.GetComponentInChildren<Shooter>().doubleShootActivated = false;
        
        base.RemoveBoost();
    }
}
