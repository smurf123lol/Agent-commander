using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentScript : MonoBehaviour
{
    public GameObject casing;
    public List<DestinationPoint> KnownDestinations;
    public GameObject destination;
    public VoskSpeechToText VoskSpeechToText;
    Animator animator;
    // Start is called before the first frame update
    private void Awake()
    {
        animator = GetComponent<Animator>();
        VoskSpeechToText.OnTranscriptionResult += OnTranscriptionResult;
    }

    private void OnTranscriptionResult(string obj)
    {
        var result = new RecognitionResult(obj);
        foreach (var item in result.Phrases) {
            foreach (var dest in KnownDestinations)
            {
                //if(dest.TranscriptionName.ToLower()==item.Text) {
                if (item.Text.Contains(dest.TranscriptionName.ToLower()))
                {
                        SetDestination(dest.gameObject);
                }
            }
        }
    }

    void Start()
    {
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
