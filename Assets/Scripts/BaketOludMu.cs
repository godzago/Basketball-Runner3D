using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaketOludMu : MonoBehaviour
{
    public float topSayisi;
    public float Score;
    public GameObject yaz�2X;
    public GameObject yaz�4X;
    public GameObject yaz�6X;
    public GameObject yaz�8X;
    public GameObject basketball;
    public GameObject basketball2;
    public GameObject basketball3;
    public GameObject basketball4;

    public void Start()
    {
        PlayerPrefs.GetFloat("TopSayisi", topSayisi);
    }
    private void OnTriggerEnter(Collider other)
    {
        Score +=1  ;
        print(Score);
    }

    public void Update()
    {

        if (Score == 1 && topSayisi <= 1)
        {
            yaz�2X.SetActive(true);
            basketball.SetActive(true);
        }

        if (Score == 2 && topSayisi <= 1)
        {
            yaz�4X.SetActive(true);
            yaz�2X.SetActive(false);           
            basketball.SetActive(false);
            basketball2.SetActive(true);
        }
        if (Score == 3 && topSayisi <= 1)
        {
            yaz�6X.SetActive(true);
            yaz�4X.SetActive(false);
            basketball.SetActive(false);
            basketball2.SetActive(false);
            basketball3.SetActive(true);
        }
        if (Score == 4 && topSayisi <= 1)
        {
            yaz�8X.SetActive(true);
            yaz�6X.SetActive(false);
            basketball.SetActive(false);
            basketball2.SetActive(false);
            basketball3.SetActive(false);
            basketball4.SetActive(true);

        }
    }
}
