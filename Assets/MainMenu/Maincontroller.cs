using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maincontroller : MonoBehaviour
{
    public GameObject ngs;
    public void OCnewgame()
    {
        Debug.Log("New Game");
        ngs.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
