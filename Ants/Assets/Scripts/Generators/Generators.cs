using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Generators : MonoBehaviour
{
    public delegate void MouseFoundGenerator();

    public static event MouseFoundGenerator WorkersGen;
    public static event MouseFoundGenerator ArchersGen;
    public static event MouseFoundGenerator WarriorsGen;

    public bool boolWg = false, boolAg = false, boolWag = false;

    public delegate void GeneratorSelectedTutorial();
    public static event GeneratorSelectedTutorial OnSelectedGenerator;

    public bool selectedGeneratorTutorial = false;
    Scene mScene;

    void Start ()
    {
        mScene = SceneManager.GetActiveScene();
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
                selectedGeneratorTutorial = true;

                if (mScene.name == "World" && boolWg)
                {
                    WorkersGen();
                }

                if (selectedGeneratorTutorial && mScene.name == "tutorial")
                {
                    OnSelectedGenerator();
                }
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
