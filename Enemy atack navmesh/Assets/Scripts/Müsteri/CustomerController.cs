using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerController : MonoBehaviour
{
    [SerializeField] private int[] numbers;
    [SerializeField] private List<GameObject> names = new List<GameObject>();

    private void Start()
    {
        StartCoroutine(CustomerSetActive());
    }
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            //Shuffle array: numbers
            numbers.Shuffle(6);
            //Shufle list: names
            names.Shuffle(6);

        }
        
    }


    IEnumerator CustomerSetActive()
    {
        while (true)
        {
            for (int i = 0; i < names.Count; i++)
            {
                BlueObject blueObjectScript = names[i].GetComponent<BlueObject>();
                blueObjectScript.customerActive = true;
                yield return new WaitForSecondsRealtime(5f);
            }
            
        }
        
        
    }
}
