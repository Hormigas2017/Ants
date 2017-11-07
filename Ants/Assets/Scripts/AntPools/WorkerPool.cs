using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkerPool : MonoBehaviour {

    public static WorkerPool WorkerP;

    private void Awake()
    {
        WorkerP = this;
    }

    private int workerNumber = 12;
    List<GameObject> workerPool;
    GameObject antWorker;
    
	void Start () {
        antWorker = GameObject.Find("WorkerAnt");
        workerPool = new List<GameObject>();
        for(int i = 0; i < workerNumber; i++)
        {
            GameObject workerClone = Instantiate(antWorker);
            workerClone.SetActive(false);
            workerPool.Add(workerClone);
        }
	}
    public GameObject GetWorker()
    {
        for(int i = 0; i < workerPool.Count; i++)
        {
            if (!workerPool[i].activeInHierarchy)
            {
                print("I Spawned a worker from the pool party");
                return workerPool[i];
            }
        }
        print("There are no ants in the pool party");
        return null;
    }
}
