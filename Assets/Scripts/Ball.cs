using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class Ball : MonoBehaviour
{
    private Vector3 mousePressDownPos;
    private Vector3 mouseRelesePos;

    private Rigidbody rb;

    private bool ÝsShoot;

    //--------------------------------Ýf bölümü-------------------------//

    public float topSayýsý;
    public GameObject ballGameObject;
    public GameObject ballGameObject1;
    public GameObject ballGameObject2;
    public GameObject ballGameObject3;
    public GameObject ballGameObject4;
    public GameObject button;

    //--------------------------------Ýf bölümü-------------------------//

    public void Awake()
    {
        rb = GetComponent<Rigidbody>();
        PlayerPrefs.SetFloat("TopSayisi", topSayýsý);
    }
    /*
    void Start()
    {
        ballGameObject1.SetActive(false);
        ballGameObject2.SetActive(false);
        ballGameObject3.SetActive(false);
        ballGameObject4.SetActive(false);
        button.SetActive(false);
    }

    private void Update()
    {
       
         if(topSayýsý == 1)
        {          
            ballGameObject.SetActive(true);
            ballGameObject4.SetActive(false);
            ballGameObject1.SetActive(false);
            ballGameObject2.SetActive(false);
            ballGameObject3.SetActive(false);
            button.SetActive(false);

        }
         if (topSayýsý == 2)
        {
            ballGameObject1.SetActive(true);
            ballGameObject2.SetActive(false);
            ballGameObject4.SetActive(false);
            ballGameObject.SetActive(false);                
            ballGameObject3.SetActive(false);
            button.SetActive(false);
        }
         if (topSayýsý == 3)
        {
            ballGameObject2.SetActive(true);
            ballGameObject4.SetActive(false);
            ballGameObject.SetActive(false);
            ballGameObject1.SetActive(false);         
            ballGameObject3.SetActive(false);
            button.SetActive(false);
        }
         if (topSayýsý == 4)
        {
            ballGameObject3.SetActive(true);
            ballGameObject4.SetActive(false);
            ballGameObject.SetActive(false);
            ballGameObject1.SetActive(false);
            ballGameObject2.SetActive(false);
            button.SetActive(false);
        }
         if (topSayýsý == 5)
        {
            ballGameObject4.SetActive(true);
            ballGameObject.SetActive(false);
            ballGameObject1.SetActive(false);
            ballGameObject2.SetActive(false);
            ballGameObject3.SetActive(false);
            button.SetActive(false);
        }
    }
    */

    private void OnMouseDown()
    {
        mousePressDownPos = Input.mousePosition;
    }

    private void OnMouseDrag()
    {
        Vector3 forceInt = (Input.mousePosition - mousePressDownPos);
        Vector3 forceV = (new Vector3(forceInt.x, forceInt.y, forceInt.z) * forceMultipler);

        if (!ÝsShoot)
            DrawManager.Instance.UpdateTrajectory(forceV, rb, transform.position);
    }

    private void OnMouseUp()
    {
        DrawManager.Instance.HideLine();
        mouseRelesePos = Input.mousePosition;
        Shoot(mousePressDownPos - mouseRelesePos);
    }

    [SerializeField] private float forceMultipler = 3;

    void Shoot(Vector3 Force)
    {
        if (ÝsShoot)
        {
            return;
        }

        rb.AddForce(new Vector3(Force.x, Force.y, Force.z) * forceMultipler);
        ÝsShoot = true;
       // Spawner.Instance.NewSpawnRequst();
    }
}
