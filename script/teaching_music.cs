using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teaching_music : MonoBehaviour
{
    // Start is called before the first frame update
    bool go=true;
    void Start()
    {
       

    }
    float time=0;
    // Update is called once per frame
    void Update()
    {
         if(go)
            time += Time.deltaTime;

        if (time>5f)
        {
            GetComponent<AudioSource>().Play();
	        //GetComponent<AudioSource>().loop=true;
            time = 0;
            go = false;
        }
    }
}
