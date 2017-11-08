using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
namespace Selection
{
    public class WarrioAttack : MonoBehaviour
    {
        [SerializeField]
        bool engage = false;
        bool attackCoolDown = false;
        float t = 0;
        NavMeshAgent mNav;
        GameObject enemyFound;
        SelectableUnit ifSelection;
        ClickToMove theClick;


        void Start()
        {
            mNav = GetComponent<NavMeshAgent>();
            theClick = GetComponent<ClickToMove>();
            ifSelection = GetComponent<SelectableUnit>();
        }
        void Update()
        {
            Disengage();
            Attack();
            if (engage)
            {
                Engage();
            }
            if (!engage) { theClick.goElseWhere = false; }
            else
            {
                mNav.ResetPath();
            }
            if (attackCoolDown == false)
            {
                t += Time.deltaTime;
                if (t >= 2f)
                {
                    attackCoolDown = true;
                    t = 0;
                }
            }
        }
        public void Attack()
        {
            if (Input.GetMouseButtonDown(1)&&ifSelection.IsSelected())
            {
                RaycastHit hitInfo = new RaycastHit();
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo) && hitInfo.transform.GetComponent<IEnemies>() != null)
                {
                    theClick.goElseWhere = true;
                    enemyFound = hitInfo.transform.gameObject;
                    if (enemyFound != null)
                    {
                        engage = true;
                    }
                    else
                    {
                        engage = false;
                    }
                }
            }
        }
        public void Engage()
        {
            Vector3 enemy = transform.position - enemyFound.transform.position;
            print("I Will Engage");
            mNav.SetDestination(enemyFound.transform.position);
            if (enemy.sqrMagnitude < 5)
            {
                mNav.ResetPath();
                IEnemies EnemyWillBeAttacked = enemyFound.GetComponent<IEnemies>();
                if (attackCoolDown)
                {
                    EnemyWillBeAttacked.Destroy(10);
                    attackCoolDown = false;
                }

            }
            else
            {
                mNav.SetDestination(enemyFound.transform.position);
            }
        }
        public void Disengage()
        {
            if (Input.GetMouseButtonDown(1) && ifSelection.IsSelected() && engage == true)
            {
                RaycastHit hitInfo = new RaycastHit();
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo) && hitInfo.transform.GetComponent<IEnemies>() == null)
                {
                    engage = false;
                    mNav.SetDestination(hitInfo.transform.position);
                    Arrived();
                }
            }
        }
        public void Arrived()
        {
            mNav.ResetPath();
        }
    }
}
