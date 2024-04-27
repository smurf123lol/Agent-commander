using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentScript : MonoBehaviour
{
    public GameObject casing;
    public GameObject destination;

    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        SetDestination(destination);
    }

    void SetDestination(GameObject dest)
    {
        destination = dest;
        animator.SetFloat("speed", 1f);
        casing.GetComponent<NavMeshAgent>().SetDestination (destination.transform.position);

    }

    // Update is called once per frame
    void Update()
    {
        if (destination != null)
        {
            if(Vector3.Distance(transform.position, destination.transform.position) <= 1f) {
                destination = null;
                animator.SetFloat("speed", 0.01f);

            }
        }
    }
}
