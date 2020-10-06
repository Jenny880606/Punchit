using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildwall : MonoBehaviour
{
    public GameObject wall;
    public GameObject walls;
    public GameObject camer;
    public bool isok = false;
    public float R;
    public float Y = 0.224f;
    int all;
    int row=5;//橫向的
     int col=24 ;//直向的

    public float add;
    float angle;
    //public float timelimt;


    // Start is called before the first frame update
    void Start()
    {
        all = row * col;
        angle = 0 ;
        float high= camer.transform.position.y;
        //walls.transform.GetChild(1).gameObject.GetComponent<MeshRenderer>().material.color = Color.black;
        for (int u = 0; u < col; u++)//x
        {
            float hudu = (angle / 180) * Mathf.PI;

            for (int j = 0; j < row; j++)//y
            {

                float x = walls.transform.position.x + Mathf.Cos(hudu) * R;
                float y = walls.transform.position.y + j * Y-3.25f+high;
                float z = walls.transform.position.z + Mathf.Sin(hudu) * R;
                float xx = walls.transform.localRotation.x;
                float yy = walls.transform.localRotation.y - angle+90;
                float zz = walls.transform.localRotation.z;


                /*float x = walls.transform.position.x + u * 0.3f -1;
                float y = walls.transform.position.y + j * 0.3f;
                float z = walls.transform.position.z +1;
                float xx = walls.transform.localRotation.x;
                float yy = walls.transform.localRotation.y;
                float zz = walls.transform.localRotation.z;*/
                
                //Debug.Log(zz);

                Instantiate(wall, new Vector3(x, y, z), Quaternion.Euler(new Vector3(xx, yy, zz)), walls.transform);
            }
            angle += add;
        }
        isok = true;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
