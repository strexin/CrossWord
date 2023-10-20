using CrossWord.Scripts.Manager;
using TMPro;
using UnityEngine;

namespace CrossWord.Scripts.Gameplay
{
    /// <summary>
    /// Handle the letter display when player touch the letter card.
    /// </summary>
    public class CollectedLetterDisplay : MonoBehaviour
    {
        #region Variable

        /// <summary>
        /// Word that collected and will be displayed.
        /// </summary>
        private string _displayWord = default;

        /// <summary>
        /// Component that used to display the temporary collected letter.
        /// </summary>
        private TextMeshProUGUI _displayTempCollectedLetter = null;

        #endregion

        #region Mono

        private void Awake()
        {
            _displayTempCollectedLetter = GetComponentInChildren<TextMeshProUGUI>();
        }

        private void OnEnable()
        {
            EventManager.OnSendLetterInformation += GetTempCollectedLetter;

            EventManager.OnTouchInputEnded += TouchInputRemoved;
        }

        private void OnDisable()
        {
            EventManager.OnSendLetterInformation -= GetTempCollectedLetter;

            EventManager.OnTouchInputEnded -= TouchInputRemoved;
        }

        private void Start()
        {
            _displayTempCollectedLetter.SetText("");
        }

        #endregion

        #region Main

        /// <summary>
        /// Called when player touch the letter card, get the letter and update the letter display.
        /// </summary>
        /// <param name="letter"></param>
        private void GetTempCollectedLetter(char letter)
        {
            _displayWord += letter.ToString();
            
            _displayTempCollectedLetter.SetText(_displayWord);
        }
        
        /// <summary>
        /// Called when player removed the touch input from screen. Reset the letter display.
        /// </summary>
        private void TouchInputRemoved()
        {
            _displayWord = string.Empty;
            
            _displayTempCollectedLetter.SetText("");
        }

        #endregion
    }
}
