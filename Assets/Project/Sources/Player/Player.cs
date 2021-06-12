using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ReversePlatformer
{
    public class Player : MonoBehaviour
    {
        #region Fields
        private bool _canInteract = false;
        public bool CanInteract => _canInteract;
        #endregion

        #region MonoBehaviour Callbacks
        private void Update()
        {
            if (_canInteract)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    InteractWithObjectInScene();
                }

                if (Input.GetMouseButtonDown(1))
                {
                    PlaceSelectedObjectInScene();
                }

                //Add scrollwheel interactions here later.

            }
        }
        #endregion

        #region Public
        public void StartInteracting()
        {
            _canInteract = true;
        }
        #endregion

        #region Private
        private void InteractWithObjectInScene()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null)
                {
                    IClickable clickable = hit.collider.gameObject.GetComponent<IClickable>();
                    if (clickable != null)
                    {
                        clickable.onClickedAction();
                    }
                }
            }
        }

        private void PlaceSelectedObjectInScene()
        {

        }
        #endregion
    }
}