using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

internal class MoveCommand : Command
{

    private readonly Vector3 destination;
    private readonly NavMeshAgent agent;
    public MoveCommand(Vector3 destination, NavMeshAgent agent)
    {
        this.destination = destination;
        this.agent = agent;
    }



    public override bool isFinished => agent.remainingDistance<=0.1f;

    public override void Execute()
    {

        agent.SetDestination(destination);

    }
}
