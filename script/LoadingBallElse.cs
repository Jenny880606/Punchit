using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingBallElse : MonoBehaviour
{
    public Transform LoadingBar;

    [SerializeField] private float speed;
    [SerializeField] private float Width;
    [SerializeField] private float Height;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(LoadingBar.transform.localPosition.x < 265)
        {
            if (Width < 200)
            {
                Width += speed * Time.deltaTime * 200;
                Height += speed * Time.deltaTime * 200;
            }
            this.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(Width, Height);
        }   
    }
}
