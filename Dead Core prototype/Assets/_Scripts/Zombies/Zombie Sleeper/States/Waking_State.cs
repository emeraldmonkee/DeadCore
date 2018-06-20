using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using States;

public class Wakingstate : State<Sleeper_AI>
{
    private static Wakingstate _instance;

    private Wakingstate()
    {
        if (_instance != null)
        {
            return;
        }
        _instance = this;
    }

    public static Wakingstate Instance
    {
        get
        {
            if (_instance == null)
            {
                new Wakingstate();
            }
            return _instance;
        }
    }

    public override void EnterState(Sleeper_AI _owner)
    {
        Debug.Log("Entering Waking State");
        //play the waking up animation
    }

    public override void ExitState(Sleeper_AI _owner)
    {
        Debug.Log("Exiting Waking State");
    }

    public override void UpdateState(Sleeper_AI _owner)
    {
        _owner.wakingAnimationTime = _owner.wakingAnimationTime + Time.deltaTime;
        if(_owner.wakingAnimationTime > _owner.wakingUpPeriod)
        {
            _owner.stateMachine.ChangeState(Patrol_State.Instance);
        }
    }
}
