using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyControlScript : MonoBehaviour
{
    private UnityEngine.AI.NavMeshAgent agent;
    private Animator anim;
    public double TargetingDist = 3;

    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        anim = gameObject.GetComponentInChildren<Animator>();
    }

    void Update()
    {
        GameObject[] units = GameObject.FindGameObjectsWithTag("Unit");
        bool UnitNear = false;
        foreach (var unit in units)
        {
            Vector3 dist = unit.transform.position - agent.transform.position;
            if (dist.magnitude < TargetingDist)
            {
                UnitNear = true;
                agent.SetDestination(unit.transform.position);
                if (dist.magnitude < 1) {
                    anim = unit.GetComponentInChildren<Animator>();
                    StartCoroutine(waiter(unit));
                }
                break;
            }

        }
        if (!UnitNear)
        {
            agent.SetDestination(GameObject.Find("Target").transform.position);
        }
    }
    IEnumerator waiter(GameObject unit)
    {
        anim.SetInteger("AnimationPar", 4);
        yield return new WaitForSeconds(0.7f);
        Destroy(unit);
    }

}
