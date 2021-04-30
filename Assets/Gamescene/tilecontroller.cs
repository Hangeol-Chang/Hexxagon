using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tilecontroller : MonoBehaviour
{
    public GameObject[] type = new GameObject[2];
    public GameObject[] player = new GameObject[3];
    public Text SerialNumberText;
    public int SerialNumber;
    public int[] type1 = new int[6];
    public int[] type2 = new int[12];

    public GameObject gm;
    public bool onplayer = false;

    // Start is called before the first frame update
    private void OnEnable()
    {
        for ( int i = 0; i <2 ; i++)
        {
            type[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < 3; i++)
        {
            player[i].gameObject.SetActive(false);
        }

    }
    public void onclick()
    {
        if (this.player[0].activeSelf == true)
            gm.GetComponent<Gamemanager>().onclickPlayer(SerialNumber, 0, type1, type2);
        else if (this.player[1].activeSelf == true)
            gm.GetComponent<Gamemanager>().onclickPlayer(SerialNumber, 1, type1, type2);
        else if (this.player[2].activeSelf == true)
            gm.GetComponent<Gamemanager>().onclickPlayer(SerialNumber, 2, type1, type2);
        else if (this.type[0].activeSelf == true)
            StartCoroutine(gm.GetComponent<Gamemanager>().onclickAttack(SerialNumber, 0, this.transform.position));
        else if (this.type[1].activeSelf == true)
            StartCoroutine(gm.GetComponent<Gamemanager>().onclickAttack(SerialNumber, 1, this.transform.position));
    }
    
    public void playerSetActive(int num)
    {
        player[num].SetActive(true);
        onplayer = true;
    }
    
    public IEnumerator playerSetDeActive(int num)
    {
        onplayer = false;
        player[num].GetComponent<Animator>().SetBool("Close", true);

        yield return new WaitForSeconds(0.25f);
        player[num].GetComponent<Animator>().SetBool("Close", false);
        player[num].SetActive(false);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

}
