using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/PlayerAtackTypeList")]
public class PlayerAtackTypesListSO : ScriptableObject
{
    [SerializeField] public List<PlayerAtackTypesSO> list;
}
