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

    public bool boolWg = false, boolAg = false, boolWag = false;

    void Start ()
    {
        
	}
	
	void Update ()
    {
        FindWorkersGen();
        FindArchersGen();
        FindWarriorsGen();
    }

    public void FindWorkersGen()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo = new RaycastHit();
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo) && hitInfo.transform.tag == "WorkersGen")
            {
                boolWg = true;
                WorkersGen();
            }
            /*else
            {
              boolWg = false;
            }*/
        }
    }

    public void FindArchersGen()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo = new RaycastHit();
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo) && hitInfo.transform.tag == "ArchersGen")
            {
                boolAg = true;
                ArchersGen();
            }
            /*else
            {
                boolAg = false;
            }*/
        }
       
    }

    public void FindWarriorsGen()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo = new RaycastHit();
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo) && hitInfo.transform.tag == "WarriorsGen")
            {
                boolWag = true;
                WarriorsGen();
            }
           /* else
            {
                boolWag = false;
            }*/
        }
        
    }
}
