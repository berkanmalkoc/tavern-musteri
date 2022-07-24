using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshscript : MonoBehaviour
{
    private Transform movePositionTransform;
    bool target;
    
    public GameObject[] blueObjects;
    int i;

    float distanceEnemy;
  
    private NavMeshAgent navMeshAgent;

    private void Awake()
    {
        i = 0;
        navMeshAgent = GetComponent<NavMeshAgent>();
        
    }

    private void Update()
    {
        if(blueObjects==null)
        EnemiesFinder();

        if (blueObjects != null)
        {
            if (target == false)
            {
                EnemiesFinder();

            }
            else
            {
                if (blueObjects[i] == null)
                {
                    EnemiesFinder();
                }
                else
                {
                    distanceEnemy = Vector3.Distance(transform.position, blueObjects[i].transform.position);

                    if (distanceEnemy > 1)
                        EnemyFollow();
                    else if (distanceEnemy <= 1)
                        AttackActive();
                }
                
            }

        }
            
    }

   
    void EnemiesFinder()
    {
            blueObjects = GameObject.FindGameObjectsWithTag("Blue");
       
            movePositionTransform = blueObjects[i].transform;
        
            

            BlueObject blueObjectScript = blueObjects[i].GetComponent<BlueObject>();
            if (blueObjectScript.atacking == true)
            {
                blueObjects = null;
                i++;
                target = false;
                return;
            }
            else
            {
                target = true;
                blueObjectScript.atacking = true;
            }
        
    }
    void EnemyFollow()
    {
        
            navMeshAgent.destination = movePositionTransform.position;
       
    }

    void AttackActive()
    {
        Debug.Log("Attack!!");
    }
    
}
