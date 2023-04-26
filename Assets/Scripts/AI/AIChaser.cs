using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIChaser : AIController
{
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }
    //FSM for Chaser AI varient
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
                    if (IsDistanceLessThan(target, 10))
                    {
                        ChangeState(AIState.Flee);
                    }
                }
                break;
            case AIState.Flee:
                if (!IsHasTarget())
                {
                    
                    ChangeState(AIState.ChooseTarget);
                }
                DoFleeState();
                if (target != null)
                {
                    if (!IsDistanceLessThan(target, 15))
                    {
                        
                        ChangeState(AIState.Chase);
                    }
                }
                break;
            
            case AIState.ChooseTarget:
                DoChooseTargetState();
                
                ChangeState(AIState.Chase);

                break;
            


        }
    }
}
