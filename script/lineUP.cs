using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class lineUP : MonoBehaviour
{
    public GameObject [] POINT;
    public GameObject I;
    public GameObject walls;
    public GameObject LBUF;
    public float timelimit = 0.03f;


    int at;
    int at2=0;
    int allcube = 0;

    public int[] atwhere= { 4,6,13,16,18};
    // Start is called before the first frame update
    int have = 0;
    int hhhh = 20;

    public void setPOINT(int[] at,float t,GameObject w)
    {
        atwhere = at;
        timelimit = t;
        walls = w;
    }

    void Start()
    {
        at = atwhere.Length;
        allcube = (atwhere.Length - 1) * hhhh + atwhere.Length;
        int nowhave = have;
        Vector3 pp;
        Quaternion qq;
       for (int i = 0; i < atwhere.Length; i++)
        {
            pp = walls.transform.GetChild(atwhere[i]).transform.position;
            //qq = walls.transform.GetChild(atwhere[i]).transform.rotation;
            qq = Quaternion.Euler(new Vector3(0, 0, 0));

            if (i == 0)
                Instantiate(POINT[0], pp, qq, I.transform).GetComponent<grow2>().wall = walls.transform.GetChild(atwhere[i]).gameObject;
            else
                Instantiate(POINT[1], pp, qq, I.transform);

            have++;
        }
        for (int i = 0; i < atwhere.Length-1; i++)
        {
            for (int d = 0; d < hhhh; d++)
            {
                float x = walls.transform.GetChild(atwhere[i]).transform.position.x + (walls.transform.GetChild(atwhere[i+1]).transform.position.x - walls.transform.GetChild(atwhere[i]).transform.position.x) / hhhh * d;
                float y = walls.transform.GetChild(atwhere[i]).transform.position.y + (walls.transform.GetChild(atwhere[i + 1]).transform.position.y - walls.transform.GetChild(atwhere[i]).transform.position.y) / hhhh * d;
                float z = walls.transform.GetChild(atwhere[i]).transform.position.z + (walls.transform.GetChild(atwhere[i + 1]).transform.position.z - walls.transform.GetChild(atwhere[i]).transform.position.z) / hhhh * d;
                Instantiate(LBUF, new Vector3(x, y, z), Quaternion.Euler(new Vector3(0, 0, 0)), I.transform);
            }
        }
    }

    // Update is called once per frame
    float time = 0;
   
    void Update()
    {

       if(I.transform.GetChild(0).transform.GetChild(0).transform.localScale.x>1f)
        {
            time += Time.deltaTime;
            
            if (time>timelimit && allcube>at)
            {
                //Debug.Log(allcube);
                Debug.Log(at2);
                if (allcube == 64)
                {
                    at2++;
                }
                if (allcube == 46)
                {
                    at2++;
                }
                if (allcube == 26)
                {
                    at2++;
                }
                if (allcube == 6)
                {
                    at2++;
                }
                
                time = 0;
                I.transform.GetChild(0).position = I.transform.GetChild(at).position;
                if (at2 < atwhere.Length)
                    I.transform.GetChild(0).GetComponent<grow2>().wall = walls.transform.GetChild(atwhere[at2]).gameObject;

                Destroy(I.transform.GetChild(at).gameObject);
                allcube--;
            }
            else if (time > timelimit+0.1f && !(allcube > at))
            {
                Destroy(gameObject);
            }


        }
       
    }
}
