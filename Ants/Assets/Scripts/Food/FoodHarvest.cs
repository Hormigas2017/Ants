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

        if (t > 1f)
        {
            eating.Play();
            t = 0;
        }

        if (arrived.gameObject.tag == "Wood")
        {
            extractionWood = 150f;
        }

        if (arrived.gameObject.tag == "Stone")
        {
            extractionStone = 100f;
        }
        if (arrived.gameObject.tag == "Food")
        {
            extractionStone = 200f;
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
