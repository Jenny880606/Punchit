using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particle : MonoBehaviour
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

    private void OnTriggerEnter()
    {
        //Debug.Log("ontriggerenter");
	Instantiate(Prefabs ,this.transform.position, this.transform.rotation);
	//Destroy(this);
    }
}