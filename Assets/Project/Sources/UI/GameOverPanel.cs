using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace ReversePlatformer
{
    public class GameOverPanel : MonoBehaviour
    {
        #region Fields
        [SerializeField] private TextMeshProUGUI _pointsText = null;
        [SerializeField] private TextMeshProUGUI _timeText = null;
        [SerializeField] private Button _restartButton = null;

        private bool _isReadyToRestart = false;
        public bool IsReadyToRestart => _isReadyToRestart;
        #endregion

        #region MonoBehaviour callbacks
        private void Awake()
        {
            _isReadyToRestart = false;
            _restartButton.onClick.AddListener(() => ReadyToRestart());
            if (gameObject.activeSelf)
            {
                gameObject.SetActive(false);
            }
        }
        #endregion

        #region Public
        public void DisplayGameOverPanel()
        {
            gameObject.SetActive(true);
        }
        #endregion

        #region Private
        private void ReadyToRestart()
        {
            _isReadyToRestart = true;
        }
        #endregion
    }
}