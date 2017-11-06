using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour, IExtractResources {

    public float foodAvailable = 1000;
    Rigidbody mCuerpo;
    GameObject wood;

	void Start ()
    {
        mCuerpo = GetComponent<Rigidbody>();

        wood = GameObject.FindGameObjectWithTag("Wood");
    }
	
	void Update ()
    {
        mCuerpo.WakeUp();

        if (foodAvailable <= 0)
        {
            wood.gameObject.SetActive(false);
        }
    }
    public void Extractor(float pWood, float pFood, float pStone)
    {
        if (wood)
        {
            foodAvailable -= pWood * Time.deltaTime;
            Debug.Log("Como wood");
        }
    }
}
