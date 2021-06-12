using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ReversePlatformer
{
    public class EndGameState : FSMState
    {
        #region Constructor
        public EndGameState(GameStateController controller)
        {
            _controller = controller;
            stateID = StateID.GameOver;
        }
        #endregion

        #region Fields
        private GameStateController _controller = null;
        #endregion

        #region Overrides
        public override void Act()
        {
            //Write here what's supposed to happen on the endgamestate
        }

        public override void Reason()
        {
            //Write here the condition to reset the scene.
        }
        #endregion
    }
}