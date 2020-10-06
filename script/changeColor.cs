using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeColor : MonoBehaviour
{
    public Material[] color;
    public GameObject walls;

    int all;
    int row = 5;//橫向的
    int col = 24;//直向的
    
    bool isok = false;



    // Start is called before the first frame update
    void Start()
    {
        
        all = row * col;
        
        //a1(1, 1);
        //StartCoroutine(startTOGO());

    }

    // Update is called once per frame
    float time = 0;
    void Update()
    {
        if (!isok && walls.transform.childCount==all)
        {
            isok = true;
            for (int u = 0; u < all; u++)//x
            {
                walls.transform.GetChild(u).gameObject.SetActive(false);
            }
        }

    }

    public void a1(int start, int end)
    {
        StartCoroutine(animation_1(start, end));
    }
    public void a1_back(int start, int end)
    {
        StartCoroutine(animation_1_back(start, end));
    }
    public void a2(int center)
    {
        StartCoroutine(animation_2(center));
    }
    IEnumerator startTOGO()
    {

        yield return new WaitForSeconds(0.7f);
        StartCoroutine(animation_1(5, 5));

        yield return new WaitForSeconds(2f);
        StartCoroutine(animation_1_back(5, 5));
        //StartCoroutine(animation_2(2));
        //StartCoroutine(animation_2(7));
        yield return new WaitForSeconds(3f);
        StartCoroutine(animation_2(2));
        //StartCoroutine(animation_2(7));

        /**/

    }


    IEnumerator animation_1(int start, int end)
    {
        int[] figure = { 0, 4, 6, 8, 12 };//------
                                          //  Debug.Log(start);
        walls.transform.GetChild((figure[0] + start * row) % all).gameObject.SetActive(true);
        walls.transform.GetChild((figure[1] + start * row) % all).gameObject.SetActive(true);
        walls.transform.GetChild((figure[2] + start * row) % all).gameObject.SetActive(true);
        walls.transform.GetChild((figure[3] + start * row) % all).gameObject.SetActive(true);
        walls.transform.GetChild((figure[4] + start * row) % all).gameObject.SetActive(true);

        walls.transform.GetChild((figure[0] + start * row) % all).gameObject.GetComponent<MeshRenderer>().material = color[1];
        walls.transform.GetChild((figure[1] + start * row) % all).gameObject.GetComponent<MeshRenderer>().material = color[1];
        walls.transform.GetChild((figure[2] + start * row) % all).gameObject.GetComponent<MeshRenderer>().material = color[1];
        walls.transform.GetChild((figure[3] + start * row) % all).gameObject.GetComponent<MeshRenderer>().material = color[1];
        walls.transform.GetChild((figure[4] + start * row) % all).gameObject.GetComponent<MeshRenderer>().material = color[1];
        yield return new WaitForSeconds(0.1f);
        walls.transform.GetChild((figure[0] + (start + 1) * row) % all).gameObject.SetActive(true);
        walls.transform.GetChild((figure[1] + (start + 1) * row) % all).gameObject.SetActive(true);
        walls.transform.GetChild((figure[2] + (start + 1) * row) % all).gameObject.SetActive(true);
        walls.transform.GetChild((figure[3] + (start + 1) * row) % all).gameObject.SetActive(true);
        walls.transform.GetChild((figure[4] + (start + 1) * row) % all).gameObject.SetActive(true);

        walls.transform.GetChild((figure[0] + (start + 1) * row) % all).gameObject.GetComponent<MeshRenderer>().material = color[1];
        walls.transform.GetChild((figure[1] + (start + 1) * row) % all).gameObject.GetComponent<MeshRenderer>().material = color[1];
        walls.transform.GetChild((figure[2] + (start + 1) * row) % all).gameObject.GetComponent<MeshRenderer>().material = color[1];
        walls.transform.GetChild((figure[3] + (start + 1) * row) % all).gameObject.GetComponent<MeshRenderer>().material = color[1];
        walls.transform.GetChild((figure[4] + (start + 1) * row) % all).gameObject.GetComponent<MeshRenderer>().material = color[1];
        yield return new WaitForSeconds(0.1f);
        // Debug.Log("12354");
        for (int x = start + 2; x < ((end - start) > 0 ? (end + 1) : (end + col + 1)); x++)
        {
            Debug.Log(x);
            for (int i = 0; i < figure.Length; i++)
            {
                int at = (figure[i] + x * row) % all;
                int at2 = ((figure[i] + x * row) + row) % all;
                int pre = (figure[i] + (x - 2 + col) % col * row) % all;

                walls.transform.GetChild(at).gameObject.GetComponent<MeshRenderer>().material = color[1];
                walls.transform.GetChild(at).gameObject.SetActive(true);

                //walls.transform.GetChild(at2).gameObject.GetComponent<MeshRenderer>().material = color[1];

                walls.transform.GetChild(pre).gameObject.GetComponent<MeshRenderer>().material = color[0];
                walls.transform.GetChild(pre).gameObject.SetActive(false);

            }

            yield return new WaitForSeconds(0.1f);
        }

        walls.transform.GetChild(((figure[0] + (end - 1 + col) % col * row)) % all).gameObject.SetActive(false);
        walls.transform.GetChild(((figure[1] + (end - 1 + col) % col * row)) % all).gameObject.SetActive(false);
        walls.transform.GetChild(((figure[2] + (end - 1 + col) % col * row)) % all).gameObject.SetActive(false);
        walls.transform.GetChild(((figure[3] + (end - 1 + col) % col * row)) % all).gameObject.SetActive(false);
        walls.transform.GetChild(((figure[4] + (end - 1 + col) % col * row)) % all).gameObject.SetActive(false);

        walls.transform.GetChild(((figure[0] + (end - 1 + col) % col * row)) % all).gameObject.GetComponent<MeshRenderer>().material = color[0];
        walls.transform.GetChild(((figure[1] + (end - 1 + col) % col * row)) % all).gameObject.GetComponent<MeshRenderer>().material = color[0];
        walls.transform.GetChild(((figure[2] + (end - 1 + col) % col * row)) % all).gameObject.GetComponent<MeshRenderer>().material = color[0];
        walls.transform.GetChild(((figure[3] + (end - 1 + col) % col * row)) % all).gameObject.GetComponent<MeshRenderer>().material = color[0];
        walls.transform.GetChild(((figure[4] + (end - 1 + col) % col * row)) % all).gameObject.GetComponent<MeshRenderer>().material = color[0];
        yield return new WaitForSeconds(0.1f);
        walls.transform.GetChild((figure[0] + end * row) % all).gameObject.GetComponent<MeshRenderer>().material = color[0];
        walls.transform.GetChild((figure[1] + end * row) % all).gameObject.GetComponent<MeshRenderer>().material = color[0];
        walls.transform.GetChild((figure[2] + end * row) % all).gameObject.GetComponent<MeshRenderer>().material = color[0];
        walls.transform.GetChild((figure[3] + end * row) % all).gameObject.GetComponent<MeshRenderer>().material = color[0];
        walls.transform.GetChild((figure[4] + end * row) % all).gameObject.GetComponent<MeshRenderer>().material = color[0];
        walls.transform.GetChild((figure[0] + end * row) % all).gameObject.SetActive(false);
        walls.transform.GetChild((figure[1] + end * row) % all).gameObject.SetActive(false);
        walls.transform.GetChild((figure[2] + end * row) % all).gameObject.SetActive(false);
        walls.transform.GetChild((figure[3] + end * row) % all).gameObject.SetActive(false);
        walls.transform.GetChild((figure[4] + end * row) % all).gameObject.SetActive(false);


    }

    IEnumerator animation_1_back(int start, int end)
    {
        int[] figure = { 2, 6, 8, 10, 14 };//------
        //  Debug.Log(start);
        walls.transform.GetChild((figure[0] + start * row) % all).gameObject.SetActive(true);
        walls.transform.GetChild((figure[1] + start * row) % all).gameObject.SetActive(true);
        walls.transform.GetChild((figure[2] + start * row) % all).gameObject.SetActive(true);
        walls.transform.GetChild((figure[3] + start * row) % all).gameObject.SetActive(true);
        walls.transform.GetChild((figure[4] + start * row) % all).gameObject.SetActive(true);

        walls.transform.GetChild((figure[0] + start * row) % all).gameObject.GetComponent<MeshRenderer>().material = color[1];
        walls.transform.GetChild((figure[1] + start * row) % all).gameObject.GetComponent<MeshRenderer>().material = color[1];
        walls.transform.GetChild((figure[2] + start * row) % all).gameObject.GetComponent<MeshRenderer>().material = color[1];
        walls.transform.GetChild((figure[3] + start * row) % all).gameObject.GetComponent<MeshRenderer>().material = color[1];
        walls.transform.GetChild((figure[4] + start * row) % all).gameObject.GetComponent<MeshRenderer>().material = color[1];
        yield return new WaitForSeconds(0.1f);
        walls.transform.GetChild((figure[0] + ((start - 1) + col) % col * row) % all).gameObject.SetActive(true);
        walls.transform.GetChild((figure[1] + ((start - 1) + col) % col * row) % all).gameObject.SetActive(true);
        walls.transform.GetChild((figure[2] + ((start - 1) + col) % col * row) % all).gameObject.SetActive(true);
        walls.transform.GetChild((figure[3] + ((start - 1) + col) % col * row) % all).gameObject.SetActive(true);
        walls.transform.GetChild((figure[4] + ((start - 1) + col) % col * row) % all).gameObject.SetActive(true);

        walls.transform.GetChild((figure[0] + ((start - 1) + col) % col * row) % all).gameObject.GetComponent<MeshRenderer>().material = color[1];
        walls.transform.GetChild((figure[1] + ((start - 1) + col) % col * row) % all).gameObject.GetComponent<MeshRenderer>().material = color[1];
        walls.transform.GetChild((figure[2] + ((start - 1) + col) % col * row) % all).gameObject.GetComponent<MeshRenderer>().material = color[1];
        walls.transform.GetChild((figure[3] + ((start - 1) + col) % col * row) % all).gameObject.GetComponent<MeshRenderer>().material = color[1];
        walls.transform.GetChild((figure[4] + ((start - 1) + col) % col * row) % all).gameObject.GetComponent<MeshRenderer>().material = color[1];
        yield return new WaitForSeconds(0.1f);
        // Debug.Log("12354");
        int num;
        if (end - start == 0)
            num = col + 1;
        else if (end - start < 0)
            num = start - end + 1;
        else
            num = -(end - start - col) + 1;

        for (int x = 2; x < num; x++)
        {
            //Debug.Log(x);
            for (int i = 0; i < figure.Length; i++)
            {
                int at = (figure[i] + (start - x + col) % col * row) % all;
                int pre = (figure[i] + (start - x + col + 2) % col * row) % all;
                //int pre = (figure[i] + (x + 8) % 10 * row) % all;

                walls.transform.GetChild(at).gameObject.GetComponent<MeshRenderer>().material = color[1];
                walls.transform.GetChild(at).gameObject.SetActive(true);
                walls.transform.GetChild(pre).gameObject.GetComponent<MeshRenderer>().material = color[0];
                walls.transform.GetChild(pre).gameObject.SetActive(false);

            }

            yield return new WaitForSeconds(0.1f);
        }

        walls.transform.GetChild((figure[0] + (end + 1) % col * row) % all).gameObject.SetActive(false);
        walls.transform.GetChild((figure[1] + (end + 1) % col * row) % all).gameObject.SetActive(false);
        walls.transform.GetChild((figure[2] + (end + 1) % col * row) % all).gameObject.SetActive(false);
        walls.transform.GetChild((figure[3] + (end + 1) % col * row) % all).gameObject.SetActive(false);
        walls.transform.GetChild((figure[4] + (end + 1) % col * row) % all).gameObject.SetActive(false);

        walls.transform.GetChild((figure[0] + (end + 1) % col * row) % all).gameObject.GetComponent<MeshRenderer>().material = color[0];
        walls.transform.GetChild((figure[1] + (end + 1) % col * row) % all).gameObject.GetComponent<MeshRenderer>().material = color[0];
        walls.transform.GetChild((figure[2] + (end + 1) % col * row) % all).gameObject.GetComponent<MeshRenderer>().material = color[0];
        walls.transform.GetChild((figure[3] + (end + 1) % col * row) % all).gameObject.GetComponent<MeshRenderer>().material = color[0];
        walls.transform.GetChild((figure[4] + (end + 1) % col * row) % all).gameObject.GetComponent<MeshRenderer>().material = color[0];
        yield return new WaitForSeconds(0.1f);
        walls.transform.GetChild((figure[0] + end * row) % all).gameObject.SetActive(false);
        walls.transform.GetChild((figure[1] + end * row) % all).gameObject.SetActive(false);
        walls.transform.GetChild((figure[2] + end * row) % all).gameObject.SetActive(false);
        walls.transform.GetChild((figure[3] + end * row) % all).gameObject.SetActive(false);
        walls.transform.GetChild((figure[4] + end * row) % all).gameObject.SetActive(false);

        walls.transform.GetChild((figure[0] + end * row) % all).gameObject.GetComponent<MeshRenderer>().material = color[0];
        walls.transform.GetChild((figure[1] + end * row) % all).gameObject.GetComponent<MeshRenderer>().material = color[0];
        walls.transform.GetChild((figure[2] + end * row) % all).gameObject.GetComponent<MeshRenderer>().material = color[0];
        walls.transform.GetChild((figure[3] + end * row) % all).gameObject.GetComponent<MeshRenderer>().material = color[0];
        walls.transform.GetChild((figure[4] + end * row) % all).gameObject.GetComponent<MeshRenderer>().material = color[0];

    }

    IEnumerator animation_2(int center)
    {
        int[] figure = { 0, 6, 12, 16, 20 };//------

        walls.transform.GetChild(((figure[2] - 2) + ((center + 8) % 10) * row) % all).gameObject.GetComponent<MeshRenderer>().material = color[1];
        walls.transform.GetChild(((figure[2] - 2) + ((center + 8) % 10) * row) % all).gameObject.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        walls.transform.GetChild(((figure[1] - 1) + ((center + 8) % 10) * row) % all).gameObject.SetActive(true);
        walls.transform.GetChild(((figure[2] - 1) + ((center + 8) % 10) * row) % all).gameObject.SetActive(true);
        walls.transform.GetChild(((figure[3] - 1) + ((center + 8) % 10) * row) % all).gameObject.SetActive(true);

        walls.transform.GetChild(((figure[1] - 1) + ((center + 8) % 10) * row) % all).gameObject.GetComponent<MeshRenderer>().material = color[1];
        walls.transform.GetChild(((figure[2] - 1) + ((center + 8) % 10) * row) % all).gameObject.GetComponent<MeshRenderer>().material = color[1];
        walls.transform.GetChild(((figure[3] - 1) + ((center + 8) % 10) * row) % all).gameObject.GetComponent<MeshRenderer>().material = color[1];
        yield return new WaitForSeconds(0.1f);
        for (int i = 0; i < row + 2; i++)
        {
            for (int x = 0; x < figure.Length; x++)
            {
                int now = (figure[x] % 5 + i) / 5 > 0 ? -1 : (figure[x] + i);
                int pre = (figure[x] % row + i - 2) < 0 ? -1 : figure[x] + i - 2;
                if (now != -1)
                {
                    int at = (now + ((center + 8) % 10) * row) % all;
                    walls.transform.GetChild(at).gameObject.GetComponent<MeshRenderer>().material = color[1];
                    walls.transform.GetChild(at).gameObject.SetActive(true);
                }
                if (pre != -1)
                {

                    int at = (pre + ((center + 8) % 10) * row) % all;
                    //Debug.Log(i + " : " + at);
                    walls.transform.GetChild(at).gameObject.GetComponent<MeshRenderer>().material = color[0];
                    walls.transform.GetChild(at).gameObject.SetActive(false);
                }
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
}
