using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherPool : MonoBehaviour {

    public static ArcherPool ArcherP;

    private void Awake()
    {
        ArcherP = this;
    }

    private int archerNumber = 12;
    List<GameObject> archerPool;
    GameObject antArcher;
    
    void Start () {
        antArcher = GameObject.Find("ArcherAnt");
        archerPool = new List<GameObject>();
        for(int i = 0; i < archerNumber; i++)
        {
            GameObject archerClone = Instantiate(antArcher);
            archerClone.SetActive(false);
            archerPool.Add(archerClone);
        }
	}
	public GameObject GetArcher()
    {
        for(int i = 0; i < archerPool.Count; i++)
        {
            if (!archerPool[i].activeInHierarchy)
            {
                print("I Spawned an archer from the pool party");
                return archerPool[i];
            }
        }
        print("There are no ants in the pool party");
        return null;
    }
}
