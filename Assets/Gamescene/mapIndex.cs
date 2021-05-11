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
    private string mapname;

    public void map(int i)
    {
        switch (i)
        {
            case 0:
                index = new int[] { 0, 1, 7, 8, 9, 16, 17, 18, 26, 35, 53, 54, 62, 63, 70, 71, 72, 73, 79, 80 };
                P1 = new int[] { 2, 74, 44 };
                P2 = new int[] { 6, 36, 78 };
                mapname = "vainilla";
                gamemanager.mapsetting2(index, P1, P2, mapname);
                break;
            case 1:
                index = new int[] { 0, 1, 7, 8, 9, 16, 17, 18, 26, 35, 53, 54, 62, 63, 70, 71, 72, 73, 79, 80, 31, 39, 49 };
                P1 = new int[] { 2, 74, 44 };
                P2 = new int[] { 6, 36, 78 };
                mapname = "Three Bridge";
                gamemanager.mapsetting2(index, P1, P2, mapname);
                break;
            case 2:
                index = new int[] { 0, 1, 7, 8, 9, 16, 17, 18, 26, 35, 53, 54, 62, 63, 70, 71, 72, 73, 79, 80, 31, 39, 49, 30, 41, 48 };
                P1 = new int[] { 2, 74, 44 };
                P2 = new int[] { 6, 36, 78 };
                mapname = "island";
                gamemanager.mapsetting2(index, P1, P2, mapname);
                break;
            case 3:
                index = new int[] { 0, 1, 4, 7, 8, 9, 12, 13, 16, 17, 18, 22, 26, 30, 31, 35, 40, 48, 49, 53, 54, 58, 62, 63, 66, 67, 70, 71, 72, 73, 76, 79, 80 };
                P1 = new int[] { 27, 36, 45 };
                P2 = new int[] { 34, 44, 52 };
                mapname = "seperated";
                gamemanager.mapsetting2(index, P1, P2, mapname);
                break;
            case 4:
                index = new int[] {0,1, 7, 8, 9, 11, 12, 13, 14, 16, 17, 18, 20, 24, 26, 28, 33, 35, 37, 43, 46, 51, 53, 54, 56, 60, 62, 63, 65, 66, 67, 68, 70, 71, 72, 73, 79, 80 };
                P1 = new int[] { 6, 36, 78 };
                P2 = new int[] { 2, 44, 74 };
                mapname = "Giant island";
                gamemanager.mapsetting2(index, P1, P2, mapname);
                break;
            case 5:
                index = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 35, 53, 54, 55, 56, 57, 58, 59, 60, 61, 62, 63, 64, 65, 66, 67, 68, 69, 70, 71, 72, 73, 74, 75, 76, 77, 78, 79, 80 };
                P1 = new int[] { 36 };
                P2 = new int[] { 44 };
                mapname = "Death match";
                gamemanager.mapsetting2(index, P1, P2, mapname);
                break;
            case 6:
                index = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 15, 16, 17, 18, 19, 25, 26, 27, 34, 35, 36, 44, 45, 52, 53, 54, 55, 61, 62, 63, 64, 69, 70, 71, 72, 73, 74, 75, 76, 77, 78, 79, 80 };
                P1 = new int[] { 14, 37, 68 };
                P2 = new int[] { 11, 43, 65 };
                mapname = "투기장";
                gamemanager.mapsetting2(index, P1, P2, mapname);
                break;
            case 7:
                index = new int[] { 5, 6, 7, 8, 14, 15, 16, 17, 18, 24, 25, 26, 27, 33, 34, 35, 36, 37, 40, 43, 44, 45, 46, 52, 53, 54, 55, 56, 62, 63, 64, 65, 71, 72, 73, 74, 75 };
                P1 = new int[] { 29 };
                P2 = new int[] { 50 };
                mapname = "death match2";
                gamemanager.mapsetting2(index, P1, P2, mapname);
                break;
            case 8:
                index = new int[] { 0, 1, 2, 3, 6, 7, 8, 12,14, 18, 22, 23, 27, 31, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 49, 53, 54, 58, 59, 66, 68, 72, 73, 74, 75, 78, 79, 80 };
                P1 = new int[] { 32, 48 };
                P2 = new int[] { 30, 50 };
                mapname = "6 island";
                gamemanager.mapsetting2(index, P1, P2, mapname);
                break;
            case 9:
                index = new int[] { 0, 1, 3, 7, 8, 9, 11,13,14, 16, 17, 18, 20, 22, 23, 24, 26, 28, 30, 33, 35, 37, 39, 41, 43, 46, 48, 49, 51, 53, 54, 56, 60, 62, 63, 65, 66, 67, 68, 70, 71, 72, 73, 79, 80 };
                P1 = new int[] { 2 };
                P2 = new int[] { 40 };
                mapname = "spiral";
                gamemanager.mapsetting2(index, P1, P2, mapname);
                break;
            case 10:
                index = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 26, 30, 31, 35, 40, 48, 49, 53, 54, 62, 63, 64, 65, 66, 67, 68, 69, 70, 71, 72, 73, 74, 75, 76, 77, 78, 79, 80 };
                P1 = new int[] { 36, 41 };
                P2 = new int[] { 39, 44 };
                mapname = "Two Bridge";
                gamemanager.mapsetting2(index, P1, P2, mapname);
                break;
            case 40:
                index = new int[] { 0, 1, 7, 8, 9, 16, 17, 18, 26, 35, 53, 54, 62, 63, 70, 71, 72, 73, 79, 80 };
                P1 = new int[] { 2, 78 };
                P2 = new int[] { 6, 74 };
                P3 = new int[] { 36, 44 };
                mapname = "vainilla";
                gamemanager.mapsetting3(index, P1, P2, P3, mapname);
                break;
            case 41:
                index = new int[] { 0, 1, 4, 5, 6, 7, 8, 9, 13, 14, 15, 16, 17, 18, 19, 23, 24, 25, 26, 27, 28, 35, 36, 37, 38, 45, 46, 53, 54, 55, 59, 60, 61, 62, 63, 67, 68, 69, 70, 71, 72, 73, 76, 77, 78, 79, 80 };
                P1 = new int[] { 2 };
                P2 = new int[] { 44 };
                P3 = new int[] { 74 };
                mapname = "Death match";
                gamemanager.mapsetting3(index, P1, P2, P3, mapname);
                break;
            case 42:
                index = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 15, 16, 17, 18, 19, 25, 26, 27, 34, 35, 36, 44, 45, 52, 53, 54, 55, 61, 62, 63, 64, 69, 70, 71, 72, 73, 74, 75, 76, 77, 78, 79, 80 };
                P1 = new int[] { 14, 43 };
                P2 = new int[] { 11, 68 };
                P3 = new int[] { 14, 56 };
                mapname = "투기장";
                gamemanager.mapsetting3(index, P1, P2, P3, mapname);
                break;
            case 999:
                index = null;
                P1 = new int[] { 36 };
                P2 = new int[] { 44 };
                mapname = "Debug";
                gamemanager.mapsetting2(index, P1, P2, mapname);
                break;


        }
    }
    
}
/*

*/
