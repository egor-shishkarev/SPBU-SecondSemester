using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.UIElements;

public class Death : MonoBehaviour
{
    private CharacterController controller;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            controller = other.gameObject.GetComponent<CharacterController>();
            controller.enabled = false;
            other.gameObject.transform.position = new Vector3(100, 100, 100);
            controller.enabled = true;
        }
    }
}
