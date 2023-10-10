using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Agent : MonoBehaviour
{
    public string TargetTag = "Target";
    private GameObject[] _targets;
    private NavMeshAgent _agent;

    // Start is called before the first frame update
    private void Start()
    {
        //setup agent
        _agent = this.GetComponent<NavMeshAgent>();

        //Debug.Log("Targets: " + _targets.Length);
        ResetTarget();
    }

    private void ResetTarget()
    {
        _targets = GameObject.FindGameObjectsWithTag(TargetTag);
        //send agent to random Target
        int rand = Random.Range(0, _targets.Length);
        _agent.SetDestination(_targets[rand].transform.position);
    }

    // Update is called once per frame
    private void Update()
    {
        if (_agent.remainingDistance < 1)
        {
            ResetTarget();
        }
    }
}