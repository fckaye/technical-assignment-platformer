using UnityEngine.SceneManagement;

namespace ReversePlatformer
{
    public class EndGameState : FSMState
    {
        #region Constructor
        public EndGameState(GameOverPanel gameOverPanel, GameStateController controller)
        {
            _gameOverPanel = gameOverPanel;
            _controller = controller;
            stateID = StateID.GameOver;
        }
        #endregion

        #region Fields
        private GameStateController _controller = null;
        private GameOverPanel _gameOverPanel = null;
        #endregion

        #region Overrides
        public override void DoBeforeEntering()
        {
            _gameOverPanel.DisplayGameOverPanel();
        }

        public override void Reason()
        {
            if (_gameOverPanel.IsReadyToRestart)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
            }
        }

        public override void Act()
        {

        }
        #endregion
    }
}