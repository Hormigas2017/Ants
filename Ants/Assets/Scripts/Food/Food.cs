using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Food : MonoBehaviour, IExtractResources
{
    public float resource = 1000f;

    Rigidbody mCuerpo;

    void Start ()
    {
         mCuerpo = GetComponent<Rigidbody>();
    }
	
	void Update ()
    {
        mCuerpo.WakeUp();

        if (resource <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    public void Extractor(float pWood, float pFood, float pStone)
    {
        resource -= pFood * Time.deltaTime;
        SingletonSources.Instance.foodCount += pFood * Time.deltaTime;
    }
}
