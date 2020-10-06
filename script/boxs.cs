using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxs : MonoBehaviour
{
    public GameObject box; 
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
        if(gameObject.layer==other.gameObject.layer)
        {
            Debug.Log("entered");
            box.transform.Translate( 0, 0, 0.02f);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(gameObject.layer==other.gameObject.layer)
        {
            Debug.Log("exit");
            box.transform.Translate( 0, 0, -0.02f);
        }
    }
}
