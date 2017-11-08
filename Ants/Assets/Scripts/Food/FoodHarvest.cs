using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodHarvest : MonoBehaviour {

    float extractionWood;
    float extractionFood;
    float extractionStone;

    Rigidbody mCuerpo;
    AudioSource eating;

    float t = 0f;

	void Start ()
    {
        mCuerpo = GetComponent<Rigidbody>();
        eating = GameObject.Find("Eating").GetComponent<AudioSource>();
	}
	
	void Update ()
    {
        mCuerpo.WakeUp();
    }

    private void OnCollisionStay(Collision pCollision)
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
            resourcesInterface.Extractor(extractionWood,extractionFood,extractionStone);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        eating.Stop();
    }
}
