using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateUnitTutorial : MonoBehaviour {

    Transform transUnit;
    Transform reference;

    public delegate void CreateUnitGen();
    public static event CreateUnitGen OnCreateUnitGen;


    void Start ()
    {
        transUnit = GameObject.Find("WorkerUnit").GetComponent<Transform>();
        reference = GameObject.Find("Ref").GetComponent<Transform>();

    }

    public void CreateUnitGenerator()
    {
        transUnit.position = reference.position;
        OnCreateUnitGen();
        Debug.Log("Genero evento");
    }

}
