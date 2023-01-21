using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public GameObject player;
    public float SidewaysSpeed;
    public float ForwadSpeed;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("d"))
        {
            player.GetComponent<Rigidbody>().AddForce(Vector3.right * SidewaysSpeed);
        }
        if (Input.GetKey("a"))
        {
            player.GetComponent<Rigidbody>().AddForce(Vector3.left * SidewaysSpeed);
        }
    }
}
