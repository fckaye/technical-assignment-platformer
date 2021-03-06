using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ReversePlatformer
{
    public class Lava : MonoBehaviour, IContactDamager, IJumpable
    {
        #region Fields
        [SerializeField] private JumpableTypes _jumpType = JumpableTypes.longJumpable;
        [SerializeField] private bool _canBeJumped;
        #endregion

        #region Interface implementations
        public void onContactWithAvatar(Avatar avatar)
        {
            avatar.ReceiveDamage();
        }

        Hazard IJumpable.onJumpableApproach()
        {
            return new Hazard(_jumpType, _canBeJumped, transform);
        }
        #endregion
    }
}
