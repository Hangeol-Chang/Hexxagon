using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGameSelect : MonoBehaviour
{
    public GameObject main;
    public GameObject backbt;
    public GameObject[] Local = new GameObject[3];
    public GameObject po;
    
    public void back()
    {
        main.SetActive(true);
        this.gameObject.SetActive(false);
    }

    public void Local1P()
    {
        po.GetComponent<PostOfficer>().totalplayer = 1;
        SceneManager.LoadScene("GameScene");
        DontDestroyOnLoad(po);
    }
    public void Local2P()
    {
        po.GetComponent<PostOfficer>().totalplayer = 2;
        SceneManager.LoadScene("GameScene");
        DontDestroyOnLoad(po);
    }

    public void Local3P()
    {
        po.GetComponent<PostOfficer>().totalplayer = 3;
        SceneManager.LoadScene("GameScene");
        DontDestroyOnLoad(po);
    }
}
