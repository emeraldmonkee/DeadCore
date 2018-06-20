using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using States;

    public class Detected_Player_State : State<Sleeper_AI>
    {
        private static Detected_Player_State _instance;

        private Detected_Player_State()
        {
            if (_instance != null)
            {
                return;
            }
            _instance = this;
        }

        public static Detected_Player_State Instance
        {
            get
            {
                if (_instance == null)
                {
                    new Detected_Player_State();
                }
                return _instance;
            }
        }

        public override void EnterState(Sleeper_AI _owner)
        {
            Debug.Log("Entering Detected Player State");
        }

        public override void ExitState(Sleeper_AI _owner)
        {
            Debug.Log("Exiting Detected Player State");
        }

        public override void UpdateState(Sleeper_AI _owner)
        {
            _owner.SetDestination_Player();
        }
    }

