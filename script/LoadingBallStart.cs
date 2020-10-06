using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingBallStart : MonoBehaviour
{
    public Transform LoadingBar;
    public Transform LoadingBall;

    [SerializeField] private float speed;
    [SerializeField] private float Width;
    [SerializeField] private float Height;
    // Start is called before the first frame update
    void Start()
    {
        LoadingBar.transform.localPosition = new Vector3(500.0f, 0.0f, 0.0f);
        LoadingBall.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Width < 200)
        {
            Width += speed * Time.deltaTime * 200;
            Height += speed * Time.deltaTime * 200;
        }
        this.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(Width, Height);
    }
}
