using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultController : MonoBehaviour
{
    public static DifficultController difficultController;

    public static int difficult;

    private void Awake()
    {
        DontDestroyOnLoad(this);

        if (difficultController == null)
        {
            difficultController = this;
        }
        else
        {
            DestroyObject(gameObject);
        }
    }

    void Start ()
    {
        difficult = 0;
	}

    public void PutItEasy()
    {
        difficult = 0;
    }

    public void PutItMedium()
    {
        difficult = 1;
    }

    public void PutItHard()
    {
        difficult = 2;
    }
}
