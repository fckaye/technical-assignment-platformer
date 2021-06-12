﻿
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace ReversePlatformer
{
    public class GameStateController : MonoBehaviour
    {
        #region Fields
        [Header("References Necessary for GameStart")]
        [SerializeField] private TextMeshProUGUI _countdownText = null;
        [SerializeField] private int _countdownLength = 5;

        [Header("References Necessary for MainGame")]
        //[SerializeField] private GameObject caca = null;
        [Header("References Necessary for GameOver")]
        //[SerializeField] private GameObject popo = null;

        private FSMSystem fsm;
        #endregion

        #region MonoBehaviour callbacks
        private void Start()
        {
            MakeFSM();
        }

        private void FixedUpdate()
        {
            fsm.CurrentState.Reason();
            fsm.CurrentState.Act();
        }
        #endregion

        #region Public
        public void SetTransition(Transition t) 
        { 
            fsm.PerformTransition(t); 
        }
        #endregion

        #region Private
        private void MakeFSM()
        {
            StartGameState start = new StartGameState(_countdownLength, _countdownText, this);
            start.AddTransition(Transition.StartCoundownOver, StateID.MainGame);

            fsm = new FSMSystem();
            fsm.AddState(start);
        }
        #endregion
    }
}