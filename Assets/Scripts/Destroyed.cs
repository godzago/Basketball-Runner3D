using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Destroyed : MonoBehaviour
{

    public float topSayisi;

    public GameObject karakter;
    public GameObject ballGameObject;
    public GameObject ballGameObject1;
    public GameObject ballGameObject2;
    public GameObject ballGameObject3;
    public GameObject ballGameObject4;

    public GameObject FiniisScoreGameObject;
    public Text FinisScoreText;

    public ParticleSystem particle;

    public GameObject x;
    public GameObject NextButton;
    public void Start()
    {
        topSayisi = Ball.topSayýsý;
        particle.Stop();
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
            FinisScoreText.text = BaketOludMu.FinishScore.ToString();
            FiniisScoreGameObject.SetActive(true);
            particle.Play();
            x.SetActive(false);
            NextButton.SetActive(true);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Top")
        {
            topSayisi -= 1;
            // Destroy(other.gameObject);
            //  print(topSayisi);         
        }
    }
}
