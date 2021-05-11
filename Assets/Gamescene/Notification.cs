using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Notification : MonoBehaviour
{
    public Text noti;
    public IEnumerator Notiup(int time, string note)
    {
        if (this.gameObject.activeSelf == false)
        {
            this.gameObject.SetActive(true);

            noti.text = note;
            yield return new WaitForSeconds(time);

            this.gameObject.SetActive(false);
        }
    }
    void Awake()
    {
        this.gameObject.SetActive(false);
    }
}
