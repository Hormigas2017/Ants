﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Missions : MonoBehaviour
{
    Toggle[] toggles;

    void Start ()
    {
        toggles = GetComponentsInChildren<Toggle>();

        SurvivalTime.OnTwoMinutes += CheckSurivalTime;
        CreateButton.OnFiveArchers += CkeckFiveArchers;
        Grasshopper.OnDieGrasshopper += CheckDieGrasshoppers;
	}

    public void CheckSurivalTime()
    {
        toggles[0].isOn = true;

    }

    public void CkeckFiveArchers()
    {
        toggles[1].isOn = true;
    }

    public void CheckDieGrasshoppers()
    {
        toggles[2].isOn = true;
    }
}
