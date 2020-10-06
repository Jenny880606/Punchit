using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class control : MonoBehaviour
{
    public GameObject pos;
    public int sscore;
    public GameObject head;
    public GameObject zero;
    public GameObject one;
    public GameObject two;
    public GameObject three;
    public GameObject four;
    public GameObject five;
    public GameObject six;
    public GameObject seven;
    public GameObject eight;
    public GameObject nine;
    public float posx;
    public float posz;
    private int sscorebuffer;
    private int position = 0;
    private float x = 0.7f;
    private float y = 0.0f;
    private float z = -1.8f;

    // Start is called before the first frame update
    void Start()
    {
	x = pos.transform.GetChild(0).transform.position.x + 0.3f;
	z = pos.transform.GetChild(0).transform.position.z;
	posx = x;
	y = head.transform.position.y - 0.3f;
	transform.localPosition = new Vector3(x, y, z);
        sscorebuffer = 0;
    }

    int rr(int p)
    {
	if(p == 0)
	    return 0;
	else if(p == 1)
	    return 45;
	else if(p == 2)
	    return 90;
	else if(p == 3)
	    return 135;
	else if(p == 4)
	    return 180;
	else if(p == 5)
	    return 225;
	else if(p == 6)
	    return 270;
	else if(p == 7)
	    return 315;
	return 0;
    }

    void num(int buffer,int p)
    {
        switch (buffer)
        {
            case 0:
                Instantiate(zero, new Vector3(posx,transform.position.y, posz), Quaternion.Euler(transform.rotation.x, transform.rotation.y + rr(p), transform.rotation.z), this.transform);
                break;
            case 1:
                Instantiate(one, new Vector3(posx, transform.position.y, posz), Quaternion.Euler(transform.rotation.x, transform.rotation.y + rr(p), transform.rotation.z), this.transform);
                break;
            case 2:
                Instantiate(two, new Vector3(posx, transform.position.y, posz), Quaternion.Euler(transform.rotation.x, transform.rotation.y + rr(p), transform.rotation.z), this.transform);
                break;
            case 3:
                Instantiate(three, new Vector3(posx, transform.position.y, posz), Quaternion.Euler(transform.rotation.x, transform.rotation.y + 180f + rr(p), transform.rotation.z), this.transform);
                break;
            case 4:
                Instantiate(four, new Vector3(posx, transform.position.y, posz), Quaternion.Euler(transform.rotation.x, transform.rotation.y + rr(p), transform.rotation.z), this.transform);
                break;
            case 5:
                Instantiate(five, new Vector3(posx, transform.position.y, posz), Quaternion.Euler(transform.rotation.x, transform.rotation.y + 180f + rr(p), transform.rotation.z), this.transform);
                break;
            case 6:
                Instantiate(six, new Vector3(posx, transform.position.y, posz), Quaternion.Euler(transform.rotation.x + 180f, transform.rotation.y + rr(p), transform.rotation.z), this.transform);
                break;
            case 7:
                Instantiate(seven, new Vector3(posx, transform.position.y, posz), Quaternion.Euler(transform.rotation.x, transform.rotation.y + 180f + rr(p), transform.rotation.z), this.transform);
                break;
            case 8:
                Instantiate(eight, new Vector3(posx, transform.position.y, posz), Quaternion.Euler(transform.rotation.x, transform.rotation.y + rr(p), transform.rotation.z), this.transform);
                break;
            case 9:
                Instantiate(nine, new Vector3(posx, transform.position.y, posz), Quaternion.Euler(transform.rotation.x, transform.rotation.y + 180f + rr(p), transform.rotation.z), this.transform);
                break;
        }
    }

    int ppos()
    {
	if(head.transform.localEulerAngles.y <= 22.5f && head.transform.localEulerAngles.y >= 337.5f)
	    return 0;
	else if(head.transform.localEulerAngles.y >= 22.5f && head.transform.localEulerAngles.y <= 67.5f)
	    return 1;
	else if(head.transform.localEulerAngles.y >= 67.5f && head.transform.localEulerAngles.y <= 112.5f)
	    return 2;
	else if(head.transform.localEulerAngles.y >= 112.5f && head.transform.localEulerAngles.y <= 157.5f)
	    return 3;
	else if(head.transform.localEulerAngles.y >= 157.5f && head.transform.localEulerAngles.y <= 202.5f)
	    return 4;
	else if(head.transform.localEulerAngles.y >= 202.5f && head.transform.localEulerAngles.y <= 247.5f)
	    return 5;
	else if(head.transform.localEulerAngles.y >= 247.5f && head.transform.localEulerAngles.y <= 292.5f)
	    return 6;
	else if(head.transform.localEulerAngles.y >= 292.5f && head.transform.localEulerAngles.y <= 337.5f)
	    return 7;
	return 0;
    }

    void delete()
    {
        Debug.Log("childCount" + transform.childCount);
        for (int i = transform.childCount  - 1; i >= 0; i--)
        {
            //Debug.Log("des");
            Destroy(transform.GetChild(i).gameObject);
        }
            
    }

    // Update is called once per frame
    void Update()
    {
	int p = ppos();
	//Debug.Log("rotation: " + head.transform.localEulerAngles.y);
	//Debug.Log(p);
	if(p != position)
	{
	    position = p;
	    //Debug.Log("position: " + position);
	    if (transform.childCount != 0)
                delete();
	    posx = x = pos.transform.GetChild(position).transform.position.x + 0.3f;
	    posz = z = pos.transform.GetChild(position).transform.position.z;
	    for (; sscorebuffer != 0; sscorebuffer /= 10)
	    {
		if(p == 0)
	    	    posx -= 0.3f;
		else if(p == 1)
	    	    posx -= 0.3f;
		else if(p == 2)
	    	    posz += 0.3f;
		else if(p == 3)
	    	    posx += 0.3f;
		else if(p == 4)
	    	    posx += 0.3f;
		else if(p == 5)
	    	    posx += 0.3f;
		else if(p == 6)
	    	    posz -= 0.3f;
		else if(p == 7)
	    	    posx -= 0.3f;
		num(sscorebuffer % 10, p);
	    }
            sscorebuffer = sscore;
	}    

        if(sscorebuffer != sscore)
        {
            if (transform.childCount != 0)
                delete();
            posx = x;
	    posz = z;      
            Debug.Log(sscore);
            sscorebuffer = sscore;
            for (; sscorebuffer != 0; sscorebuffer /= 10)
	    {
		if(p == 0)
	    	    posx -= 0.3f;
		else if(p == 1)
	    	    posx -= 0.3f;
		else if(p == 2)
	    	    posz += 0.3f;
		else if(p == 3)
	    	    posx += 0.3f;
		else if(p == 4)
	    	    posx += 0.3f;
		else if(p == 5)
	    	    posx += 0.3f;
		else if(p == 6)
	    	    posz -= 0.3f;
		else if(p == 7)
	    	    posx -= 0.3f;
		num(sscorebuffer % 10, p);
	    }
            sscorebuffer = sscore;
        }
        //跳轉結束頁面
        if(sscore >= 123)
        {
            PlayerPrefs.SetInt("indexM", sscore);
           // SceneManager.LoadScene("End");
        }
    }
}
