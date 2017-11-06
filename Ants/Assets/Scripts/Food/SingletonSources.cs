using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SingletonSources : MonoBehaviour
{
    public float woodCount;
    public float foodCount;
    public float stoneCount;

    public Text tFood;
    public Text tWood;
    public Text tStone;

    public static SingletonSources instance = null;

	public static SingletonSources Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new SingletonSources();
            }
            return instance;
        }
    }

    public SingletonSources()
    {
        woodCount = 0f;
        foodCount = 0f;
        stoneCount = 0f;
    }
}
