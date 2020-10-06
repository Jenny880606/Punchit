using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class line_2 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject RunningPrefab;
    public GameObject Prefabs;
    public GameObject[] thing;
    public GameObject thing2;
    public GameObject L;
    public GameObject LBUF;
    public int hhhh;//方塊數量
    public float timelimt;
    //public GameObject R;
    //public GameObject thing;
    int num = 0;
    float lineline = 0;
    int at = 0;

    // Start is called before the first frame update
    void Start()
    {
        int buf = 0;
        while (buf < thing.Length - 1)
        {
            for (int i = 0; i < hhhh; i++)
            {
                float x = thing[buf].transform.position.x + (thing[buf + 1].transform.position.x - thing[buf].transform.position.x) / hhhh * i;
                float y = thing[buf].transform.position.y + (thing[buf + 1].transform.position.y - thing[buf].transform.position.y) / hhhh * i;
                float z = thing[buf].transform.position.z + (thing[buf + 1].transform.position.z - thing[buf].transform.position.z) / hhhh * i;
                float xx = thing[buf].transform.localRotation.x;
                float yy = thing[buf].transform.localRotation.y;
                float zz = thing[buf].transform.localRotation.z;
                Instantiate(LBUF, new Vector3(x, y, z), Quaternion.Euler(new Vector3(xx, yy, zz)), thing[at].transform);
            }
            buf++;
        }

    }

    float time = 0;
    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (thing2.transform.localScale.x < 30f && thing2.transform.localScale.z < 30f)
        {
            thing2.transform.localScale += new Vector3(10f, 0, 10f) * Time.deltaTime;
        }
        else if(num<hhhh)
        {
            if (time > timelimt)
            {
                time = 0;
                float x = thing[at].transform.position.x + (thing[at + 1].transform.position.x - thing[at].transform.position.x) / hhhh * num;
                float y = thing[at].transform.position.y + (thing[at + 1].transform.position.y - thing[at].transform.position.y) / hhhh * num;
                float z = thing[at].transform.position.z + (thing[at + 1].transform.position.z - thing[at].transform.position.z) / hhhh * num;
                float xx = thing[at].transform.localRotation.x;
                float yy = thing[at].transform.localRotation.y;
                float zz = thing[at].transform.localRotation.z;
                //Debug.Log(zz);
                num++;
                Instantiate(L, new Vector3(x, y, z), Quaternion.Euler(new Vector3(xx, yy, zz)), thing[0].transform);
		Instantiate(RunningPrefab ,thing2.transform.position, thing2.transform.rotation);
                thing2.transform.position = new Vector3(x, y, z);

            }
        }
        else if (at < thing.Length - 1)
        {
            Debug.Log("lLLLl:  " + thing.Length);
            //Debug.Log("lLLLl:  "+ at);
            if (at < thing.Length - 2)
            {
                num = 0;
                Debug.Log("lLLLl:  " + at);
            }
            at++;
        }
        else
	{
	    Instantiate(Prefabs ,thing2.transform.position, thing2.transform.rotation);
            Destroy(gameObject);
	}

    }
}
