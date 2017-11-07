using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneCenterOfMass : MonoBehaviour {

    Rigidbody mRigi;

	void Start ()
    {
        mRigi = GetComponent<Rigidbody>();

        mRigi.centerOfMass = new Vector3(0,0.1f,0);
	}
	
	void Update ()
    {
		
	}
}
