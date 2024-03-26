using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlGuadaña : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator anim;
    public int danioGuadania;
    void Start()
    {
        anim = GetComponent<Animator>();
        GetComponent<BoxCollider2D>().enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            anim.SetBool("Golpeando", true);
            GetComponent<BoxCollider2D>().enabled = true;
            Debug.Log(anim);
        }
    }
    public void endAtackAnimation()
    {
        anim.SetBool("Golpeando", false);
        GetComponent<BoxCollider2D>().enabled = false;

    }
}
