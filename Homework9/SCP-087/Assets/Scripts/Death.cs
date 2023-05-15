using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.UIElements;

public class Death : MonoBehaviour
{
    private CharacterController controller;

    [SerializeField]
    public GameObject deathSreen;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            controller = other.gameObject.GetComponent<CharacterController>();
            controller.enabled = false;
            other.gameObject.transform.position = new Vector3(-32.16f, 3.48f, 28.9f);
            controller.enabled = true;
            //GetComponent<AudioSource>().Play();
            Instantiate(deathSreen);
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        }
    }
}
