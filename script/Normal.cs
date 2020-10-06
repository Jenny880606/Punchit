using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Normal : MonoBehaviour
{
    public GameObject ring;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(ring ,this.transform.position, this.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
