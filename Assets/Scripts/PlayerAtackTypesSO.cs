using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/PlayerAtackType")]
public class PlayerAtackTypesSO : ScriptableObject
{
    public enum TypeOfPunch
    {
        leftJab,
        leftLowKick,
        rightUppercut
    }

    public int damageAmount;
    public Transform prefab;
    public TypeOfPunch typeOfPunch;
}
