using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnthillSelection : MonoBehaviour
{

    GameObject iOne;
    GameObject iTwo;
    GameObject iThree;

    public string firstCharacter = "1";
    public string secondCharacter = "2";
    public string thirdCharacter = "3";

    GameObject left;
    GameObject right;

    int i = 0;

    public GameObject[] arrayCharacters;

    void Start()
    {
        iOne = GameObject.Find(firstCharacter);
        iTwo = GameObject.Find(secondCharacter);
        iThree = GameObject.Find(thirdCharacter);

        left = GameObject.Find("Left");
        right = GameObject.Find("Right");

        foreach (GameObject a in arrayCharacters)
        {
            a.gameObject.SetActive(false);
        }

        if (iOne.gameObject.activeInHierarchy == true)
        {
            left.gameObject.SetActive(false);
        }
        Time.timeScale = 0;
        iTwo.gameObject.SetActive(false);
        iThree.gameObject.SetActive(false);
    }

    public void NextButton()
    {
        i += 1;

        if (i == 1)
        {
            iOne.gameObject.SetActive(false);
            iTwo.gameObject.SetActive(true);

            left.gameObject.SetActive(true);
        }

        if (i == 2)
        {
            iTwo.gameObject.SetActive(false);
            iThree.gameObject.SetActive(true);

            right.gameObject.SetActive(false);
        }

    }

    public void PrevButton()
    {
        i -= 1;

        if (i == 0)
        {
            iOne.gameObject.SetActive(true);
            iTwo.gameObject.SetActive(false);

            left.gameObject.SetActive(false);
        }

        if (i == 1)
        {
            iTwo.gameObject.SetActive(true);
            iThree.gameObject.SetActive(false);

            right.gameObject.SetActive(true);
        }
    }

    public void StartButton()
    {
        if (i == 0)
        {
            Debug.Log(i);
            arrayCharacters[0].gameObject.SetActive(true);
            arrayCharacters[1].gameObject.SetActive(false);
            arrayCharacters[2].gameObject.SetActive(false);
        }
        if (i == 1)
        {
            arrayCharacters[0].gameObject.SetActive(false);
            arrayCharacters[1].gameObject.SetActive(true);
            arrayCharacters[2].gameObject.SetActive(false);
        }
        if (i == 2)
        {
            arrayCharacters[0].gameObject.SetActive(false);
            arrayCharacters[1].gameObject.SetActive(false);
            arrayCharacters[2].gameObject.SetActive(true);
        }

        Time.timeScale = 1;
    }
}
