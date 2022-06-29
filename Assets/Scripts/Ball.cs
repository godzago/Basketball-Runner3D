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

    [SerializeField]
    public static int topSay�s� = 5;

    //--------------------------------�f b�l�m�-------------------------//

    public GameObject ballGameObject;
    public GameObject ballGameObject1;
    public GameObject ballGameObject2;
    public GameObject ballGameObject3;
    public GameObject ballGameObject4;
    public GameObject button;

    //--------------------------------�f b�l�m�-------------------------//

    public void Start()
    {
        rb = GetComponent<Rigidbody>();
        button.SetActive(false);
    }
  
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
    }
}
