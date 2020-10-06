using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delete1 : MonoBehaviour
{
    private float t;
    // Start is called before the first frame update
    void Start()
    {
        t = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
	t += Time.deltaTime;
        if(t > 1)
	    Destroy(gameObject);
    }
}
