using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gamemanager : MonoBehaviour
{
    public Text Turn;
    public Text[] count = new Text[3];
    public GameObject P3icon;
    public int[] countint = { 1, 1, 1 };
    public Text countdown;
    public int PostBox;
    private int totalplayer;
    private int aidif = 2;
    private int aaa;

    public mapIndex mapIndex;
    public GameObject tileprefab;
    private readonly int Maxcount = 81;
    private int inoneline = 9;
    private List<GameObject> tile = new List<GameObject>();
    public GameObject canvas;

    private int w, h;
    private int j, q, k;
    public int turn = 0;
    private int who = 0;
    private int changewho = 1;

    private int[] type1 = { 1, -1, 9, 10, -8, -9 }; //{1,나누는 수, 나누는 수+1,-1,-나누는 수 +1, - 나누는 수}   가이드 까는 위치
    private int[] type2 = { 2, -2, 17, 18, 19, -17, -18, -19, 8, 11, -7, -10 };
    private int[] type1snSave = new int[6];                                         //가이드 지우는 용도의 저장소
    private int[] type2snSave = new int[12];
    private bool check = false;                                                     //가이드가 있는 상태인지 없는 상태인지
    private bool cantouch = true;                                                   //터치 가능한지 여부

    private int maxtile;
    private int currenttilefill;

    private int[] UndoPlayer = { -1, -1, -1, -1 };                              //무르기용, 0,2가 공격할 때 없어진 타일, 1,3이 공격한 타일
    private int[] UndoAttack = { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 };

    int tn;
    int snSave;

    Vector2 pos1;
    private void Awake()
    {
        PostBox = GameObject.Find("PostOfficer").GetComponent<PostOfficer>().totalplayer;
        w = Screen.width;
        h = Screen.height;

        for (int i = 0; i < Maxcount; i++)
        {
            GameObject a = Instantiate<GameObject>(tileprefab);
            j = i / inoneline;
            if (j % 2 == 1) k = 65;
            else k = 0;
            q = i % inoneline;

            a.gameObject.transform.position = new Vector3(w / 2 - 112.6f * 4 + j * 112.6f, h / 2 - 130 * 4 - 32.5f + 130 * q + k, 0);
            a.transform.SetParent(canvas.transform);
            a.GetComponent<tilecontroller>().SerialNumber = i;
            a.GetComponent<tilecontroller>().SerialNumberText.text = i.ToString();

            tile.Add(a);
        }                                      

        for (int i = 0; i < Maxcount; i++)
        {
            pos1 = tile[i].transform.position;

            for (int j = 0; j < 6; j++) //type1 움직일 범위
            {
                if ((i / inoneline) % 2 == 1) tn = i + type1[j];
                else
                {
                    if (j <= 1) tn = i + type1[j];
                    else tn = i + type1[j] - 1;
                }

                if (tn < 0 || tn >= Maxcount)
                {
                    type1snSave[j] = -1;
                }
                else
                {
                    Vector2 sqrdistance = new Vector2(pos1.x - tile[tn].transform.position.x, pos1.y - tile[tn].transform.position.y);
                    if (sqrdistance.sqrMagnitude < 17000) type1snSave[j] = tn;
                    else type1snSave[j] = -1;
                }
                tile[i].GetComponent<tilecontroller>().type1[j] = type1snSave[j];
            }
            //type2 움직일 범위
            for (int j = 0; j < 12; j++)
            {
                if ((i / inoneline) % 2 == 1) tn = i + type2[j];
                else
                {
                    if (j <= 7) tn = i + type2[j];
                    else tn = i + type2[j] - 1;
                }

                if (tn < 0 || tn >= Maxcount)
                {
                    type2snSave[j] = -1;
                }
                else
                {
                    Vector2 sqrdistance = new Vector2(pos1.x - tile[tn].transform.position.x, pos1.y - tile[tn].transform.position.y);
                    if (sqrdistance.sqrMagnitude < 67660) type2snSave[j] = tn;
                    else type2snSave[j] = -1;
                }
                tile[i].GetComponent<tilecontroller>().type2[j] = type2snSave[j];
            }
        }

        tileprefab.SetActive(false);

        if (PostBox == 3 || PostBox == 5)
        {
            aaa = Random.Range(40, 41);
            totalplayer = 3;
        }
        else if (PostBox ==1)
        {
            this.gameObject.GetComponent<AiSet>().aiset(aidif);

            aaa = Random.Range(0, 5);
            P3icon.SetActive(false);                                                       //3p에 관한거 지우기
            count[2].gameObject.SetActive(false);
            totalplayer = 2;
        }
        else
        {
            aaa = Random.Range(0, 5);
            P3icon.SetActive(false);                                                       //3p에 관한거 지우기
            count[2].gameObject.SetActive(false);
            totalplayer = 2;
        }

        this.mapIndex.map(aaa);
        //this.mapIndex.map(999);
    }

    private IEnumerator touchban()
    {
        cantouch = false;
        yield return new WaitForSeconds(0.3f);

        cantouch = true;
    }
    public void mapsetting2(int[] deltile, int[] P1, int[] P2)
    {
        for (int i = 0; i < deltile.Length; i++) tile[deltile[i]].SetActive(false);
        for (int i = 0; i < P1.Length; i++) tile[P1[i]].GetComponent<tilecontroller>().playerSetActive(0);
        for (int i = 0; i < P2.Length; i++) tile[P2[i]].GetComponent<tilecontroller>().playerSetActive(1);
        count[0].text = P1.Length.ToString();
        count[1].text = P2.Length.ToString();
        countint[0] = P1.Length;
        countint[1] = P2.Length;

        currenttilefill = P1.Length + P2.Length;
        maxtile = 81 - deltile.Length ;
        Debug.Log(maxtile);
    }

    public void mapsetting3(int[] deltile, int[] P1, int[] P2, int[] P3)
    {
        for (int i = 0; i < deltile.Length; i++) tile[deltile[i]].SetActive(false);
        for (int i = 0; i < P1.Length; i++) tile[P1[i]].GetComponent<tilecontroller>().playerSetActive(0);
        for (int i = 0; i < P2.Length; i++) tile[P2[i]].GetComponent<tilecontroller>().playerSetActive(1);
        for (int i = 0; i < P3.Length; i++) tile[P3[i]].GetComponent<tilecontroller>().playerSetActive(2);
        count[0].text = P1.Length.ToString();
        count[1].text = P2.Length.ToString();
        count[2].text = P3.Length.ToString();
        countint[0] = P1.Length;
        countint[1] = P2.Length;
        countint[2] = P3.Length;

        currenttilefill = P1.Length + P2.Length + P3.Length;
        maxtile = 81 - (deltile.Length + currenttilefill);
    }


    public void onclickPlayer(int sn,/* Vector2 pos, */int gal, int[] type_sn1, int[] type_sn2)
    {
        if (cantouch == true)
        {
            if (check == true)                                                                   //이동 가이드 전부 지움
            {
                for (int i = 0; i < 6; i++)
                    if (type1snSave[i] != -1) tile[type1snSave[i]].GetComponent<tilecontroller>().type[0].SetActive(false);
                for (int i = 0; i < 12; i++)
                    if (type2snSave[i] != -1) tile[type2snSave[i]].GetComponent<tilecontroller>().type[1].SetActive(false);
            }                                               //이동 가이드 전부 지움
            who = turn % totalplayer;
            if (gal == who) //내 턴일 때
            {
                snSave = sn;

                for (int i = 0; i < 6; i++)
                {
                    if (type_sn1[i] != -1 && tile[type_sn1[i]].GetComponent<tilecontroller>().onplayer == false) tile[type_sn1[i]].GetComponent<tilecontroller>().type[0].SetActive(true);
                }
                for (int i = 0; i < 12; i++)
                {
                    if (type_sn2[i] != -1 && tile[type_sn2[i]].GetComponent<tilecontroller>().onplayer == false) tile[type_sn2[i]].GetComponent<tilecontroller>().type[1].SetActive(true);
                }
                type1snSave = type_sn1;
                type2snSave = type_sn2;

                check = true;
            }                                                   //이동 가이드 찍는 코드
        }
    }
    public IEnumerator onclickAttack(int sn, int type, Vector2 pos)                    //공격공격공격공격공격공격공격공격공격공격
    {
        StartCoroutine(touchban());

        who = turn % totalplayer;
        for (int i = 0; i <= 1; i++) UndoPlayer[i] = UndoPlayer[i + 2];                     //무르기를 대비한 자료 저장
        for (int i = 0; i <= 5; i++) UndoAttack[i] = UndoAttack[i + 6];

        changewho = (turn + 1) % 2;                                                                   //상대 말 번호
        tile[sn].GetComponent<tilecontroller>().playerSetActive(who);                          //새 위치에 내 말을 만듬
        countint[who]++;
        UndoPlayer[3] = sn;

        for (int i = 0; i < 6; i++)                                                                   //이동 가이드 전부 지움
        {
            if (type1snSave[i] != -1) tile[type1snSave[i]].GetComponent<tilecontroller>().type[0].SetActive(false);
        }
        for (int i = 0; i < 12; i++)
            if (type2snSave[i] != -1) tile[type2snSave[i]].GetComponent<tilecontroller>().type[1].SetActive(false);

        yield return new WaitForSeconds(0.2f);

        for (int i = 0; i < 6; i++)                                                              //주변에 있는 상대 말 내걸로 바꿈
        {
            if ((sn / inoneline) % 2 == 1) tn = sn + type1[i];                                               //tn(주변위치)잡기
            else
            {
                if (i <= 1) tn = sn + type1[i];
                else tn = sn + type1[i] - 1;
            }

            if (tn < 0 || tn >= Maxcount)                                                            //주변 말 내걸로 바꾸기
            {
                UndoAttack[i + 6] = -1;
                continue;
            }
            else
            {
                Vector2 sqrdistance = new Vector2(pos.x - tile[tn].transform.position.x, pos.y - tile[tn].transform.position.y);
                if (sqrdistance.sqrMagnitude < 17000) {
                    if (totalplayer == 2)
                    {
                        if (tile[tn].GetComponent<tilecontroller>().player[(who + 1) % 2].activeSelf == true)
                        {
                            StartCoroutine(tile[tn].GetComponent<tilecontroller>().playerSetDeActive((who + 1) % 2));
                            countint[(who + 1) % 2]--;
                            tile[tn].GetComponent<tilecontroller>().playerSetActive(who);
                            countint[who]++;
                            UndoAttack[i + 6] = tn;
                        }
                    }
                    else if (totalplayer == 3)
                    {
                        if (tile[tn].GetComponent<tilecontroller>().player[(who + 1) % 3].activeSelf == true)
                        {
                            StartCoroutine(tile[tn].GetComponent<tilecontroller>().playerSetDeActive((who + 1) % 3));
                            countint[(who + 1) % 3]--;
                            tile[tn].GetComponent<tilecontroller>().playerSetActive(who);
                            countint[who]++;
                            UndoAttack[i + 6] = tn;
                        }
                        else if (tile[tn].GetComponent<tilecontroller>().player[(who + 2) % 3].activeSelf == true)
                        {
                            StartCoroutine(tile[tn].GetComponent<tilecontroller>().playerSetDeActive((who + 2) % 3));
                            countint[(who + 2) % 3]--;
                            tile[tn].GetComponent<tilecontroller>().playerSetActive(who);
                            countint[who]++;
                            UndoAttack[i + 6] = tn;
                        }
                    }
                }
            }
        }

        if (type == 1)                                                                         //type1에서 내 원래 말 지움
        {
            StartCoroutine(tile[snSave].GetComponent<tilecontroller>().playerSetDeActive(who));
            countint[who]--;
            UndoPlayer[2] = snSave;
        }
        else
        {
            currenttilefill++;
            UndoPlayer[2] = -1;
            Debug.Log(currenttilefill);
            if (currenttilefill == maxtile) Gameend();
        }

        check = false;
        turn++;
        Turn.text = turn.ToString();
        count[0].text = countint[0].ToString();
        count[1].text = countint[1].ToString();
        count[2].text = countint[2].ToString();
        //snSave = -1;


        if(PostBox ==1 && turn %2 == 1)
        {
            StartCoroutine(aibehaviour1());
        }

    }
    
    private IEnumerator Gameend()
    {
        yield return new WaitForSeconds(0.4f);
        cantouch = false;
        Debug.Log("게임 끝");
    }
    public void Undo()
    {
        for (int i = 6; i <= 11; i++)
        {
            if (UndoAttack[i] != -1)
            {
                tile[UndoAttack[i]].GetComponent<tilecontroller>().player[changewho].SetActive(true);
                countint[changewho]++;
                tile[UndoAttack[i]].GetComponent<tilecontroller>().player[who].SetActive(false);
                countint[who]--;
            }
        }
        if (UndoPlayer[2] != -1)
        {
            tile[UndoPlayer[2]].GetComponent<tilecontroller>().playerSetActive(who);
            countint[who]++;
        }
        if (UndoPlayer[3] != -1)
        {
            StartCoroutine(tile[UndoPlayer[3]].GetComponent<tilecontroller>().playerSetDeActive(who));
            countint[who]--;
        }

        for (int i = 0; i <= 5; i++)
        {
            if (UndoAttack[i] != -1)
            {
                tile[UndoAttack[i]].GetComponent<tilecontroller>().player[changewho].SetActive(false);
                countint[changewho]--;
                tile[UndoAttack[i]].GetComponent<tilecontroller>().player[who].SetActive(true);
                countint[who]++;
            }
        }
        if (UndoPlayer[0] != -1)
        {
            tile[UndoPlayer[0]].GetComponent<tilecontroller>().playerSetActive(changewho);
            countint[changewho]++;
        }
        if (UndoPlayer[1] != -1)
        {
            StartCoroutine(tile[UndoPlayer[1]].GetComponent<tilecontroller>().playerSetDeActive(changewho));
            countint[changewho]--;
        }

        turn = turn - 2;
        Turn.text = turn.ToString();
        count[0].text = countint[0].ToString();
        count[1].text = countint[1].ToString();
        check = false;
    }

    //ai

    public int[] aidifficulty = { 0, 0, 0, 0, 0 };                               //내 타일 주변 내 타일, 상대 타일,복사 점수,이동 마이너스점수, 움직일 곳 주변 상대 타일 각 점수
    private int[] aisn = { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 };      //20개 위치 잡음
    private int[,] aitn = new int[20, 18];
    private int[,] aiscore = new int[20, 18];
    private int aiscoreseq;
    private int aiscoresep;
    private int maxaiscore;
    private int[] finalmove = new int[2];
    private int thinkcount = 20;
    IEnumerator aibehaviour1()
    {
        yield return new WaitForSeconds(0.6f);
        if (cantouch == true)
        {
            //  aisn에 계산할 ai의 위치들 계산
            for (int i = 0; i < thinkcount; i++) aisn[i] = -1;

            if ((turn / 4) % 2 == 0)
            {
                for (int i = 0; i <= 80; i++)
                {
                    if (tile[i].GetComponent<tilecontroller>().player[1].activeSelf == true)
                    {
                        for (int j = 0; j < thinkcount; j++)
                        {
                            if (aisn[j] == -1)
                            {
                                aisn[j] = i;
                                break;
                            }
                        }
                        if (aisn[thinkcount - 1] != -1) break;
                    }
                }
            }
            else
            {
                for (int i = 80; i >= 0; i--)
                {
                    if (tile[i].GetComponent<tilecontroller>().player[1].activeSelf == true)
                    {
                        for (int j = 0; j < thinkcount; j++)
                        {
                            if (aisn[j] == -1)
                            {
                                aisn[j] = i;
                                break;
                            }
                        }
                        if (aisn[thinkcount - 1] != -1) break;
                    }
                }
            }
            //aitn에 계산할 위치들 대입
            for (int j = 0; j < thinkcount; j++)
            {
                if (aisn[j] == -1) break;
                int sn = aisn[j];

                for (int i = 0; i < 6; i++)
                {
                    aitn[j, i] = tile[sn].GetComponent<tilecontroller>().type1[i];
                    if (aitn[j, i] != -1 && (tile[aitn[j, i]].GetComponent<tilecontroller>().onplayer == true || tile[aitn[j, i]].activeSelf == false)) aitn[j, i] = -1;
                }

                for (int i = 0; i < 12; i++)
                {
                    aitn[j, i + 6] = tile[sn].GetComponent<tilecontroller>().type2[i];
                    if (aitn[j, i + 6] != -1 && (tile[aitn[j, i + 6]].GetComponent<tilecontroller>().onplayer == true || tile[aitn[j, i + 6]].activeSelf == false)) aitn[j, i + 6] = -1;
                }
            }
            //aiscore 대입하는 코드
            for (int j = 0; j < thinkcount; j++)
            {
                if (aisn[j] == -1)
                {
                    for (int i = 0; i < 18; i++) aiscore[j, i] = -5;
                    break;
                }

                for (int i = 0; i < 18; i++)
                {
                    if (aitn[j, i] == -1)
                    {
                        aiscore[j, i] = -5;
                        continue;
                    }
                    else
                    {
                        int sn = aitn[j, i];
                        if (i <= 5) aiscoresep = aidifficulty[2];
                        else aiscoresep = aidifficulty[3];

                        for (int k = 0; k < 6; k++)
                        {
                            if ((sn / inoneline) % 2 == 1) tn = sn + type1[k];
                            else
                            {
                                if (k <= 1) tn = sn + type1[k];
                                else tn = sn + type1[k] - 1;
                            }

                            if (tn < 0 || tn >= Maxcount)
                            {
                                continue;
                            }
                            else
                            {
                                Vector2 sqrdistance = new Vector2(tile[sn].transform.position.x - tile[tn].transform.position.x, tile[sn].transform.position.y - tile[tn].transform.position.y);
                                if (tile[tn].GetComponent<tilecontroller>().player[0].activeSelf == true && sqrdistance.sqrMagnitude < 17000)
                                {
                                    aiscoresep += aidifficulty[4];
                                }
                            }
                        }

                        if (i < 6) aiscore[j, i] = aiscoresep;
                        else
                        {
                            aiscoreseq = 0;
                            for (int k = 0; k < 6; k++)
                            {
                                if ((aisn[j] / inoneline) % 2 == 1) tn = aisn[j] + type1[k];
                                else
                                {
                                    if (k <= 1) tn = aisn[j] + type1[k];
                                    else tn = aisn[j] + type1[k] - 1;
                                }

                                if (tn < 0 || tn >= Maxcount)
                                {
                                    continue;
                                }
                                else
                                {
                                    Vector2 sqrdistance = new Vector2(tile[aisn[j]].transform.position.x - tile[tn].transform.position.x, tile[aisn[j]].transform.position.y - tile[tn].transform.position.y);
                                    if (sqrdistance.sqrMagnitude < 17000)
                                    {
                                        if (tile[tn].GetComponent<tilecontroller>().player[0].activeSelf == true)
                                        {
                                            aiscoreseq += aidifficulty[1];
                                        }
                                        else if (tile[tn].GetComponent<tilecontroller>().player[1].activeSelf == true)
                                        {
                                            aiscoreseq += aidifficulty[0];
                                        }
                                    }
                                }
                            }

                            aiscore[j, i] = aiscoresep + aiscoreseq;
                        }
                    }
                }
            }
            maxaiscore = -99;
            //최대값 위치 찾기
            for (int j = 0; j < thinkcount; j++)
            {
                for (int i = 0; i <= 17; i++)
                {
                    if (aiscore[j, i] >= maxaiscore)
                    {
                        maxaiscore = aiscore[j, i];
                        finalmove[0] = j;
                        finalmove[1] = i;
                    }
                }
            }

            //Debug.Log(maxaiscore);
            //Debug.Log(aisn[finalmove[0]]);                                                      //출발위치
            //Debug.Log(aitn[finalmove[0], finalmove[1]]);                                        //도착위치

            if (finalmove[1] >= 6)
            {
                snSave = aisn[finalmove[0]];
                StartCoroutine(onclickAttack(aitn[finalmove[0], finalmove[1]], 1, tile[aitn[finalmove[0], finalmove[1]]].GetComponent<tilecontroller>().transform.position));
            }
            else StartCoroutine(onclickAttack(aitn[finalmove[0], finalmove[1]], 0, tile[aitn[finalmove[0], finalmove[1]]].GetComponent<tilecontroller>().transform.position));

        }
    }
    void Start()
    {

    }
    void Update()
    {
        
    }

}
