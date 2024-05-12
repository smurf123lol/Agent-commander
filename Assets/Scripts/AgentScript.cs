using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentScript : MonoBehaviour
{
    // Объект с навмешем
    public GameObject Casing;
    // Список точек для перемещения
    public List<DestinationPoint> KnownDestinations;
    // Объект для перемещения до позиции
    public GameObject destination;

    public VoskSpeechToText VoskSpeechToText;

    Animator animator;

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
    void SetDestination(GameObject dest)
    {
        destination = dest;
        animator.SetFloat("speed", 1f);
        Casing.GetComponent<NavMeshAgent>().SetDestination (destination.transform.position);

    }

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
    void Start()
    {
        SetDestination(destination);
    }
    private void Awake()
    {
        animator = GetComponent<Animator>();
        VoskSpeechToText.OnTranscriptionResult += OnTranscriptionResult;
    }
}
