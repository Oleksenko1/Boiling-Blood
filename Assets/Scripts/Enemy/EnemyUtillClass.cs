using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUtillClass : MonoBehaviour
{
    public static Vector3 CalculateHitPoint(Transform hitPoint, Collider2D enemyPos)
    {
        float xPosition = Mathf.Clamp(hitPoint.position.x,
            enemyPos.bounds.min.x,
            enemyPos.bounds.max.x);
        float yPosition = Mathf.Clamp(hitPoint.position.y,
            enemyPos.bounds.min.y,
            enemyPos.bounds.max.y);

        Vector3 hitPosition = new Vector3(xPosition, yPosition, 0);
        return hitPosition;
    }
}
