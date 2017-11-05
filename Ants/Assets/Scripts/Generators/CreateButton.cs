using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateButton : MonoBehaviour
{
    public Image[] imagesArrayWorkers = new Image[10];
    public Image[] imagesArrayArchers = new Image[10];
    public Image[] imagesArrayWarriors = new Image[10];

    float tAG = 0f;
    float tWaG = 0f;
    float tWG = 0f;

    CanvasEvents mCanvasE;
    Generators mGens;

    AudioSource spawnWarriors;
    AudioSource spawnArchers;
    AudioSource spawnWorkers;

    bool archerBool = false, workerBool = false, warriorBool = false;

    void Start ()
    {
        mCanvasE = GetComponent<CanvasEvents>();
        mGens = GetComponent<Generators>();

        spawnWarriors = GameObject.Find("SpawnWaA").GetComponent<AudioSource>();
        spawnArchers = GameObject.Find("SpawnAA").GetComponent<AudioSource>();
        spawnWorkers = GameObject.Find("SpawnWA").GetComponent<AudioSource>();
    }

    void Update()
    {
        if (archerBool == true)
        {
            tAG += Time.deltaTime;
        }
        if (warriorBool == true)
        {
            tWaG += Time.deltaTime;
        }
        if (workerBool == true)
        {
            tWG += Time.deltaTime;
        }

        ArchersTime();
        WarriorsTime();
        WorkersTime();
    }

    public void NumAntsWorkers()
    {
        for (int i = 0; i < imagesArrayWorkers.Length; i++)
        {
            if (imagesArrayWorkers[i].gameObject.activeInHierarchy == false)
            {
                imagesArrayWorkers[i].gameObject.SetActive(true);
                workerBool = true;
                break;
            }
        }
    }
    public void NumAntsArchers()
    {
        for (int i = 0; i < imagesArrayArchers.Length; i++)
        {
            if (imagesArrayArchers[i].gameObject.activeInHierarchy == false)
            {
                imagesArrayArchers[i].gameObject.SetActive(true);
                archerBool = true;
                break;
            }
        }
    }
    public void NumAntsWarriors()
    {
        for (int i = 0; i < imagesArrayWarriors.Length; i++)
        {
            if (imagesArrayWarriors[i].gameObject.activeInHierarchy == false)
            {
                imagesArrayWarriors[i].gameObject.SetActive(true);
                warriorBool = true;
                break;
            }
        }
    }

    public void ArchersTime()
    {
        
        for (int i = 0; i < imagesArrayArchers.Length; i++)
        {
            if (tAG > 20f)
            {
                if (imagesArrayArchers[i].gameObject.activeInHierarchy == true)
                {
                    imagesArrayArchers[i].gameObject.SetActive(false);
                    spawnArchers.Play();
                    tAG = 0f;
                    break;
                }
            }
        }
    }

    public void WarriorsTime()
    {
        
        for (int i = 0; i < imagesArrayWarriors.Length; i++)
        {
            if (tWaG > 15f)
            {
                if (imagesArrayWarriors[i].gameObject.activeInHierarchy == true)
                {
                    imagesArrayWarriors[i].gameObject.SetActive(false);
                    spawnWarriors.Play();
                    tWaG = 0f;
                    break;
                }
            }
        }
    }

    public void WorkersTime()
    {
        
        for (int i = 0; i < imagesArrayWorkers.Length; i++)
        {
            if (tWG > 10f)
            {
                if (imagesArrayWorkers[i].gameObject.activeInHierarchy == true)
                {
                    imagesArrayWorkers[i].gameObject.SetActive(false);
                    spawnWorkers.Play();
                    tWG = 0f;
                    break;
                }
            }
        }
    }

}
