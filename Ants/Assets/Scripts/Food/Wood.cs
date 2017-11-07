using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wood : MonoBehaviour, IExtractResources {

    public float resource = 1500f;

    Rigidbody mCuerpo;

    void Start()
    {
        mCuerpo = GetComponent<Rigidbody>();
    }

    void Update()
    {
        mCuerpo.WakeUp();

        if (resource <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    public void Extractor(float pWood, float pFood, float pStone)
    {
        resource -= pWood * Time.deltaTime;
        SingletonSources.Instance.woodCount += pWood * Time.deltaTime;
    }   
}
