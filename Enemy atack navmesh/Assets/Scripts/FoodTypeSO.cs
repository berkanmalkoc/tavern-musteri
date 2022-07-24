using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/FoodType")]
public class FoodTypeSO : ScriptableObject
{
    public string nameString;
    public Transform foodPrefab;
    public int parcaSayisi;
    public GameObject foodIcon;
    public int fiyat;
    public int maliyet;
    public int prestij;
    public int miktar;


}
