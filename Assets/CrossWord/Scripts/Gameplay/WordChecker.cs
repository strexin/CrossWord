using System.Collections.Generic;
using CrossWord.Scripts.Interfaces;
using CrossWord.Scripts.Manager;
using UnityEngine;

namespace CrossWord.Scripts.Gameplay
{
    /// <summary>
    /// Checking the collected letter with the correct word.
    /// </summary>
    public class WordChecker : MonoBehaviour, IWordChecker
    {
        #region IWordChecker

        [field: SerializeField] 
        public List<string> CorrectWord { get; set; } = null;

        #endregion

        #region Mono

        private void OnEnable()
        {
            EventManager.OnLetterCollected += CheckWord;
        }

        private void OnDisable()
        {
            EventManager.OnLetterCollected -= CheckWord;
        }

        #endregion
        
        #region Main

        /// <summary>
        /// Called when the player has collected letter and will check if the word is correct or not.
        /// </summary>
        /// <param name="word">
        /// The word that will be checked.
        /// </param>
        private void CheckWord(string word)
        {
            foreach (var correct in CorrectWord)
            {
                if (correct == word)
                {
                    Debug.Log(word + " is correct");

                    CorrectWord.Remove(correct);

                    if (CorrectWord.Count == 0)
                    {
                        Debug.Log("Player win");
                    }

                    return;
                }
            }
            
            Debug.Log("Wrong word");
        }

        #endregion
    }
}
