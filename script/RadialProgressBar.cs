using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RadialProgressBar : MonoBehaviour
{
    public Transform LoadingBar;
    [SerializeField] private float currentAmount;
    [SerializeField] private float speed;

    private void Start()
    {
	
	this.transform.SetParent(GameObject.Find("Canvas/Panel").GetComponent<Transform>(), false);
        LoadingBar.GetComponent<Image>().fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentAmount < 100)
            currentAmount += speed * Time.deltaTime;
        LoadingBar.GetComponent<Image>().fillAmount = currentAmount / 100;
    }
}
