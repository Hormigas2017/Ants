using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

namespace Selection
{
    public class ClickToMove : MonoBehaviour
    {
        WarrioAttack theWarrior;
        FoodHarvest harvest;
        private NavMeshAgent navAgent;
        //private Animator anim;
        [SerializeField]
        //private LineRenderer trace;
        public Vector3 targetPos;
        public LayerMask groundLayer; // capa del suelo;
        private SelectableUnit selectable;
        public bool goElseWhere = false;

        public delegate void TutorialMoveUnit();
        public static event TutorialMoveUnit OnMoveUnitTutorial;

        bool moveUnitTutotial = false;

        Scene mScene;

        private void Awake()
        {
            harvest = GetComponent<FoodHarvest>();
            navAgent = GetComponent<NavMeshAgent>();
            //anim = GetComponentInChildren<Animator>();
            selectable = GetComponent<SelectableUnit>();
            theWarrior = GetComponent<WarrioAttack>();
            mScene = SceneManager.GetActiveScene();
        }

        private void Update()
        {
            //anim.SetFloat("velocity", navAgent.velocity.sqrMagnitude);

            //trace.SetPosition(0, transform.position);
            if (!goElseWhere) {
                if (Input.GetButtonDown("Fire2") && selectable.IsSelected())
                {
                    MoveTowardsClick();
                }
            }
            if (selectable.IsSelected())
            {
                if (navAgent.remainingDistance <= navAgent.stoppingDistance)
                {
                    //trace.enabled = false;
                }
                //else
                    //trace.enabled = true;

            }
            //else
                //trace.enabled = false;
        }

        private void MoveTowardsClick()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            int radius = SelectionController.selectedUnits.Count / 2;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, groundLayer))
            {
                targetPos = hit.point + new Vector3(Random.Range(-radius, radius), 0, Random.Range(-radius, radius));
                navAgent.SetDestination(targetPos);

                moveUnitTutotial = true;

                if (moveUnitTutotial && mScene.name == "tutorial")
                {
                    OnMoveUnitTutorial();
                }
                //trace.SetPosition(1, targetPos);

            }
        }
    }
}

