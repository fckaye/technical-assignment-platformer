using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ReversePlatformer
{
    public class PlayGameState : FSMState
    {
        #region Constructor
        public PlayGameState(Avatar avatar, GameStateController controller)
        {
            _controller = controller;
            _avatar = avatar;
            stateID = StateID.GameMain;
        }
        #endregion

        #region Fields
        private GameStateController _controller = null;
        private Avatar _avatar = null;
        #endregion

        #region Overrides
        public override void DoBeforeEntering()
        {
            _avatar.StartRolling();
        }

        public override void Act()
        {
            //Write here the main logic of the game.
            //Make here a method to add the score and counter.
        }

        public override void Reason()
        {
            if (_avatar.CurrentStatus == Avatar.AvatarStatus.Dead)
            {
                _controller.SetTransition(Transition.GamePlayerDestroyed);
            }
        }
        #endregion
    }
}
