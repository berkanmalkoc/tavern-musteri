using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BlueObject : MonoBehaviour
{
    public bool atacking=false;

    [SerializeField] Transform tablePoisition;
    public GameObject[] tableObjects;
    [SerializeField] int i;
    [SerializeField]private bool targetTableEmpty;
    public bool customerActive;

    private NavMeshAgent naveMeshAgent;

    private void Awake()
    {
        naveMeshAgent = GetComponent<NavMeshAgent>();
        customerActive = false;
    }

    private void Update()
    {

        if (customerActive)
        {
            if (tableObjects == null)
                TableFinder();
            else if (tableObjects != null)
            {
                if (targetTableEmpty == true)
                {
                    GoToTable();
                }
                else
                {
                    TableFinder();
                }

            }
            if (i == tableObjects.Length)
            {
                i = 0;
            }
        }
        
        
    }

    void TableFinder()
    {
        tableObjects = GameObject.FindGameObjectsWithTag("table");

        tablePoisition = tableObjects[i].transform;



        TableSc tableObjectScript = tableObjects[i].GetComponent<TableSc>();

        if (tableObjectScript.isFull == true)
        {
           
            i++;
            targetTableEmpty = false;
            return;
        }
        else
        {
            tableObjectScript.isFull = true;
            targetTableEmpty = true;
            GoToTable();

        }
        if (i == tableObjects.Length)
            i = 0;

    }

    void GoToTable()
    {
        naveMeshAgent.destination = tablePoisition.position;
    }
}
