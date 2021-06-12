using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ReversePlatformer
{
    [RequireComponent(typeof(Rigidbody))]
    public class Avatar : MonoBehaviour
    {
        #region Fields
        public enum AvatarStatus
        {
            Idle,
            MovingForward,
            Dead
        }

        private AvatarStatus _currentStatus = new AvatarStatus();
        public AvatarStatus CurrentStatus => _currentStatus;

        [SerializeField] private float _speed;

        private Rigidbody _rb = null;
        #endregion

        #region MonoBehaviour Callbacks
        private void Awake()
        {
            _currentStatus = AvatarStatus.Idle;
            _rb = gameObject.GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            if (_currentStatus == AvatarStatus.MovingForward)
            {
                MoveForward();
            }
        }
        #endregion

        #region Public
        public void StartRolling()
        {
            if (_currentStatus == AvatarStatus.Idle)
            {
                _currentStatus = AvatarStatus.MovingForward;
            }
        }
        #endregion

        #region Private
        private void MoveForward()
        {
            Vector3 direction = Vector3.right;

            _rb.AddForce(direction * _speed);
        }
        #endregion
    }
}
