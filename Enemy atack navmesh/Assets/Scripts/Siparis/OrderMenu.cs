using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderMenu : MonoBehaviour
{
    private FoodTypeListSO foodTypeList;
    private FoodTypeSO foodType;
    public Transform tableTransform;


    int menuListNumber;
    [SerializeField] private Text nameOfOrder;

    // Start is called before the first frame update
    void Start()
    {

        foodTypeList = Resources.Load<FoodTypeListSO>(typeof(FoodTypeListSO).Name);
        

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            menuListNumber = Random.Range(0, foodTypeList.list.Count);
            foodType = foodTypeList.list[menuListNumber];
            nameOfOrder.text = foodType.nameString.ToString();
            Instantiate(foodType.foodPrefab, tableTransform.position, Quaternion.identity);
        }
    }
}
