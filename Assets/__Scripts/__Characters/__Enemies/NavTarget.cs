using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavTarget : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent _Agent;

    [SerializeField]
    private Vector3 _PositionTarget;

    [SerializeField]
    private float _RangeAttack; //It's the max range that the prefab will going to move;

    //To avoid enter in the condition on the update everytime when is walking the enemy
    private bool _IsMoving = true;

    private void Awake()
    {
        _Agent = this.gameObject.GetComponent<NavMeshAgent>();
        Vector3 tmpTransform = GameObject.FindGameObjectWithTag("Target").transform.position;
        //+1.0f it's a offset to avoid that the characters go to the backside of the target
        _PositionTarget = new Vector3(tmpTransform.x, tmpTransform.y, tmpTransform.z + 1.0f); 

    }


    private void OnEnable()
    {
        _Agent.SetDestination(_PositionTarget);
        _Agent.stoppingDistance = _RangeAttack;
    }

    //At the moment, we don't have any skill that it can cause that effect
    //private void Update()
    //{
    //   if(_Agent.isStopped == true && _IsMoving) //At its location
    //   {
    //        _IsMoving = false;
    //        //Call event animation, then the animation has to call the attack event
    //   }
    //    //This condition is in case the hero's ability causes the enemy to retreat, 
    //    //and as a consequence it should stop doing the attack animation and start walking again.
    //   else if (_Agent.isStopped == false && _IsMoving == false)
    //   {
    //        _IsMoving = true;
    //        //Call to cancel event animation
    //   }

    //}
}
