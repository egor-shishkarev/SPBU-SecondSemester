using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SCPMovement : MonoBehaviour
{
    public Rigidbody rigidbody;

    [SerializeField]
    public Transform playerPosition;

    public float speed;

    public float visibilityDistance;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (transform.position != new Vector3(97.23f, -31f, 24.03f))
        //{
        //    return;
        //}

        float distanceToPlayer = Vector3.Distance(transform.position, playerPosition.position);

        if (distanceToPlayer < visibilityDistance)
        {
            rigidbody.velocity = new Vector3(0, 0, -speed);
        }
        //else
        //{
        //    rigidbody.velocity.Normalize();
        //}
        Debug.Log("Distance - " + distanceToPlayer);
    }
}