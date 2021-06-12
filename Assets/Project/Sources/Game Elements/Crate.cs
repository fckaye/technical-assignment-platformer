using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ReversePlatformer
{
    public class Crate : MonoBehaviour, IClickable
    {
        #region Fields
        private MeshRenderer _crateMesh = null;
        private BoxCollider _crateCollider = null;
        private ParticleSystem _explosion = null;
        #endregion

        #region Interface implementations
        public void onClickedAction()
        {
            if (_explosion != null)
            {
                _explosion.Play();
            }
            _crateMesh.enabled = false;
            _crateCollider.enabled = false;
            Destroy(this, 1);
        }
        #endregion

        #region MonoBehaviour callbacks
        private void Awake()
        {
            _crateMesh = gameObject.GetComponent<MeshRenderer>();
            _crateCollider = gameObject.GetComponent<BoxCollider>();
            _explosion = gameObject.GetComponentInChildren<ParticleSystem>();
        }
        #endregion
    }
}