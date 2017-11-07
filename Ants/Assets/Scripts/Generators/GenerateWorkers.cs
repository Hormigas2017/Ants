using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateWorkers : MonoBehaviour {

    Transform mTransform;

    // Use this for initialization
    void Start () {
        mTransform = GetComponent<Transform>();
        CreateButton.SpawnWorker += SpawnAWorker;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void SpawnAWorker()
    {
        GameObject antWorker = WorkerPool.WorkerP.GetWorker();
        if (antWorker != null)
        {
            antWorker.transform.position = new Vector3(mTransform.position.x + 1, mTransform.position.y, mTransform.position.z + 1);
            antWorker.transform.rotation = Quaternion.identity;
            antWorker.SetActive(true);
        }
    }
}
