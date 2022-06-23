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


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
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
        Spawner.Instance.NewSpawnRequst();
    }
}
