using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hut : MonoBehaviour
{
    public bool spawn = true;
    Transform spawnReference;
    Transform ghTransform;
    float timer; //Spawn Frecuency
    //float t = 0;

	// Use this for initialization
	void Start ()
    {
        spawnReference = transform.Find("Spawn Ref").GetComponent<Transform>();
        timer = 5f;

        if (spawn)
        {
            InvokeRepeating("Spawn", 0.5f, timer);
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
 
	}

    void Spawn()
    {
        GameObject grasshopper = GrasshopperPooler.SharedInstance.GetGrasshopper();
        if (grasshopper != null)
        {
            grasshopper.transform.position = spawnReference.transform.position;
            grasshopper.transform.rotation = Quaternion.identity;
            grasshopper.SetActive(true);
        }  
    }

}
