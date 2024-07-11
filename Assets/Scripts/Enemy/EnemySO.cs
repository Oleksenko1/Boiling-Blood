using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Enemy")]
public class EnemySO : ScriptableObject
{
    [SerializeField] string stringName;
    [SerializeField] Sprite sprite;
    [SerializeField] Transform prefab;
}
