using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateButton : MonoBehaviour
{
    Transform mTrans;
    Transform mCanvas;

    Image antAG;

    float t = 0.0f;
    public Image[] imagesArray = new Image[10];

    // Use this for initialization
    void Start ()
    {
        antAG = GameObject.Find("AntAG").GetComponent<Image>();
        mTrans = GameObject.Find("AntAG").GetComponent<Transform>();
        mCanvas = GameObject.Find("WhiteBackGround").GetComponent<Transform>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        t += Time.deltaTime;
    }

    public void NumAntsAG()
    {
        for (int i = 0; i < imagesArray.Length; i++)
        {
            if (t > 1)
            {
                float xy = 5f;
                Vector3 changePos = new Vector3(xy, xy, 0);
                imagesArray[i] = Instantiate(antAG, mCanvas.position, Quaternion.identity);
                t = 0f;
            }
            i++;
        }
    }
}
