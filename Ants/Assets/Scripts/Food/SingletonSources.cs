using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SingletonSources : MonoBehaviour
{
    public float woodCount =0f;
    public float foodCount = 0f;
    public float stoneCount = 0f;

    public Text tFood;
    public Text tWood;
    public Text tStone;

    private static SingletonSources instance = null;

	public static SingletonSources Instance
    {
        get
        {
            return instance;
        }
    }
    private void Start()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    private void Update()
    {
        tFood.text = " " + foodCount.ToString("0");
        tWood.text = " " + woodCount.ToString("0");
        tStone.text = " " + stoneCount.ToString("0");
    }
}
