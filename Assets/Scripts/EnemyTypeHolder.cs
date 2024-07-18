using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTypeHolder : MonoBehaviour
{
    [SerializeField] private EnemySO enemyType;
    public EnemySO GetEnemyType()
    {
        return enemyType;
    }
}
