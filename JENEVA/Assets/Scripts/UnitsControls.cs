using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class UnitsControls : MonoBehaviour
{
    private Camera mainCamera;
    private NavMeshAgent agent;
    private Animator anim;
    RaycastHit hit;
    bool SpeedFlag;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        agent = GetComponent<NavMeshAgent>();
        anim = gameObject.GetComponentInChildren<Animator>();
        SpeedFlag = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(mainCamera.ScreenPointToRay(Input.mousePosition), out hit))
            {
                anim.SetInteger("AnimationPar", 1);
                agent.SetDestination(hit.point);
            }
        }
        IfStopped();
        if (agent.velocity != new Vector3(0, 0, 0)) SpeedFlag = true;
    }
    void IfStopped()
    {
        if (agent.velocity == new Vector3(0, 0, 0) && SpeedFlag)
        {
            anim.SetInteger("AnimationPar", 0);
            SpeedFlag = false;
        }
    }
}
