using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class continuous2 : MonoBehaviour
{
    public GameObject Prefabs;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {

        Debug.Log("cccccccccccccccccccc");
        if (other.tag == "left" || other.tag == "right")
        {
            Debug.Log("OnTriggerEnter1");
            if (this.transform.GetChild(0).localScale.x > 1.05f)
            {
                Debug.Log("OnTriggerEnter11111");
                Instantiate(Prefabs, this.transform.position, this.transform.rotation);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Stay");
        if (other.tag == "left" || other.tag == "right")
        {
            Debug.Log("OnTriggerStay1");
            if (this.transform.GetChild(0).localScale.x > 1.05f) 
            {
                Debug.Log("OnTriggerStay1111");
                Hp.hphp = Hp.hphp + 15;
                Instantiate(Prefabs, this.transform.position, this.transform.rotation);
            }
        }


    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Exit");
        if (other.tag == "left" || other.tag == "right")
        {
            Debug.Log("OnTriggerExit1");
            if (this.transform.GetChild(0).localScale.x > 1.05f)
            {
                Debug.Log("OnTriggerExit1111");
                //Destroy(other.gameObject);
                //Instantiate(Prefabs ,this.transform.position, this.transform.rotation);
            }
        }
    }
}
