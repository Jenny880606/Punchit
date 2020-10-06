using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinuousLine : MonoBehaviour
{
    public Transform LoadingBall;
    [SerializeField] private float speed;
    [SerializeField] private float posx;
    // Start is called before the first frame update
    void Start()
    {
        posx = 500;
    }

    // Update is called once per frame
    void Update()
    {
        if (LoadingBall.gameObject.GetComponent<RectTransform>().rect.width > 162)
        {
            if (posx > 0)
                posx -= speed * Time.deltaTime * 200;
            //Debug.Log(posx);
            this.transform.localPosition = new Vector3(posx, 0.0f, 0.0f);
        }     
    }
}
