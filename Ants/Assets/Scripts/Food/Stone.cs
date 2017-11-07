using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stone : MonoBehaviour, IExtractResources {

    public float resource = 2000f;

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
        resource -= pStone * Time.deltaTime;
        SingletonSources.Instance.stoneCount += pStone * Time.deltaTime;
    }   
}
