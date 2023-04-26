using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPatrol : AIController
{
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    } 
    //FSM for Patrol AI Varient
    public override void MakeDecisions()
    {
        switch (currentState)
        {
            
            case AIState.Chase:
                if (!IsHasTarget())
                {
                   
                    ChangeState(AIState.ChooseTarget);

                }
                DoAttackState();
                if (target != null)
                {
                    if (!IsDistanceLessThan(target, 7))
                    {

                        ChangeState(AIState.Patrol);
                    }
                }
                
                break;
            
            case AIState.Patrol:
                if (!IsHasTarget())
                {
                    
                    ChangeState(AIState.ChooseTarget);
                }
                DoPatrolState();
                if (target != null)
                {
                    if (CanHear(target))
                    {
                        
                        ChangeState(AIState.Chase);
                    }
                    if (CanSee(target))
                    {
                        
                        ChangeState(AIState.Chase);
                    }
                }
                break;
            case AIState.ChooseTarget:
                DoChooseTargetState();
                
                ChangeState(AIState.Patrol);

                break;
            
               

        }

    }
}
