using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Generators : MonoBehaviour
{
    public delegate void MouseFoundGenerator();

    public static event MouseFoundGenerator WorkersGen;
    public static event MouseFoundGenerator ArchersGen;
    public static event MouseFoundGenerator WarriorsGen;

    bool boolWG = false, boolAG = false, boolWaG = false;

    public Transform canvasWG, canvasAG, canvasWaG;

    // Use this for initialization
    void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update () {
        FindWorkersGen();
        FindArchersGen();
        FindWarriorsGen();
        Gen();
    }

    public void FindWorkersGen()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo = new RaycastHit();
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo) && hitInfo.transform.tag == "WorkersGen")
            {
                boolWG = true;
                Gen();
            }
        }
    }

    public void FindArchersGen()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo = new RaycastHit();
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo) && hitInfo.transform.tag == "ArchersGen")
            {
                boolAG = true;
                Gen();
            }
        }
    }

    public void FindWarriorsGen()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo = new RaycastHit();
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo) && hitInfo.transform.tag == "WarriorsGen")
            {
                boolWaG = true;
                Gen();
            }
        }
    }

    public void Gen()
    {
        if (boolWG == true)
        {
            canvasWG.gameObject.SetActive(true);
        }
        if (boolAG == true)
        {
            canvasAG.gameObject.SetActive(true);
        }
        if (boolWaG == true)
        {
            canvasWaG.gameObject.SetActive(true);
        }
    }
}
