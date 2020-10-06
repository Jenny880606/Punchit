using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayLight : MonoBehaviour
{

    public GameObject Prefabs;


    // Start is called before the first frame update
    void Start()
    {
        Instantiate(Prefabs ,this.transform.position, this.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
