using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Food : MonoBehaviour, IExtractResources
{
    public float foodAvailable = 1000f;

    Rigidbody mCuerpo;

    GameObject wood;
    GameObject stone;
    GameObject food;

    SingletonSources countSources;

    public Text tFood;

    public Food()
    {
        countSources = SingletonSources.Instance;
    }

    void Start ()
    {
        mCuerpo = GetComponent<Rigidbody>();

        wood = GameObject.FindGameObjectWithTag("Wood");
        stone = GameObject.FindGameObjectWithTag("Stone");
        food = GameObject.FindGameObjectWithTag("Food");
    }
	
	void Update ()
    {
        mCuerpo.WakeUp();

        if (foodAvailable <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    public void Extractor(float pWood, float pFood, float pStone)
    {
        foodAvailable -= pWood * Time.deltaTime;
        foodAvailable -= pFood * Time.deltaTime;
        foodAvailable -= pStone * Time.deltaTime;

        tFood.text = " " + foodAvailable.ToString("0");
    }
}
