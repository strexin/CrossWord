using CrossWord.Scripts.Manager;
using UnityEngine;
using UnityEngine.Serialization;

namespace CrossWord.Scripts.Gameplay
{
    /// <summary>
    /// Handle the display when player get the correct word.
    /// </summary>
    public class CorrectWordDisplay : MonoBehaviour
    {
        #region Variable

        /// <summary>
        /// The correct word that used to display the word when player submit this word.
        /// </summary>
        [FormerlySerializedAs("correctWord")] [SerializeField]
        private string displayWord = default;

        #endregion

        #region Mono

        private void Awake()
        {
            EventManager.OnSubmitCorrectWord += DisplayWord;
        }

        private void OnDestroy()
        {
            EventManager.OnSubmitCorrectWord -= DisplayWord;
        }

        private void Start()
        {
            gameObject.SetActive(false);
        }

        #endregion

        #region Main

        /// <summary>
        /// Called when player submit the correct word. Display the correct word.
        /// </summary>
        /// <param name="word">
        /// The correct word.
        /// </param>
        private void DisplayWord(string word)
        {
            if (word == displayWord)
            {
                gameObject.SetActive(true);
            }
        }

        #endregion
    }
}