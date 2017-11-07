using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateArchers : MonoBehaviour {

    Transform mTransform;

    // Use this for initialization
    void Start () {
        mTransform = GetComponent<Transform>();
        CreateButton.SpawnArcher += SpawnAnArcher;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void SpawnAnArcher()
    {
        GameObject GetArcher = ArcherPool.ArcherP.GetArcher();
        if (GetArcher != null)
        {
            GetArcher.transform.position = new Vector3(mTransform.position.x + 1, mTransform.position.y, mTransform.position.z + 1);
            GetArcher.transform.rotation = Quaternion.identity;
            GetArcher.SetActive(true);
        }
    }
}
