using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateButton : MonoBehaviour
{
    public Image[] imagesArray = new Image[10];
    float tAG = 30f;
    float tWaG = 30f;
    float tWG = 30f;
    // Use this for initialization
    void Start ()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tAG -= Time.deltaTime;
        tWaG -= Time.deltaTime;
        tWG -= Time.deltaTime;
        ArchersTime();
        WarriorsTime();
        WorkersTime();
        Debug.Log(tWG);
    }

    public void NumAnts()
    {
        for (int i = 0; i < imagesArray.Length; i++)
        {
            if (imagesArray[i].gameObject.activeInHierarchy == false)
            {
                imagesArray[i].gameObject.SetActive(true);
                break;
            }
        }
    }

    public void ArchersTime()
    {
        for (int i = 0; i < imagesArray.Length; i++)
        {
            if (tAG < 0f)
            {
                if (imagesArray[i].gameObject.activeInHierarchy == true)
                {
                    imagesArray[i].gameObject.SetActive(false);
                    tAG = 30;
                    break;
                }
            }
        }
    }

    public void WarriorsTime()
    {
        for (int i = 0; i < imagesArray.Length; i++)
        {
            if (tWaG < 10f)
            {
                if (imagesArray[i].gameObject.activeInHierarchy == true)
                {
                    imagesArray[i].gameObject.SetActive(false);
                    tWaG = 30;
                    break;
                }
            }
        }
    }

    public void WorkersTime()
    {
        for (int i = 0; i < imagesArray.Length; i++)
        {
            if (tWG < 20f)
            {
                if (imagesArray[i].gameObject.activeInHierarchy == true)
                {
                    imagesArray[i].gameObject.SetActive(false);
                    tWG = 30;
                    break;
                }
            }
        }
    }
}
