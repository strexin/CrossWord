using CrossWord.Scripts.Manager;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CrossWord.Scripts.System
{
    /// <summary>
    /// Handle the display of win panel when player finish the level.
    /// </summary>
    public class CompleteLevelPanel : MonoBehaviour
    {
        #region Mono

        private void Awake()
        {
            EventManager.OnCompleteLevel += ShowCompleteLevel;
        }

        private void OnDestroy()
        {
            EventManager.OnCompleteLevel -= ShowCompleteLevel;
        }

        private void Start()
        {
            gameObject.SetActive(false);
        }

        #endregion
        
        #region Main

        /// <summary>
        /// Called when player finish the level. Show the complete panel.
        /// </summary>
        private void ShowCompleteLevel()
        {
            gameObject.SetActive(true);
        }

        /// <summary>
        /// Called in button. Restart the current scene.
        /// </summary>
        public void RestartLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        #endregion
    }
}
