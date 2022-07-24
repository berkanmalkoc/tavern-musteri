using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodManager : MonoBehaviour
{
    private FoodTypeListSO foodTypeList;
    private FoodTypeSO foodType;
    private Camera mainCamera;
    public int foodIndexNumber;
    
    public Transform tableTransform;

    void Start()
    {
        mainCamera = Camera.main;

        foodTypeList = Resources.Load<FoodTypeListSO>(typeof(FoodTypeListSO).Name);
        foodType = foodTypeList.list[foodIndexNumber];
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            
        }
    }

    public void FoodOnTable(int q)
    {
        Instantiate(foodType.foodPrefab, tableTransform.position, Quaternion.identity);
    }
}
