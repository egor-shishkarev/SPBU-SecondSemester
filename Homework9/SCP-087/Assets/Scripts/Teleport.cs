using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Windows;

public class Teleport : MonoBehaviour
{
    public float yScale;

    [SerializeField]
    private GameObject door;

    [SerializeField]
    public float appearanceProbability = 0f;

    private CharacterController controller;

    [SerializeField]
    public GameObject SCP;

    public void OnTriggerEnter(Collider other)
    {
        controller = other.gameObject.GetComponent<CharacterController>();
        controller.enabled = false;
        Vector3 teleportMove = other.gameObject.transform.position;
        teleportMove.y += yScale;
        other.gameObject.transform.position = teleportMove;
        controller.enabled = true;
        if (door.GetComponent<Animator>().GetBool("IsTeleported") != true)
        {
            door.GetComponent<AudioSource>().Play();
            door.GetComponent<Animator>().SetBool("IsTeleported", true);
        }
        if (Random.Range(0.0f, 1.0f) <= appearanceProbability/100)
        {
            Vector3 place = new(97.23f, -31f, 24.03f);
            SCP.transform.position = place;
            
        }
    }
}
