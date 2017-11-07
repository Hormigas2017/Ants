using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Missions : MonoBehaviour
{
    Toggle[] toggles;

    AudioSource missionWin;

    void Start ()
    {
        toggles = GetComponentsInChildren<Toggle>();
        missionWin = GameObject.Find("MissionComplete").GetComponent<AudioSource>();

        SurvivalTime.OnTwoMinutes += CheckSurivalTime;
        CreateButton.OnFiveArchers += CkeckFiveArchers;
        Grasshopper.OnDieGrasshopper += CheckDieGrasshoppers;
	}

    public void CheckSurivalTime()
    {
        toggles[0].isOn = true;
        missionWin.Play();
    }

    public void CkeckFiveArchers()
    {
        toggles[1].isOn = true;
        missionWin.Play();
    }

    public void CheckDieGrasshoppers()
    {
        toggles[2].isOn = true;
        missionWin.Play();
    }
}
