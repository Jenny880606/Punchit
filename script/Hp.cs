using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hp : MonoBehaviour
{
    public static int hphp = 0;
    // Start is called before the first frame update
    void Start()
    {
        //DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        //hphp++;
        if (hphp >= 10)
        {     
            PlayerPrefs.SetInt("indexM", hphp);
            //SceneManager.LoadScene("End");
        }
    }
}