using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateButton : MonoBehaviour
{
    public Image[] imagesArray = new Image[10];
    float tAG = 0f;
    float tWaG = 0f;
    float tWG = 0f;

    CanvasEvents mCanvasE;
    Generators mGens;

    AudioSource spawnWarriors;
    AudioSource spawnArchers;

    // Use this for initialization
    void Start ()
    {
        mCanvasE = GetComponent<CanvasEvents>();
        mGens = GetComponent<Generators>();

        spawnWarriors = GameObject.Find("SpawnWaA").GetComponent<AudioSource>();
        spawnArchers = GameObject.Find("SpawnAA").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ArchersTime();
        WarriorsTime();
        WorkersTime();
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
        tAG += Time.deltaTime;
        Debug.Log(tAG);
        for (int i = 0; i < imagesArray.Length; i++)
        {
            if (tAG > 5f)
            {
                if (imagesArray[i].gameObject.activeInHierarchy == true)
                {
                    imagesArray[i].gameObject.SetActive(false);
                    tAG = 0f;
                    break;
                }
            }
        }
    }

    public void WarriorsTime()
    {
        tWaG -= Time.deltaTime;
        
        for (int i = 0; i < imagesArray.Length; i++)
        {
            if (tWaG < 10f)
            {
                if (imagesArray[i].gameObject.activeInHierarchy == true)
                {
                    imagesArray[i].gameObject.SetActive(false);

                    spawnWarriors.Play();//Audio source

                    tWaG = 30f;
                    break;
                }
            }
        }
    }

    public void WorkersTime()
    {
        tWG -= Time.deltaTime;
        for (int i = 0; i < imagesArray.Length; i++)
        {
            if (tWG < 20f)
            {
                if (imagesArray[i].gameObject.activeInHierarchy == true)
                {
                    imagesArray[i].gameObject.SetActive(false);
                    tWG = 30f;
                    break;
                }
            }
        }
    }

}
