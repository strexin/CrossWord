using System;
using UnityEngine;

namespace CrossWord.Scripts.Manager
{
    /// <summary>
    /// Handle the event to maintain the scripts flow.
    /// </summary>
    public static class EventManager
    {
        #region Event

        /// <summary>
        /// Event that called when player press the word card.
        /// </summary>
        public static event Action<GameObject> OnCardPressed;

        /// <summary>
        /// Event that called when letter card send the letter information to letter collector.
        /// </summary>
        public static event Action<char> OnSendLetterInformation;

        /// <summary>
        /// Event that called when card get touched by player and activate the line connector.
        /// </summary>
        public static event Action<Vector3> OnActivatedLine;

        /// <summary>
        /// Event that called to update the line position same as the touch input.
        /// </summary>
        public static event Action<Vector3> OnLineUpdatePosition;

        /// <summary>
        /// Event that called when the player remove the touch input from screen.
        /// </summary>
        public static event Action OnTouchInputEnded;

        /// <summary>
        /// Event that called when the letter from player has collected.
        /// </summary>
        public static event Action<string> OnLetterCollected;

        /// <summary>
        /// Event that called when player submit the correct word.
        /// </summary>
        public static event Action<string> OnSubmitCorrectWord;

        /// <summary>
        /// Event that called when player complete current level.
        /// </summary>
        public static event Action OnCompleteLevel;

        #endregion

        #region Broadcaster

        /// <summary>
        /// Broadcast the OnCardPressed event when touch input press the word card.
        /// </summary>
        /// <param name="card">
        /// the card that get touched by player.
        /// </param>
        public static void BroadcastOnCardPressed(GameObject card) => OnCardPressed?.Invoke(card);

        /// <summary>
        /// Broadcast the OnSendLetterInformation event when card get touched by player.
        /// </summary>
        /// <param name="letter">
        /// The letter on card.
        /// </param>
        public static void BroadcastOnSendLetterInformation(char letter) => OnSendLetterInformation?.Invoke(letter);

        /// <summary>
        /// Broadcast the OnActivatedLine event when card get touched by player.
        /// </summary>
        /// <param name="cardPos">
        /// The position of the card that get touched by player.
        /// </param>
        public static void BroadcastOnActivatedLine(Vector3 cardPos) => OnActivatedLine?.Invoke(cardPos);

        /// <summary>
        /// Broadcast the OnLineUpdatePosition event when player give touch input and has touched a card.
        /// </summary>
        /// <param name="pos">
        /// The position for input touch.
        /// </param>
        public static void BroadcastOnLineUpdatePosition(Vector3 pos) => OnLineUpdatePosition?.Invoke(pos);

        /// <summary>
        /// Broadcast the OnTouchInputEnded event when player remove the touch input,
        /// </summary>
        public static void BroadcastOnTouchInputEnded() => OnTouchInputEnded?.Invoke();

        /// <summary>
        /// Broadcast the OnLetterCollected event to check the word in word checker.
        /// </summary>
        /// <param name="word">
        /// The word that wanted to check.
        /// </param>
        public static void BroadcastOnLetterCollected(string word) => OnLetterCollected?.Invoke(word);

        /// <summary>
        /// Broadcast the OnSubmitCorrectWord event to display the correct word.
        /// </summary>
        /// <param name="word">
        /// The correct word.
        /// </param>
        public static void BroadcastOnSubmitCorrectWord(string word) => OnSubmitCorrectWord?.Invoke(word);

        /// <summary>
        /// Broadcast the OnCompleteLevel event to display the win panel.
        /// </summary>
        public static void BroadcastOnCompleteLevel() => OnCompleteLevel?.Invoke();

        #endregion
    }
}
