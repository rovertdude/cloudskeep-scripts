using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastStandingManager : MonoBehaviour
{
    public GameObject player;
    public GameObject lastPosition;
    //public Vector3 temp;
    //public static GameObject temp2;

    void Start()
    {
        //temp2 = GameObject.Find("platform temp");
        player = GameObject.Find("RigidBodyFPSController");
        lastPosition = GameObject.Find("ContactPoint");
    }

    void OnCollisionEnter(Collision collision)
    {
        ContactPoint contact = collision.GetContact(0);
        lastPosition.transform.position = contact.point + new Vector3(0.0f, 2.0f, 0.0f);
        //temp = contact.point;
        //temp.y = 3;
        //lastPosition.transform.position = temp;
    }
}
