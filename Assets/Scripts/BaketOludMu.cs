using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaketOludMu : MonoBehaviour
{
    public float topSayisi;
    public static int FinishScore = 1000;
    public static int Score;
    public GameObject yaz�2X;
    public GameObject yaz�4X;
    public GameObject yaz�6X;
    public GameObject yaz�8X;
    public GameObject yaz�10X;

    public void Update()
    {
        if (Score == 1 )
        {
            yaz�2X.SetActive(true);
        }
        if (Score == 2 )
        {
            yaz�4X.SetActive(true);
            yaz�2X.SetActive(false);
        }
        if (Score == 3 )
        {
            yaz�6X.SetActive(true);
            yaz�4X.SetActive(false);
        }
        if (Score == 4 )
        {
            yaz�8X.SetActive(true);
            yaz�6X.SetActive(false);
        }
        if (Score == 5)
        {
            yaz�8X.SetActive(false);
            yaz�10X.SetActive(true);
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Score += 1;
        //  print(Score);
        if (Score == 1)
        {
            FinishScore *= 2;
        }
        else if (Score == 2)
        {
            FinishScore  = 4 * (FinishScore / 2);
        }
        else if (Score == 3)
        {
            FinishScore = 6 * (FinishScore / 4);
        }
        else if (Score == 4)
        {
            FinishScore = 8 * (FinishScore / 6);
        }
        else if (Score == 5)
        {
            FinishScore = 10 * (FinishScore / 8);
        }
    }
}
