using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggertest : MonoBehaviour
{
    public GameObject player;
    public GameObject thing2;
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        print("whoa i've collided with " + other.name);
        print("that's pretty cool man");
        player.transform.position = thing2.transform.position;
    }
}
