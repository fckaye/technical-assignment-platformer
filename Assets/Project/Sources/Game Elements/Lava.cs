using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ReversePlatformer
{
    public class Lava : MonoBehaviour, IContactDamager
    {
        #region Interface implementations
        public void onContactWithAvatar(Avatar avatar)
        {
            avatar.ReceiveDamage();
        }
        #endregion
    }
}
