using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SwampAttack;

public class Pistol : Weapon
{
    
    public override void Shot(Transform shotPoint)
    {
        Instantiate(Bullet, shotPoint.position, Quaternion.identity);
    }
}
