using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateWarriors : MonoBehaviour {

    Transform mTransform;

    // Use this for initialization
    void Start () {
        mTransform = GetComponent<Transform>();
        CreateButton.SpawnWarrior += SpawnAWarrior;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void SpawnAWarrior()
    {
        GameObject GetWarrior = WarriorPool.WarriorP.GetWarrior();
        if (GetWarrior != null)
        {
            GetWarrior.transform.position = new Vector3(mTransform.position.x + 1, mTransform.position.y, mTransform.position.z + 1);
            GetWarrior.transform.rotation = Quaternion.identity;
            GetWarrior.SetActive(true);
        }
    }
}
