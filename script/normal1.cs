using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class normal1 : MonoBehaviour
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
        Debug.Log("Enter");

        if (other.tag == "left" || other.tag == "right")
        {
            Debug.Log("OnTriggerEnter2");
            if(this.transform.GetChild(0).localScale.x>1.05f)
            {
                float nnn = this.transform.GetChild(0).localScale.x;
                Debug.Log("OnTriggerEnter2222");
                Instantiate(Prefabs, this.transform.position, this.transform.rotation);
                Hp.hphp = Hp.hphp + aaa(this.transform.GetChild(0).localScale.x);
                Destroy(gameObject);
            }

        }
    }


    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Stay");
        if (other.tag == "left" || other.tag == "right")
        {
            Debug.Log("OnTriggerEnter2");
            if(this.transform.GetChild(0).localScale.x>1.05f)
            {
                Debug.Log("OnTriggerEnter2222");
                Instantiate(Prefabs, this.transform.position, this.transform.rotation);
                Hp.hphp = Hp.hphp + aaa(this.transform.GetChild(0).localScale.x);
                //Hp.hphp = Hp.hphp + 100;
                Destroy(gameObject);
            }
        }


    }


    int aaa(float num)
    {
        if (num < 1.12f)
        {
            return 100;

        }
        else if(num < 1.152f)
        {
            return 125;

        }
        else
        {
            return 150;

        }
    }
}
