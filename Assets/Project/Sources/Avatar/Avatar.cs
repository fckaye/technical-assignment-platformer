using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace ReversePlatformer
{
    /// <summary>
    /// The Avatar of the game, this agent can move and jump by itself.
    /// </summary>
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
            ApproachingHazard,
            Dead
        }

        private AvatarStatus _currentStatus = new AvatarStatus();
        public AvatarStatus CurrentStatus => _currentStatus;

        [SerializeField] private float _speed;
        [SerializeField] private int _maxHitPoints = 1;

        private int _hitPoints;
        private Rigidbody _rb = null;
        private ConstantForce _constantForce = null;
        private HazardScanner _hazardScanner = null;
        #endregion

        #region MonoBehaviour Callbacks
        private void Awake()
        {
            _currentStatus = AvatarStatus.Idle;
            _hitPoints = _maxHitPoints;
            _rb = gameObject.GetComponent<Rigidbody>();
            _constantForce = gameObject.GetComponent<ConstantForce>();
            _hazardScanner = gameObject.GetComponent<HazardScanner>();
        }

        private void FixedUpdate()
        {
            DetermineMovement();
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
        /// <summary>
        /// Sets the Avatar in forward motion.
        /// It will keep this forward movement and watch for avoidable Hazards.
        /// </summary>
        public void MoveForward()
        {
            if (_currentStatus != AvatarStatus.MovingForward)
            {
                _currentStatus = AvatarStatus.MovingForward;
                _constantForce.enabled = true;
                _constantForce.force = Vector3.right * _speed;
            }
        }

        /// <summary>
        /// Damage the Avatar by 1.
        /// </summary>
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
        /// <summary>
        /// Decide what action should the Avatar do given current circumstances.
        /// </summary>
        private void DetermineMovement()
        {
            if (_currentStatus == AvatarStatus.MovingForward)
            {
                Hazard hazardAhead = _hazardScanner.ScanForHazardsAhead();
                if (hazardAhead != null)
                {
                    StartCoroutine(ApproachHazard(hazardAhead));
                    _currentStatus = AvatarStatus.ApproachingHazard;
                }
            }
        }

        /// <summary>
        /// The Avatar carefully approaches the obstacle ahead.
        /// Stops in front of the Hazard and crosses it.
        /// </summary>
        /// <param name="hazard"></param>
        private IEnumerator ApproachHazard(Hazard hazard)
        {
            // Get close to the edge of the hazard and stop.
            float edgeDistance = hazard._jumpType == JumpableTypes.longJumpable ? 2 : 1;
            while (Mathf.Abs(transform.position.x - hazard._transform.position.x) > edgeDistance)
            {
                yield return null;
            }
            _constantForce.force = Vector3.zero;
            _rb.velocity = Vector3.zero;
            _rb.angularVelocity = Vector3.zero;

            // Perform the respective jump if it is possible.
            if (hazard._canBeJumped)
            {
                Vector3 longJumpType = new Vector3(4, 0, 0);
                Vector3 highJumpType = new Vector3(1, 1, 0);
                Vector3 jumpType = hazard._jumpType == JumpableTypes.longJumpable ? longJumpType: highJumpType;
                Vector3 target = transform.position + jumpType;
                Tween jump = transform.DOJump(target, 2, 1, 1, false);
                yield return jump.WaitForCompletion();
            }

            // Back to normal, keep moving forward.
            _rb.velocity = Vector3.zero;
            _rb.angularVelocity = Vector3.zero;
            MoveForward();
            yield return null;
        }
        #endregion
    }
}
