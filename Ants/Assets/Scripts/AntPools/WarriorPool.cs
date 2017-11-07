using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorPool : MonoBehaviour {

    public static WarriorPool WarriorP;

    private void Awake()
    {
        WarriorP = this;
    }

    private int warriorNumber = 12;
    List<GameObject> warriorPool;
    GameObject antWarrior;
    
    void Start () {
        antWarrior = GameObject.Find("WarriorAnt");
        warriorPool = new List<GameObject>();
        for(int i = 0; i < warriorNumber; i++)
        {
            GameObject warriorClone = Instantiate(antWarrior);
            warriorClone.SetActive(false);
            warriorPool.Add(warriorClone);
        }
	}
	public GameObject GetWarrior()
    {
        for(int i = 0; i < warriorPool.Count; i++)
        {
            if (!warriorPool[i].activeInHierarchy)
            {
                print("I Spawned a warrior from the pool party");
                return warriorPool[i];
            }
        }
        print("There are no ants in the pool party");
        return null;
    }
}
