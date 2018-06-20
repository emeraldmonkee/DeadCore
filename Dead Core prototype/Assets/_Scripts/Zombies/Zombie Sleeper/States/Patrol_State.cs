using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using States;

public class Patrol_State : State<Sleeper_AI>
{
    private static Patrol_State _instance;

    private Patrol_State()
    {
        if (_instance != null)
        {
            return;
        }
        _instance = this;
    }

    public static Patrol_State Instance
    {
        get
        {
            if (_instance == null)
            {
                new Patrol_State();
            }
            return _instance;
        }
    }

    public override void EnterState(Sleeper_AI _owner)
    {
        Debug.Log("Entering Patrol State");

        //play walking animation on loop
    }

    public override void ExitState(Sleeper_AI _owner)
    {
        Debug.Log("Exiting Pater State");
    }

    public override void UpdateState(Sleeper_AI _owner)
    {
        if (_owner.chasingPlayer == true)
        {
            _owner.stateMachine.ChangeState(Detected_Player_State.Instance);
        }

    }
}
