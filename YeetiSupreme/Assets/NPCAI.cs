using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class NPCAI : MonoBehaviour
{
    [SerializeField] Transform[] moveToStory;
    [SerializeField] bool movingToPosition;
    [SerializeField] NavMeshAgent agent;
    private void Update()
    {
        MoveToPosition();
    }
    public void MoveToPosition()
    {
        if (movingToPosition)
        {
            agent.SetDestination(moveToStory[0].position);
            if (this.transform.position == moveToStory[0].position)
            {
                movingToPosition = false;
            }

        }
    }
    public void StartWalk()
    {
        movingToPosition = true;
    }
}
