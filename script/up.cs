using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class up : MonoBehaviour
{
    public GameObject at;
    public GameObject thing;
    public Material[] color;
    public GameObject wall;

    //public GameObject R;
    //public GameObject thing;
    public float timelimt;
    float angle = 3;
    float add;
    float caseto;
    int num = 0;

    // Start is called before the first frame update
    public void setPOINT(GameObject w,float t)
    {
        wall = w;
        timelimt = t;
        

    }
    void Start()
    {
        at.transform.GetChild(0).gameObject.transform.localScale = new Vector3(0, 0.004f, 0);
        add = angle;
        caseto = 360 / angle;

        add = angle;
        caseto = 360 / angle;

        for (int i = 0; i < caseto; i++)
        {
            float hudu = (angle / 180) * Mathf.PI;

            float x = at.transform.position.x + Mathf.Cos(hudu) * 0.09f;
            float y = at.transform.position.y + Mathf.Sin(hudu) * 0.09f;
            float z = at.transform.position.z;
            float xx = at.transform.localRotation.x;
            float yy = at.transform.localRotation.y;
            float zz = at.transform.localRotation.z + angle;
            //Debug.Log(zz);
            angle += add;
            Instantiate(thing, new Vector3(x, y, z), Quaternion.Euler(new Vector3(xx, yy, zz)), at.transform);
        }
        at.transform.rotation = wall.transform.rotation;

    }


    float time = 0;
    float time2 = 0;
    bool delete = false;

    // Update is called once per frame
    void Update()
    {
        at.transform.rotation = wall.transform.rotation;


        time += Time.deltaTime;
        if (at.transform.GetChild(0).gameObject.transform.localScale.x > 1.05f)
        {
            at.transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().material = color[0];

        }

        if (at.transform.GetChild(0).gameObject.transform.localScale.x < 1.2f)
        {
            at.transform.GetChild(0).gameObject.transform.localScale += new Vector3(0.4f, 0, 0.4f) * Time.deltaTime*2;
        }
        else
        {
            if (caseto > 0)
            {
                if (time > timelimt)
                {

                    time = 0;
                    Destroy(at.transform.GetChild((int)caseto).gameObject);
                    caseto--;
                }

            }
            else
            {
                time2 += Time.deltaTime;
                if (time2 > 0.5f - Time.deltaTime && time2 <= 0.5f + Time.deltaTime && !delete)
                {
                    Destroy(gameObject);
                    delete = true;
                }
            }
        }

      
    }
}
