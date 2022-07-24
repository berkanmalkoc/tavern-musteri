using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/FoodTypeList")]

public class FoodTypeListSO : ScriptableObject
{

    public List<FoodTypeSO> list;

}