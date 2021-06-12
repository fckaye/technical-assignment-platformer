using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ReversePlatformer
{
    public class CursorController : MonoBehaviour
    {
        #region Fields
        [SerializeField] private Texture2D _normalCursor = null;
        [SerializeField] private Texture2D _pointCursor = null;
        #endregion

        #region MonoBehaviour callbacks
        private void Awake()
        {
            ChangeCursor(_normalCursor);
            //Cursor.lockState = CursorLockMode.Confined;
        }
        #endregion

        #region Private
        private void ChangeCursor(Texture2D cursor)
        {
            Cursor.SetCursor(cursor, Vector2.zero, CursorMode.Auto);
        }
        #endregion
    }
}
