using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPlaneScript : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(gameObject.name + " collided with " + collision.gameObject.name + " - " + collision.gameObject.tag);

        //Destroy(gameObject);

        if (collision.gameObject.CompareTag("Respawn"))
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered " + other.gameObject.name + " - " + other.gameObject.tag);

        if (other.gameObject.CompareTag("Respawn"))
        {
            Destroy(gameObject);
        }

    }




}
