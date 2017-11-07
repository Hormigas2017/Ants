using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    GameObject good;
    GameObject generator;
    GameObject selectGenerator;
    GameObject goodOne;
    GameObject nice;
    GameObject continuar;
    GameObject skip;

    GameObject canvas;

    bool boolMove = false;
    bool boolScroll = false;
    bool boolSelectioned = false;
    bool boolMoveUnit = false;
    bool boolSelectGenerator = false;
    bool boolUnitGeneration = false;

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
        good = GameObject.Find("Good");
        generator = GameObject.Find("WorkersGen");
        selectGenerator = GameObject.Find("SelectGen");
        canvas = GameObject.Find("CanvasWorkG");
        goodOne = GameObject.Find("Good1");
        nice = GameObject.Find("Nice");
        continuar = GameObject.Find("Continue");
        skip = GameObject.Find("TextSkip");

        welcome.SetActive(false);
        move.SetActive(false);
        wellDoneMove.SetActive(false);
        scroll.SetActive(false);
        wellDoneScroll.SetActive(false);
        selectCharacter.SetActive(false);
        mouseScrollSprite.SetActive(false);
        goodJob.SetActive(false);
        good.SetActive(false);
        generator.SetActive(false);
        selectGenerator.SetActive(false);
        goodOne.SetActive(false);
        canvas.SetActive(false);
        nice.SetActive(false);
        continuar.SetActive(false);

        foreach (GameObject a in arrows)
        {
            a.SetActive(false);
        }

        //events
        CameraMove.OnCameraMove += CheckCameraMove;
        CameraMove.OnCameraSize += CheckCameraScroll;

        Selection.SelectionController.OnSelectionTutorial += CheckSelectedUnit;
        Selection.ClickToMove.OnMoveUnitTutorial += CheckMoveUnit;
        Generators.OnSelectedGenerator += CheckSelectedGenerator;
        CreateUnitTutorial.OnCreateUnitGen += CheckUnitGeneration;

    }
	
	void Update ()
    {
        t += Time.deltaTime;

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
        if (t > 14f && t < 22f)
        {
            selectCharacter.SetActive(true);
            boolSelectioned = true;
            boolMoveUnit = true;
        }
        else
        {
            selectCharacter.SetActive(false);
            boolSelectioned = false;
            goodJob.SetActive(false);
            good.SetActive(false);
        }
        
        //Select Gen
        if (t > 23f && t < 30f)
        {
            generator.SetActive(true);
            boolSelectGenerator = true;
            selectGenerator.SetActive(true);

            boolUnitGeneration = true;
        }
        else
        {
            generator.SetActive(false);
            boolSelectGenerator = false;
            selectGenerator.SetActive(false);
            canvas.SetActive(false);
            goodOne.SetActive(false);

            nice.SetActive(false);
        }

        //continue
        if (t> 31 && t< 38f)
        {
            continuar.SetActive(true);
            skip.SetActive(false);
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

    public void CheckMoveUnit()
    {
        if (boolMoveUnit == true)
        {
            good.SetActive(true);
        }
    }

    public void CheckSelectedGenerator()
    {
        if (boolSelectGenerator == true)
        {
            goodOne.SetActive(true);
            canvas.SetActive(true);
        }
    }

    public void CheckUnitGeneration()
    {
        if (boolUnitGeneration == true)
        {
            nice.SetActive(true);
        }
    }

    public void SkipTutorial()
    {
        SceneManager.LoadScene("World");
    }
}
