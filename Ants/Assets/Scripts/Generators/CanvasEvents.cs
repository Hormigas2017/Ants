using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasEvents : MonoBehaviour {

    public GameObject canvasWG, canvasAG, canvasWaG;
    Generators mGenerators;

    void Start ()
    {
        mGenerators = GameObject.Find("WorkersGenerator").GetComponent<Generators>();

        Generators.WorkersGen += CanvasWG;
        Generators.ArchersGen += CanvasAG;
        Generators.WarriorsGen += CanvasWaG;
    }
	
	void Update ()
    {
        CanvasWG();
        CanvasAG();
        CanvasWaG();
    }

    public void CanvasWG()
    {
        if (mGenerators.boolWg == true)
        {
            if (canvasWG.activeInHierarchy == false)
            {
                canvasWG.SetActive(true);
            }
        }
        else
        {
            canvasWG.SetActive(false);
        }
    }

    public void CanvasAG()
    {
        if (mGenerators.boolAg == true)
        {
            if (canvasAG.activeInHierarchy == false)
            {
                canvasAG.SetActive(true);
            }
        }
        else
        {
            canvasAG.SetActive(false);
        }
    }

    public void CanvasWaG()
    {
        if (mGenerators.boolWag == true)
        {
            if (canvasWaG.activeInHierarchy == false)
            {
                canvasWaG.SetActive(true);
            }
        }
        else
        {
            canvasWaG.SetActive(false);
        }
    }

    public void ExitCanvasWG()
    {
        if (mGenerators.boolWg == true)
        {
            mGenerators.boolWg = false;
        }
    }

    public void ExitCanvasAG()
    {
        if (mGenerators.boolAg == true)
        {
            mGenerators.boolAg = false;
        }
    }
    public void ExitCanvasWaG()
    {
        if (mGenerators.boolWag == true)
        {
            mGenerators.boolWag = false;
        }
    }
}
