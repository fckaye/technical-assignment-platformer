using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ReversePlatformer
{
    public class Stone : MonoBehaviour, IJumpable
    {
        #region Fields
        [SerializeField] private JumpableTypes _jumpType = JumpableTypes.highJumpable;
        [SerializeField] private bool _canBeJumped;
        [SerializeField] private bool _hasObstacleOnTop;
        #endregion

        #region Interface implementations
        Hazard IJumpable.onJumpableApproach()
        {
            return new Hazard(_jumpType, _canBeJumped, transform);
        }
        #endregion
    }
}