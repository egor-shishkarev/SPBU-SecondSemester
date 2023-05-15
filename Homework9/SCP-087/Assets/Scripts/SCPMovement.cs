using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SCPMovement : MonoBehaviour
{
    [SerializeField]
    public Transform playerPosition;

    public float speed;

    public float visibilityDistance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, playerPosition.position);

        if (distanceToPlayer < visibilityDistance)
        {
            GetComponent<AudioSource>().Play();
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -speed);
        }
    }
}