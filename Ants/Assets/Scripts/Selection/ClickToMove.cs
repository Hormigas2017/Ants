using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClickToMove : MonoBehaviour
{
    private NavMeshAgent navAgent;
    private Animator anim;

    public Vector3 targetPos; //Position of Mouse "To go"
    public LayerMask groundLayer; //Layer of ground

    public string clickToMove = "Fire1";
    private SelectableUnit selectable;

    private void Awake()
    {
        navAgent = GetComponent<NavMeshAgent>();
        selectable = GetComponent<SelectableUnit>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        //anim.SetFloat("Velocity", navAgent.velocity.sqrMagnitude);

        if (Input.GetButtonDown(clickToMove))
        {
            MoveTowardsClick();
        }
    }

    private void MoveTowardsClick()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, groundLayer))
        {
            if (targetPos != hit.point)
            {
                targetPos = hit.point;
            }
            navAgent.SetDestination(targetPos);
        }
    }
}
