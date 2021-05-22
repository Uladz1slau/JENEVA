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
    bool HaveObject;
    public float PickingDist = 1;
    GameObject ChosenItem;
    GameObject scene;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        agent = GetComponent<NavMeshAgent>();
        anim = gameObject.GetComponentInChildren<Animator>();
        HaveObject = false;
    }

    // Update is called once per frame
    void Update()
    {
        //передвижение и анимация движения
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButton(0))
        {
            if (Physics.Raycast(mainCamera.ScreenPointToRay(Input.mousePosition), out hit))
            {
                anim.SetInteger("AnimationPar", 1);
                agent.SetDestination(hit.point);
            }
        }
        IfStopped();

        //смена уровня
        if ((Input.GetKeyDown(KeyCode.L)))
        {
            GameObject[] scenes = GameObject.FindGameObjectsWithTag("StartScene");
            float dist = -1;
            foreach (GameObject item in scenes)
            {
                float curdist = (item.transform.position - gameObject.transform.position).magnitude;
                if (curdist < dist || dist == -1)
                {
                    scene = item;
                    dist = curdist;
                }
            }
            if (dist != -1 && dist < PickingDist)
            {
                scene.SendMessage("Load");
            }
        }

        //подбор предмета
        if ((Input.GetKeyDown(KeyCode.E)))
        {
            if (!HaveObject)
            {
                GameObject[] items = GameObject.FindGameObjectsWithTag("MobileObj");
                float dist = -1;
                foreach (GameObject item in items)
                {
                    float curdist = (item.transform.position - gameObject.transform.position).magnitude;
                    if (curdist < dist || dist == -1)
                    {
                        ChosenItem = item;
                        dist = curdist;
                    }
                }
                if (dist != -1 && dist < PickingDist)
                {
                    HaveObject = true;
                }               
            }
            else
            {
                //сброс предмета
                ChosenItem.transform.position = new Vector3(ChosenItem.transform.position.x, 0, ChosenItem.transform.position.z);
                HaveObject = false;
            }
        }
        //обновление позиции предмета
        if (HaveObject)
        {
            ChosenItem.transform.position = GameObject.FindGameObjectsWithTag("Arm")[0].transform.position;
        }

        
    }
    void IfStopped()
    {
        if ((agent.destination - gameObject.transform.position).magnitude < agent.stoppingDistance)
        {
            anim.SetInteger("AnimationPar", 0);
        }
    }
}
