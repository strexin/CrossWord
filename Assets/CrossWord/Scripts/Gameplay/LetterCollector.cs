using System.Collections.Generic;
using CrossWord.Scripts.Manager;
using UnityEngine;

namespace CrossWord.Scripts.Gameplay
{
    public class LetterCollector : MonoBehaviour
    {
        #region Variable

        /// <summary>
        /// All collected letter and combine to become a word.
        /// </summary>
        private List<char> _collectedLetter = default;

        /// <summary>
        /// The final word that collected when player interact with card letter.
        /// </summary>
        private string _finalWord = default;

        #endregion

        #region Mono

        private void Start()
        {
            _collectedLetter = new List<char>();
        }

        private void OnEnable()
        {
            EventManager.OnSendLetterInformation += CollectLetter;

            EventManager.OnTouchInputEnded += TouchInputRemoved;
        }

        private void OnDisable()
        {
            EventManager.OnSendLetterInformation -= CollectLetter;
            
            EventManager.OnTouchInputEnded -= TouchInputRemoved;

        }

        #endregion

        #region Main

        /// <summary>
        /// Called when player add a letter to make it a word.
        /// </summary>
        /// <param name="letter">
        /// The letter that added to the collected letter.
        /// </param>
        private void CollectLetter(char letter)
        {
            _collectedLetter.Add(letter);
        }

        /// <summary>
        /// Called when player removed the touch input from screen. Checking the letter that has collected.
        /// </summary>
        private void TouchInputRemoved()
        {
            _finalWord = new string(_collectedLetter.ToArray());

            EventManager.BroadcastOnLetterCollected(_finalWord);
            
            _collectedLetter.Clear();
        }

        #endregion
    }
}