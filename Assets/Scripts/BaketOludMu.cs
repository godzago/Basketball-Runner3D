using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaketOludMu : MonoBehaviour
{
    public float topSayisi;
    public float Score;
    public GameObject yazý2X;
    public GameObject yazý4X;
    public GameObject yazý6X;
    public GameObject yazý8X;
    public GameObject yazý10X;

    public void Update()
    {
        if (Score == 1 )
        {
            yazý2X.SetActive(true);
        }
        if (Score == 2 )
        {
            yazý4X.SetActive(true);
            yazý2X.SetActive(false);
        }
        if (Score == 3 )
        {
            yazý6X.SetActive(true);
            yazý4X.SetActive(false);
        }
        if (Score == 4 )
        {
            yazý8X.SetActive(true);
            yazý6X.SetActive(false);

        }
        if (Score == 5)
        {
            yazý8X.SetActive(false);
            yazý10X.SetActive(true);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Score += 1;
        print(Score);
    }
  
  
}
