using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class N_music : MonoBehaviour
{
    public GameObject hitALL;

    public GameObject[] walls;
    public GameObject[] point;
    public GameObject[] balls;


    int have =0;

    // Start is called before the first frame update
    int beat_at=0;
    int light_at=0;
    int long_beat_at=0;
    int line_beat_at=0;
    float beat = ((60f / 70f) / 4f);
    public Material[] color;
    float time=0;
    void Start()
    {
        
    }
    int[] hit_where=new int[]{
        3,7,17,23,11,5,15,12,22,18,12,22,33,43,32,26,
36,46,37,83,87,81,85,90,91,87,102,112,101,
111,95,110,107,117,16,20,32,38,42,52,60,70,
66,72,67,73,79,83,82,81,53,63,57,67,58,
52,46,40,36,32,28,18,22,16,15,32,37,42,
47,33,42,35,41,42,48,54,58,52,56,61,72,
63,69,59,53,52,51,50,35,41,36,42,38,44,
34,33,32,48,41,51,29,19,18,28,63,
67,70,81,89,98,17,22,33,32,31,36,41,18,
17,11,16,21,26,31,22,27,33,29,28,27,31,
37,33,39,44,47,53,58,63,62,67,66,71,75,
81,77,83,93,97,101,105,113,119
    };
 int[] hit_beat=new int[]{
        32,40,48,56,64,70,71,72,76,80,86,87,88,92,96,100,
102,120,124,144,148,150,152,156,160,164,176,177,178,
179,184,188,192,194,208,210,224,226,240,242,268,270,
272,276,277,280,281,282,283,284,304,308,318,319,340,
341,344,345,346,347,348,364,366,368,369,384,385,386,
387,400,404,416,421,422,424,426,432,437,438,448,453,
454,456,460,464,465,466,467,472,476,480,482,488,492,
496,501,502,512,517,518,528,529,536,540,560,
563,576,579,592,595,628,629,632,633,634,635,636,660,
661,664,665,666,667,668,692,693,712,716,724,725,728,
729,730,731,732,744,748,752,753,754,755,760,764,768,
769,770,771,776,780,784,787,800,802
    };

    int[] long_hit_where = new int[]
    {
37,47,35,43,98,26,46,41,43,24,44,
31,50,38,42,32,59,71,88,107,11,4,24,
16,20,40,45,111
    };

    int[] long_hit_beat = new int[]
    {
104,108,112,128,168,216,248,296,336,352,392,
408,440,504,520,524,552,568,584,600,616,648,652,
680,696,736,740,792
    };

    int[] long_hit_time = new int[]
    {
4,4,8,8,8,8,8,8,8,4,8,
8,8,8,4,4,8,8,8,8,8,4,4,
8,8,4,4,8
    };
    int[,] line_hit_where = new int[,]
    {{119,2,13,17},{42,39,32,35},{56,63,73,66},
        {71,78,81,88},{17,26,37,28},{113,117,3,7},
       {33,31,22,23},{22,29,32,39}

    };

    int[] line_hit_beat = new int[]
    {
        200,232,256,320,376,608,672,704
    };

    int[] line_hit_time = new int[]
    {

8,8,8,8,8,8,8,8
    };
    //right 0 left 1
    
    int[] lights_time_at = new int[]
     {
         150,302,343,559,655
     };
    int[] lights_turn = new int[]
    {
        0,1,1,0,1
    };
    int[] lights_begin = new int[]
    {
        2,10,6,23,8
    };

    float grow = -5f;

    float long_time_to_hit(int T)
    {
        switch (T)
        {
            case 4:
                return 0.0005f;
            case 8:
                return 0.001f;
            default:
                return 0.04f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //StartCoroutine(playNOW());

        time += Time.deltaTime;
        float beat_time = hit_beat[beat_at] * beat - 1.2f;
        float starttime = 36 * beat;
        if (time >= starttime - Time.deltaTime && time < starttime + Time.deltaTime)
        {
            walls[1].GetComponent<changeColor>().a1(12, 21);
            walls[1].GetComponent<changeColor>().a1_back(10, 1);
            //walls[1].GetComponent<changeColor>().a2(2);

        }
        if (time + grow >= beat_time - Time.deltaTime && time + grow < beat_time + Time.deltaTime)
        {
            //Debug.Log("red: " + hit_beat[beat_at]);
            point_1(hit_where[beat_at]);
            if (beat_at < hit_beat.Length - 1)
                beat_at++;
            //walls[1].GetComponent<changeColor>().a1(12, 1);
        }

        float long_beat_time = long_hit_beat[long_beat_at] * beat - 1.25f;
        if (time + grow >= long_beat_time - Time.deltaTime && time + grow < long_beat_time + Time.deltaTime)
        {
            Debug.Log(long_hit_beat[long_beat_at]);
            float timelimit = long_time_to_hit(long_hit_time[long_beat_at]);
            //Debug.Log(timelimit);
            point_2(long_hit_where[long_beat_at], timelimit);
            if (long_beat_at < long_hit_beat.Length - 1)
                long_beat_at++;
        }

        float line_beat_time = line_hit_beat[line_beat_at] * beat - 1.5f;
        if (time + grow >= line_beat_time - Time.deltaTime && time + grow < line_beat_time + Time.deltaTime)
        {
            int[] buf = { 0, 0, 0, 0 };

            for (int i = 0; i < line_hit_where.GetLength(1); i++)
            {
                buf[i] = line_hit_where[line_beat_at, i];
            }
            point_3(buf, 0.025f);
            if (line_beat_at < line_hit_beat.Length - 1)
                line_beat_at++;
        }
        float lights_time = lights_time_at[light_at] * beat;
        if (time >= lights_time - Time.deltaTime && time < lights_time + Time.deltaTime)
        {
            var begin_at = lights_time_at[light_at];
            Debug.Log("ininininininnininininininin light");
            if (lights_turn[light_at] == 0)
            {
                walls[1].GetComponent<changeColor>().a1(begin_at, begin_at);
            }
            else
            {
                walls[1].GetComponent<changeColor>().a1_back(begin_at, begin_at);
            }
            if (light_at < lights_begin.Length - 1)
                light_at++;

        }
        var end = 840 * beat;
        if (time >= end - Time.deltaTime && time < end + Time.deltaTime)
        {
            //轉跳
            Debug.Log("ending");
            SceneManager.LoadScene("end");

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
