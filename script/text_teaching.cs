using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class text_teaching : MonoBehaviour
{
    // Start is called before the first frame 
    public Text word;
    public GameObject[] walls;
    public GameObject[] point;
    public GameObject[] balls;
    public GameObject[] next;

    int[] ball_at = { 0, 0, 0 };

    // public float timelimt;

    int at = 0;
    void Start()
    {

        walls[0].gameObject.SetActive(false);
        next[0].gameObject.SetActive(false);
        next[1].gameObject.SetActive(false);
        //walls[1].GetComponent<changeColor>().a2(5);

    }
    float time = 0;
    string[] w ={
        "Welcome","Let","Music"
        ,"歡迎來到教學區","這是款360°的音樂遊戲","四面八方都會有打擊點的產生" 
        ,"這是我們的打擊範圍"
        ,"遊戲有2種關卡","分為","簡單 EASY","困難 HARD","大家要加油喔 ! ! !"
        ,"遊戲打擊方式有三種","單點","長壓","移動"
        ,"在中間長滿變色的時候","就是我們的打擊時刻"
        ,"當我們看到黃色的提示箭頭時","順著箭頭的方向看過去","就可以看到我們下一個打擊點囉~"
        ,"那我們教學的部份就到這裡啦~~","讓我們趕快開始遊戲吧~~~!!"


    };
    float[] TT ={
        0,3.4f,4.2f
        ,6.2f,8.7f,11.7f
        ,14.7f
        ,17.2f,19.7f,21.7f,24.2f,26.7f
        ,31.7f,34.2f,42,48
        ,54,56.5f
        ,59,61,63.5f
        ,74,77
        
    };
    // Update is called once per frame
    void Update()
    {

        time += Time.deltaTime;
        if (time > TT[at] - Time.deltaTime && time <= TT[at] + Time.deltaTime)
        {
            // Debug.Log(TT.Length+" : "+at);
            word.text = w[at];
            if (at < TT.Length - 1)
                at++;
        }
        //----build the walls
        if (time > 15.5f - Time.deltaTime && time <= 15.5f + Time.deltaTime)
        {
            walls[0].gameObject.SetActive(true);

        }
        if (time > 35f - Time.deltaTime && time <= 35 + Time.deltaTime)
        {
            point_1(28);
            point_1(32);
            point_1(38);
        }
        if (time > 37 - Time.deltaTime && time <= 37 + Time.deltaTime)
        {
            point_1(28);
            point_1(32);
            point_1(38);
        }
        if (time > 39 - Time.deltaTime && time <= 39 + Time.deltaTime)
        {
            point_1(28);
            point_1(32);
            point_1(38);
        }
        if (time > 43 - Time.deltaTime && time <= 43 + Time.deltaTime)
        {
            point_2(28, 0.01f);
            point_2(32, 0.01f);
            point_2(38, 0.01f);
        }
        if (time > 49 - Time.deltaTime && time <= 49 + Time.deltaTime)
        {
            int[] at = { 28, 32, 38, 36, 26 };
            point_3(at, 0.03f);

        }
        //
        if (time > 66.5f - Time.deltaTime && time <= 66.5f + Time.deltaTime)
        {
            walls[1].GetComponent<changeColor>().a1(3, 3);
        }
        if (time > 70f - Time.deltaTime && time <= 70f + Time.deltaTime)
        {
            walls[1].GetComponent<changeColor>().a1_back(3, 3);
        }
        if (time > 79.5f - Time.deltaTime && time <= 79.5f + Time.deltaTime)
        {
           next[0].gameObject.SetActive(true);
           next[1].gameObject.SetActive(true);
           walls[0].gameObject.SetActive(false);


        }


    }
    void point_1(int hit)
    {
        Vector3 pp;
        Quaternion qq;
        pp = walls[0].transform.GetChild(hit).transform.position;
        qq = Quaternion.Euler(new Vector3(0, 0, 0));

        Instantiate(point[0], pp, qq, balls[0].transform).GetComponent<growUP>().wall = walls[0].transform.GetChild(hit).gameObject;
    }
    void point_2(int hit, float timelimit)
    {
        Vector3 pp;
        Quaternion qq;
        pp = walls[0].transform.GetChild(hit).transform.position;
        qq = Quaternion.Euler(new Vector3(0, 0, 0));

        Instantiate(point[1], pp, qq, balls[1].transform).GetComponent<up>().setPOINT(walls[0].transform.GetChild(hit).gameObject, timelimit);


    }
    void point_3(int[] hit, float timelimit)
    {
        Vector3 pp;
        Quaternion qq;
        pp = new Vector3(0, 0, 0);
        qq = Quaternion.Euler(new Vector3(0, 0, 0));

        Instantiate(point[2], pp, qq, balls[1].transform).GetComponent<lineUP>().setPOINT(hit, timelimit, walls[0]);
    }
}
