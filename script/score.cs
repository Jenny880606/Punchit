using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{
    //public GameObject hp;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Text>().text = "SCORE 0";
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Hp.hphp);
        GetComponent<Text>().text = "SCORE " + Hp.hphp.ToString();
    }
}
