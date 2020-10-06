using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hand : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject Prefabs;
    private bool open;
    public int sss = 0;
    void Start()
    {
        open = false;
        sss = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("sss:" + sss);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Enter");
        if (other.tag == "continuous" || other.tag == "line")
        {
            Debug.Log("OnTriggerEnter1");
            if (transform.localScale.x >= 0.12f && transform.localScale.z >= 0.12f)
            {
                Debug.Log("OnTriggerEnter11111");
                open = true;
                Instantiate(Prefabs,this.transform.position, this.transform.rotation);
            }
        }
            
        if(other.tag == "normal")
        {
            Debug.Log("OnTriggerEnter2");
            if (transform.localScale.x >= 0.12f && transform.localScale.z >= 0.12f)
            {
                Debug.Log("OnTriggerEnter2222");
                Instantiate(Prefabs, this.transform.position, this.transform.rotation);
                Hp.hphp = Hp.hphp + 100;
                sss += 100;
                //Destroy(other.gameObject);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Stay");
        if (other.tag == "continuous" || other.tag == "line")
        {
            Debug.Log("OnTriggerStay1");
            if (transform.localScale.x >= 0.12f && transform.localScale.z >= 0.12f && open)
            {
                Debug.Log("OnTriggerStay1111");
                Hp.hphp = Hp.hphp + 15;
                sss += 15;
                Instantiate(Prefabs, this.transform.position, this.transform.rotation);
            }
        }
            

    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Exit");
        if (other.tag == "continuous" || other.tag == "line")
        {
            Debug.Log("OnTriggerExit1");
            if (transform.localScale.x >= 0.12f && transform.localScale.z >= 0.12f)
            {
                Debug.Log("OnTriggerExit1111");
                open = false;
                //Destroy(other.gameObject);
                //Instantiate(Prefabs ,this.transform.position, this.transform.rotation);
            }
        }
    }
}
