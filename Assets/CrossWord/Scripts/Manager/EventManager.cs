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

        #endregion
    }
}
