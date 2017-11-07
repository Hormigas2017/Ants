using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour {

    float t = 0f;

    public GameObject[] arrows;

    GameObject welcome;
    GameObject move;
    GameObject wellDoneMove;
    GameObject wellDoneScroll;
    GameObject scroll;
    GameObject selectCharacter;
    GameObject mouseScrollSprite;
    GameObject goodJob;

    bool boolMove = false;
    bool boolScroll = false;
    bool boolSelectioned = false;

    void Start ()
    {
        welcome = GameObject.Find("Welcome");
        move = GameObject.Find("Move");
        wellDoneMove = GameObject.Find("WellDone");
        scroll = GameObject.Find("Scroll");
        wellDoneScroll = GameObject.Find("WellDoneScroll");
        selectCharacter = GameObject.Find("SelectCharacter");
        mouseScrollSprite = GameObject.Find("MouseScrollSprite");
        goodJob = GameObject.Find("GoodJob");

        welcome.SetActive(false);
        move.SetActive(false);
        wellDoneMove.SetActive(false);
        scroll.SetActive(false);
        wellDoneScroll.SetActive(false);
        selectCharacter.SetActive(false);
        mouseScrollSprite.SetActive(false);
        goodJob.SetActive(false);

        foreach (GameObject a in arrows)
        {
            a.SetActive(false);
        }

        //events
        CameraMove.OnCameraMove += CheckCameraMove;
        CameraMove.OnCameraSize += CheckCameraScroll;

        Selection.SelectionController.OnSelectionTutorial += CheckSelectedUnit;
        
    }
	
	void Update ()
    {
        t += Time.deltaTime;
        Debug.Log(t);

        //Welcome
        if (t > 1f && t < 4f)
        {
            welcome.SetActive(true);
        }
        else
        {
            welcome.SetActive(false);
        }

        //Move your mouse
        if (t > 5f && t < 9f)
        {
            move.SetActive(true);
            boolMove = true;

            foreach (GameObject a in arrows)
            {
                a.SetActive(true);
            }
        }
        else
        {
            wellDoneMove.SetActive(false);
            move.SetActive(false);
            boolMove = false;

            foreach (GameObject a in arrows)
            {
                a.SetActive(false);
            }
        }

        //Scroll your mouse
        if (t > 10f && t < 13f)
        {
            scroll.SetActive(true);
            boolScroll = true;
            mouseScrollSprite.SetActive(true);
        }
        else
        {
            wellDoneScroll.SetActive(false);
            mouseScrollSprite.SetActive(false);
            scroll.SetActive(false);
            boolScroll = false;
        }

        //Select character
        if (t > 14f && t < 18f)
        {
            selectCharacter.SetActive(true);
            boolSelectioned = true;
        }
        else
        {
            selectCharacter.SetActive(false);
            boolSelectioned = false;
        }
        
    }

    public void CheckCameraMove()
    {
        if (boolMove == true)
        {
            wellDoneMove.SetActive(true);
        }
    }

    public void CheckCameraScroll()
    {
        if (boolScroll == true)
        {
            wellDoneScroll.SetActive(true);
        }
    }

    public void CheckSelectedUnit()
    {
        if (boolSelectioned == true)
        {
            goodJob.SetActive(true);
        }
    }
}
