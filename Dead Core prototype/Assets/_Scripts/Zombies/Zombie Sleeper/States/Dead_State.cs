using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using States;

public class Deadstate : State<Sleeper_AI>
{
    private static Deadstate _instance;

    private Deadstate()
    {
        if (_instance != null)
        {
            return;
        }
        _instance = this;
    }

    public static Deadstate Instance
    {
        get
        {
            if (_instance == null)
            {
                new Deadstate();
            }
            return _instance;
        }
    }

    public override void EnterState(Sleeper_AI _owner)
    {
        Debug.Log("Entering Dead State");
    }

    public override void ExitState(Sleeper_AI _owner)
    {
        Debug.Log("Exiting Dead State");
    }

    public override void UpdateState(Sleeper_AI _owner)
    {

    }
}
