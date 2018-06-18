using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using States;

public class Sleepingstate : State<Sleeper_AI>
{
    private static Sleepingstate _instance;

    private Sleepingstate()
    {
        if(_instance != null)
        {
            return;
        }
        _instance = this;
    }

    public  static Sleepingstate Instance
    {
        get
        {
            if (_instance == null)
            {
                new Sleepingstate();
            }
            return _instance;
        }
    }

    public override void EnterState(Sleeper_AI _owner)
    {
        Debug.Log("Entering Sleeping State");
    }

    public override void ExitState(Sleeper_AI _owner)
    {
        Debug.Log("Exiting Sleeping State");
    }

    public override void UpdateState(Sleeper_AI _owner)
    {
        if (_owner.detected == true)
        {
            _owner.stateMachine.ChangeState(Wakingstate.Instance);
        }
    }
}
