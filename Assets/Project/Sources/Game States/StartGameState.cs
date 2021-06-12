﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading.Tasks;

namespace ReversePlatformer
{
    public class StartGameState : FSMState
    {
        #region Constructor
        public StartGameState(int countdownLength, TextMeshProUGUI countdownText, GameStateController owner)
        {
            _owner = owner;
            _countdownText = countdownText;
            _countdownLength = countdownLength;
        }
        #endregion

        #region Fields
        private GameStateController _owner = null;
        private TextMeshProUGUI _countdownText = null;
        private int _countdownLength;
        private int _countdown = int.MaxValue;
        private bool _startedCountdown = false;
        #endregion

        #region Overrides
        public override void Act()
        {
            if (!_startedCountdown)
            {
                _countdown = _countdownLength;
                _ = Countdown();
            }
        }

        public override void Reason()
        {
            if (_countdown < 0)
            {
                Debug.Log("Countdown ended");
                //Return control to gamestatecontroller to transition to game state.
                _owner.SetTransition(Transition.StartCoundownOver);
            }
        }

        public override void DoBeforeLeaving()
        {
            _countdownText.gameObject.SetActive(false);
        }
        #endregion

        #region Private
        private async Task Countdown()
        {
            _startedCountdown = true;

            while (_countdown >= 0)
            {
                await Task.Delay(700);
                _countdownText.text = _countdown.ToString();
                if (_countdown == 0)
                {
                    _countdownText.text = "GO!";
                }
                await Task.Delay(300);
                _countdown--;
            }
        }
        #endregion
    }
}