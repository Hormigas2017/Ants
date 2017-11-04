using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("Contact", false);
    }

    private void OnTriggerEnter(Collider other)
    {
        anim.SetBool("Contact", true);
    }

    private void OnTriggerExit(Collider other)
    {
        anim.SetBool("Contact", false);
    }

}
