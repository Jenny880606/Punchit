using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bigbig : MonoBehaviour
{
    public GameObject Prefabs;
    private bool open;

    // Start is called before the first frame update
    void Start()
    {
        open = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localScale.x <30f && transform.localScale.z<30f)
        {
            transform.localScale += new Vector3(8.5f, 0, 8.5f) * Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
	if(other.tag == "left" || other.tag == "right")
	    if(transform.localScale.x >= 30f && transform.localScale.z >= 30f)
	    {
	        //Debug.Log("ontriggerenter1");
		open = true;
	        Instantiate(Prefabs ,this.transform.position, this.transform.rotation);
	    }
        
    }

    private void OnTriggerStay(Collider other)
    {
	if(other.tag == "left" || other.tag == "right")
	    if(transform.localScale.x >= 30f && transform.localScale.z >= 30f && open)
	    {
	        //Debug.Log("ontriggerenter2");
	        Instantiate(Prefabs ,this.transform.position, this.transform.rotation);
	    }
        
    }

    private void OnTriggerExit(Collider other)
    {
	if(other.tag == "left" || other.tag == "right")
	    if(transform.localScale.x >= 30f && transform.localScale.z >= 30f)
	    {
		//Debug.Log("ontriggerenter3");
		open = false;
	        //Instantiate(Prefabs ,this.transform.position, this.transform.rotation);
	    }
        
    }
}

