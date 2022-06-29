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

    private bool �sShoot;

    //--------------------------------�f b�l�m�-------------------------//

    public float topSay�s�;
    public GameObject ballGameObject;
    public GameObject ballGameObject1;
    public GameObject ballGameObject2;
    public GameObject ballGameObject3;
    public GameObject ballGameObject4;
    public GameObject button;

    //--------------------------------�f b�l�m�-------------------------//

    public void Awake()
    {
        rb = GetComponent<Rigidbody>();
        PlayerPrefs.SetFloat("TopSayisi", topSay�s�);
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
       
         if(topSay�s� == 1)
        {          
            ballGameObject.SetActive(true);
            ballGameObject4.SetActive(false);
            ballGameObject1.SetActive(false);
            ballGameObject2.SetActive(false);
            ballGameObject3.SetActive(false);
            button.SetActive(false);

        }
         if (topSay�s� == 2)
        {
            ballGameObject1.SetActive(true);
            ballGameObject2.SetActive(false);
            ballGameObject4.SetActive(false);
            ballGameObject.SetActive(false);                
            ballGameObject3.SetActive(false);
            button.SetActive(false);
        }
         if (topSay�s� == 3)
        {
            ballGameObject2.SetActive(true);
            ballGameObject4.SetActive(false);
            ballGameObject.SetActive(false);
            ballGameObject1.SetActive(false);         
            ballGameObject3.SetActive(false);
            button.SetActive(false);
        }
         if (topSay�s� == 4)
        {
            ballGameObject3.SetActive(true);
            ballGameObject4.SetActive(false);
            ballGameObject.SetActive(false);
            ballGameObject1.SetActive(false);
            ballGameObject2.SetActive(false);
            button.SetActive(false);
        }
         if (topSay�s� == 5)
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

        if (!�sShoot)
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
        if (�sShoot)
        {
            return;
        }

        rb.AddForce(new Vector3(Force.x, Force.y, Force.z) * forceMultipler);
        �sShoot = true;
       // Spawner.Instance.NewSpawnRequst();
    }
}
