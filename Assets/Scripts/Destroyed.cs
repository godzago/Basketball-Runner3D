using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyed : MonoBehaviour
{

    public float topSayisi;

    public GameObject karakter;
    public GameObject ballGameObject;
    public GameObject ballGameObject1;
    public GameObject ballGameObject2;
    public GameObject ballGameObject3;
    public GameObject ballGameObject4;

    public void Start()
    {
        topSayisi = Ball.topSayýsý;
    }

    public void Update()
    {
        if (topSayisi == 5)
        {
            ballGameObject4.SetActive(true);
        }
        if (topSayisi == 4 )
        {
            ballGameObject3.SetActive(true);
        }
        if (topSayisi == 3)
        {
            ballGameObject2.SetActive(true);
        }
        if (topSayisi == 2)
        {
            ballGameObject1.SetActive(true);
        }
        if (topSayisi == 1)
        {
            ballGameObject.SetActive(true);
        }
        if (topSayisi == 0)
        {
            karakter.SetActive(true);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Top")
        {
            topSayisi -= 1;
           // Destroy(other.gameObject);
            print(topSayisi);
        }
    }
}
