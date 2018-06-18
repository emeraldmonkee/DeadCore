using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using States;

public class Awakestate : State<Sleeper_AI>
{
    private static Awakestate _instance;

    private Awakestate()
    {
        if (_instance != null)
        {
            return;
        }
        _instance = this;
    }

    public static Awakestate Instance
    {
        get
        {
            if (_instance == null)
            {
                new Awakestate();
            }
            return _instance;
        }
    }

    public override void EnterState(Sleeper_AI _owner)
    {
        Debug.Log("Entering Awake State");

        //play walking animation on loop
    }

    public override void ExitState(Sleeper_AI _owner)
    {
        Debug.Log("Exiting Awake State");
    }

    public override void UpdateState(Sleeper_AI _owner)
    {
        _owner.SetDestination();
    }
}
