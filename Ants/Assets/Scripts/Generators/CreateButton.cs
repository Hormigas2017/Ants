using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateButton : MonoBehaviour
{
    InputField mInputField;
    string stringNumber;
    char[] charArray;

    // Use this for initialization
    void Start ()
    {
        mInputField = GetComponent<InputField>();
    }
	
	// Update is called once per frame
	void Update () {
        NumberOFAnts();

    }

    public void NumberOFAnts()
    {
        if (mInputField.text != null)
        {
            mInputField.text = stringNumber;
        }

        for (int i = 0; i <= charArray.Length; i++)
        {
            charArray = stringNumber.ToCharArray();
        }
        Debug.Log(charArray);
    }
}
