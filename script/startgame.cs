using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class startgame : MonoBehaviour
{
    public string gotowhere;

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
        Hp.hphp = 0;
	    //PlayerPrefs.SetInt("showhp", 0);
        Debug.Log(gotowhere);
        SceneManager.LoadScene(gotowhere);
        // GetComponent<MeshRenderer>().material.color = Color.red;
    }
}
