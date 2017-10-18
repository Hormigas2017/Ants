using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasEvents : MonoBehaviour {

    public Transform canvasWG, canvasAG, canvasWaG;
    Generators bools;

    // Use this for initialization
    void Start ()
    {
        bools = GameObject.Find("WorkersGenerator").GetComponent<Generators>();
        Generators.WorkersGen += CanvasWG;
        Generators.ArchersGen += CanvasAG;
        Generators.WarriorsGen += CanvasWaG;
    }
	
	// Update is called once per frame
	void Update ()
    {
        CanvasWG();
        CanvasAG();
        CanvasWaG();
    }

    public void CanvasWG()
    {
        if (bools.boolWg == true)
        {
            if (canvasWG.gameObject.activeInHierarchy == false)
            {
                canvasWG.gameObject.SetActive(true);
            }
        }
        else
        {
            if (canvasWG.gameObject.activeInHierarchy == true)
            {
                canvasWG.gameObject.SetActive(false);
            }
        }

    }

    public void CanvasAG()
    {
        if (bools.boolAg == true)
        {
            if (canvasAG.gameObject.activeInHierarchy == false)
            {
                canvasAG.gameObject.SetActive(true);
            }
        }
        else
        {
            if (canvasAG.gameObject.activeInHierarchy == true)
            {
                canvasAG.gameObject.SetActive(false);
            }
        }
    }

    public void CanvasWaG()
    {
        if (bools.boolWag == true)
        {
            if (canvasWaG.gameObject.activeInHierarchy == false)
            {
                canvasWaG.gameObject.SetActive(true);
            }
        }
        else
        {
            if (canvasWaG.gameObject.activeInHierarchy == true)
            {
                canvasWaG.gameObject.SetActive(false);
            }
        }
    }
}
