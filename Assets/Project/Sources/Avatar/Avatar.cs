using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ReversePlatformer
{
    [RequireComponent(typeof(HazardScanner))]
    [RequireComponent(typeof(SphereCollider))]
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(ConstantForce))]
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
        [SerializeField] private int _maxHitPoints = 1;

        private int _hitPoints;
        private Rigidbody _rb = null;
        private ConstantForce _constantForce = null;
        #endregion

        #region MonoBehaviour Callbacks
        private void Awake()
        {
            _currentStatus = AvatarStatus.Idle;
            _hitPoints = _maxHitPoints;
            _rb = gameObject.GetComponent<Rigidbody>();
            _constantForce = gameObject.GetComponent<ConstantForce>();
        }

        private void FixedUpdate()
        {
            if (_currentStatus == AvatarStatus.MovingForward)
            {
                MoveForward();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            IContactDamager contactDamager = other.gameObject.GetComponent<IContactDamager>();
            if (contactDamager != null)
            {
                contactDamager.onContactWithAvatar(this);
            }
        }
        #endregion

        #region Public
        public void StartRolling()
        {
            if (_currentStatus == AvatarStatus.Idle)
            {
                _currentStatus = AvatarStatus.MovingForward;
                _constantForce.enabled = true;
                _constantForce.force = Vector3.right * _speed;
            }
        }

        public void ReceiveDamage()
        {
            _hitPoints--;
            if (_hitPoints <= 0)
            {
                _currentStatus = AvatarStatus.Dead;
            }
        }
        #endregion

        #region Private
        private void MoveForward()
        {

        }
        #endregion
    }
}
