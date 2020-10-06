using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    public GameObject L0;
    public GameObject[] newIndexs;

    public GameObject Panel;

    public Text indexText;

    int indexM;//用来把取的数赋值于此

    int[] save = new int[8];
    int Num;
    string saveIntStr;

    // Use this for initialization                                                                                      
    void Start()
    {
        // //刪除存儲排行榜中的數據
        // for (int i = 0; i < 8; i++)
        // {
        //    string saveIntStrS = saveIntStr + i.ToString();
        //    PlayerPrefs.DeleteKey(saveIntStrS);
        // }



        //獲取此玩家的得分紀錄
        indexM = PlayerPrefs.GetInt("indexM");
        indexText.text = "此次得分：" + indexM.ToString();

        //get存儲排行榜中的數據
        for (int i = 0; i < 8; i++)
        {
            string saveIntStrS = saveIntStr + i.ToString();
            save[i] = PlayerPrefs.GetInt(saveIntStrS);
        }

        int Markred = -1;//*

        //添加新數據並排序（大到小） //插入排序
        for (int i = 0; i < 8; i++)
        {
            if (save == null || save[i] == 0)
            {
                save[i] = indexM;
                Num = i;

                Markred = i;//*

                for (int m = 0; m < Num + 1; ++m)
                {
                    int t = save[m];
                    int n = m;
                    while ((n > 0) && (save[n - 1] < t))
                    {
                        save[n] = save[n - 1];
                        --n;
                    }
                    save[n] = t;
                }

                break;
            }
            else
            {
                int n = 7;
                if (indexM >= save[7])
                {
                    while (save[n - 1] <= indexM)
                    {
                        save[n] = save[n - 1];
                        --n;
                        save[n] = indexM;
                        Markred = n;//*

                        if (n == 0)
                        {
                            Markred = 0;//*
                            break;
                        }
                    }
                    //Markred = n;//*
                    break;
                }
            }
        }

        //儲存當前數據
        for (int j = 0; j < 8; j++)
        {
            string saveIntStrI = saveIntStr + j.ToString();
            PlayerPrefs.SetInt(saveIntStrI, save[j]);
            //PlayerPrefs.SetInt(saveIntStrI, 0);
        }

        //將數據顯示到場景UI
        for (int i = 0; i < newIndexs.Length; i++)
        {
            string saveIntStrO = saveIntStr + i.ToString();
            newIndexs[i] = Instantiate(L0, L0.transform.position, L0.transform.rotation) as GameObject;
            newIndexs[i].transform.SetParent(Panel.transform);
            newIndexs[i].transform.localScale = new Vector3(0.008f, 0.008f, 0.008f);
            newIndexs[i].transform.position = new Vector3(0.82f,-0.2f,0.15f);
            newIndexs[i].GetComponent<Text>().text = PlayerPrefs.GetInt(saveIntStrO).ToString();//"ya"
            if(i == Markred)
            {
                newIndexs[i].GetComponent<Text>().color = Color.yellow;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ReStart()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
