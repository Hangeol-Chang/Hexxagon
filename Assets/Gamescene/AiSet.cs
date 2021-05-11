using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiSet : MonoBehaviour
{
    // Start is called before the first frame update
    private int[] aindex;
              //내 타일 주변 내 타일, 상대 타일,복사 점수,이동 마이너스점수, 움직일 곳 주변 상대 타일 각 점수
    public void aiset(int i)
    {
        switch (i)
        {
            case 1:
                aindex = new int[] { -2, 1, 1, -3, 2 };
                break;
            case 2:
                aindex = new int[] { -4, 1, 1, -3, 2 };                                 //노말
                break;
            case 3:
                aindex = new int[] { -5, 5, 2, -2, 4 };
                break;
            case 4:
                aindex = new int[] { -6, 3, 2, 0, 5 };
                break;
            case 5:
                aindex = new int[] { -2, 3, 2, 0, 5 };
                break;
            case 6:
                aindex = new int[] { -1, 1, 2, 0, 3 };              //괜찮음
                break;
            case 7:
                aindex = new int[] { 1, 3, 2, 0, 1 };               //소극적
                break;
        }

        this.gameObject.GetComponent<Gamemanager>().aidifficulty = aindex;
    }
}
