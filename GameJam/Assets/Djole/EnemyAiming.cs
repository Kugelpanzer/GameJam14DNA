using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAiming :  EnemyBase
{
    public GameObject Target;

    public void AimToTarget()
    {
       // transform.up = Target.transform.position;

        Vector3 vectorToTarget = Target.transform.position - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 100);
    }

    private void Update()
    {
        EnemyMove();
        ConstMove();
        ShootWeapon();
        InvTime();
        AimToTarget();
    }
}
