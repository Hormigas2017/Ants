using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Selection
{

    public class FoodHarvest : MonoBehaviour
    {
        bool harvest = false, harvestCoolDown = true;
        SelectableUnit ifSelected;
        float extractionWood;
        float extractionFood;
        float extractionStone;

        NavMeshAgent mNav;
        GameObject resourceFound;
        Rigidbody mCuerpo;
        AudioSource eating;
        ClickToMove theClick;

        float t = 0f;

        void Start()
        {
            mNav = GetComponent<NavMeshAgent>();
            ifSelected = GetComponent<SelectableUnit>();
            theClick = GetComponent<ClickToMove>();
            mCuerpo = GetComponent<Rigidbody>();
            eating = GameObject.Find("Eating").GetComponent<AudioSource>();
            if (DifficultController.difficult == 0)
            {
                extractionWood = 250f;
                extractionFood = 300f;
                extractionStone = 250f;
            }
            if (DifficultController.difficult == 1)
            {
                extractionWood = 150f;
                extractionFood = 150f;
                extractionStone = 200f;
            }
            if (DifficultController.difficult == 2)
            {
                extractionWood = 50f;
                extractionStone = 25;
                extractionFood = 100f;
            }

        }

        void Update()
        {
            StartExtract();
            mCuerpo.WakeUp();
            if (harvest)
            {
                Harvest();
            }
            if (harvestCoolDown == false)
            {
                t += Time.deltaTime;
                if (t >= 2f)
                {
                    harvestCoolDown = true;
                    t = 0;
                }
            }
        }

        /*private void OnCollisionStay(Collision pCollision)
        {
            GameObject arrived = pCollision.gameObject;

            t += Time.deltaTime;

            if (arrived.gameObject.tag == "Wood")
            {
                if (DifficultController.difficult == 0)
                {
                    extractionWood = 250f;
                }
                if (DifficultController.difficult == 1)
                {
                    extractionWood = 150f;
                }
                if (DifficultController.difficult == 2)
                {
                    extractionWood = 50f;
                }

                if (t > 1f)
                {
                    eating.Play();
                    t = 0;
                }
            }

            if (arrived.gameObject.tag == "Stone")
            {
                if (DifficultController.difficult == 0)
                {
                    extractionStone = 200f;
                }
                if (DifficultController.difficult == 1)
                {
                    extractionStone = 100f;
                }
                if (DifficultController.difficult == 2)
                {
                    extractionStone = 25f;
                }

                if (t > 1f)
                {
                    eating.Play();
                    t = 0;
                }
            }

            if (arrived.gameObject.tag == "Food")
            {
                if (DifficultController.difficult == 0)
                {
                    extractionFood = 300f;
                }
                if (DifficultController.difficult == 1)
                {
                    extractionFood = 200f;
                }
                if (DifficultController.difficult == 2)
                {
                    extractionFood = 100f;
                }

                if (t > 1f)
                {
                    eating.Play();
                    t = 0;
                }
            }

            if (arrived.GetComponent<IExtractResources>() != null)
            {
                IExtractResources resourcesInterface = arrived.GetComponent<IExtractResources>();
                resourcesInterface.Extractor(extractionWood, extractionFood, extractionStone);
            }
        }*/

        /*private void OnCollisionExit(Collision collision)
        {
            eating.Stop();
        }*/
        public void StartExtract()
        {
            if (Input.GetMouseButtonDown(1) && ifSelected.IsSelected())
            {
                RaycastHit hitInfo = new RaycastHit();
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo) && hitInfo.transform.GetComponent<IExtractResources>() != null)
                {
                    print("Click en recurso");
                    resourceFound = hitInfo.transform.gameObject;
                    if (resourceFound != null)
                    {
                        harvest = true;
                    }
                    else
                    {
                        harvest = false;
                    }
                }
            }
        }
        public void Harvest()
        {
            Vector3 resource = transform.position - resourceFound.transform.position;
            print("I Will Harvest");
            mNav.SetDestination(resourceFound.transform.position);
            if (resource.sqrMagnitude < 5)
            {
                mNav.ResetPath();
                IExtractResources resourceToHarvest = resourceFound.GetComponent<IExtractResources>();
                if (harvestCoolDown)
                {
                    resourceToHarvest.Extractor(extractionWood, extractionFood, extractionStone);
                    eating.Play();
                    harvestCoolDown = false;
                }
            }
            else
            {
                mNav.SetDestination(resourceFound.transform.position);
            }
        }
        public void DisHarvest()
        {
            if (Input.GetMouseButtonDown(1) && ifSelected.IsSelected() && harvest == true)
            {
                RaycastHit hitInfo = new RaycastHit();
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo) && hitInfo.transform.GetComponent<IEnemies>() == null)
                {
                    harvest = false;
                    mNav.ResetPath();
                    mNav.SetDestination(hitInfo.transform.position);
                }
            }
        }
    }
}
