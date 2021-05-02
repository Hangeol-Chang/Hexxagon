using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bgcontroller : MonoBehaviour
{
    SpriteRenderer render;
    float a;
    private float normalalpha = 0.65f;
    private int timeconst = 4;
    void Start()
    {
        render = GetComponent<SpriteRenderer>();
        InvokeRepeating("gg", 0,0.1f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void gg()
    {
        a = Time.time % timeconst;
        if ((Time.time / timeconst) % 2 < 1) render.color = new Color(1, 1, 1, normalalpha + 0.075f * a);
        else render.color = new Color(1, 1, 1, normalalpha + 0.3f - 0.075f * a);
    }
}
