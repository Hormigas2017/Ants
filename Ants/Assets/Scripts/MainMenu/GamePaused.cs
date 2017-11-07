using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePaused : MonoBehaviour {

    GameObject canvasPaused;
    GameObject canvasSource;

    private void Awake()
    {
        canvasPaused = GameObject.Find("CanvasPaused");
        canvasSource = GameObject.Find("CanvasSources"); 
        canvasPaused.SetActive(false);
        canvasSource.SetActive(false);
    }

    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (canvasPaused.activeInHierarchy == false)
            {
                canvasPaused.SetActive(true);
                canvasSource.SetActive(false);
                Time.timeScale = 0;
            }
            else
            {
                canvasPaused.gameObject.SetActive(false);
                canvasSource.SetActive(true);
                Time.timeScale = 1;
            }
        }
	}

    public void Resume() {

        if (canvasPaused.activeInHierarchy == true)
        {
            canvasPaused.SetActive(false);
            canvasSource.SetActive(true);
            Time.timeScale = 1;
        }
    }
}
