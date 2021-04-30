using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapIndex : MonoBehaviour
{
    public Gamemanager gamemanager;
    private int[] index;
    private int[] P1;
    private int[] P2;
    private int[] P3;

    public void map(int i)
    {
        if (i == 0)
        {
            int[] index = { 0, 1, 7, 8, 9, 16, 17, 18, 26, 35, 53, 54, 62, 63, 70, 71, 72, 73, 79, 80 };
            int[] P1 = { 2, 74, 44 };
            int[] P2 = { 6, 36, 78 };
            gamemanager.mapsetting2(index, P1, P2);
        }
        else if (i == 1)
        {
            int[] index = { 0, 1, 7, 8, 9, 16, 17, 18, 26, 35, 53, 54, 62, 63, 70, 71, 72, 73, 79, 80, 31, 39, 49 };
            int[] P1 = { 2, 74, 44 };
            int[] P2 = { 6, 36, 78 };
            gamemanager.mapsetting2(index, P1, P2);
        }
        else if (i == 2)
        {
            int[] index = { 0, 1, 7, 8, 9, 16, 17, 18, 26, 35, 53, 54, 62, 63, 70, 71, 72, 73, 79, 80, 31, 39, 49,30,41,48 };
            int[] P1 = { 2, 74, 44 };
            int[] P2 = { 6, 36, 78 };
            gamemanager.mapsetting2(index, P1, P2);
        }
        else if (i == 3)
        {
            int[] index = { 0,2,4,6,8,10,11,12,13,14,15,17,18,19,21,23,25,26,28,29,30,31,32,33,35,38,49,42,46,47,48,49,50,51,53,
                            54,55,57,59,61,62,64,65,66,67,68,69,71,72,74,76,78,80};
            int[] P1 = { 36 };
            int[] P2 = { 44 };
            gamemanager.mapsetting2(index, P1, P2);
        }
        else if (i == 4)
        {
            int[] index = { 0,2,4,5,7,9,10,11,12,14,15,16,17,18,19,21,22,23,24,26,28,29,31,33,34,36,39,40,41,42,46,47,49,51,52,54,55,57,
                            58,59,60,62,63,64,65,66,68,69,70,71,72,74,76,77,79};
            int[] P1 = { 37 };
            int[] P2 = { 44 };
            gamemanager.mapsetting2(index, P1, P2);
        }
        else if (i == 40)
        {
            int[] index = { 0, 1, 7, 8, 9, 16, 17, 18, 26, 35, 53, 54, 62, 63, 70, 71, 72, 73, 79, 80 };
            int[] P1 = { 2,78 };
            int[] P2 = { 6,74 };
            int[] P3 = { 36,44};
            gamemanager.mapsetting3(index, P1, P2, P3);
        }
        else if (i == 999)                      //테스트용 풀맵
        {
            int[] index = null;
            int[] P1 = { 36 };
            int[] P2 = { 44 };
            gamemanager.mapsetting2(index, P1, P2);
        }
        else
        {
            int[] index = { 0, 1, 7, 8, 9, 16, 17, 18, 26, 35, 53, 54, 62, 63, 70, 71, 72, 73, 79, 80 };
            int[] P1 = { 2, 74, 44 };
            int[] P2 = { 6, 36, 78 };
            gamemanager.mapsetting2(index, P1, P2);
        }

    }
    
}
/*

*/
