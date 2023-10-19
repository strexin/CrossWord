using CrossWord.Scripts.Manager;
using TMPro;
using UnityEngine;

namespace CrossWord.Scripts.Gameplay
{
    /// <summary>
    /// The card that contain letter that can be interacted by player.
    /// </summary>
    public class CardWord : MonoBehaviour
    {
        #region Variable

        /// <summary>
        /// Letter that show and include in the card.
        /// </summary>
        [SerializeField]
        private char letterInCard = default;

        /// <summary>
        /// The condition where the card has been touched by player or not.
        /// </summary>
        private bool _hasTouched = default;

        /// <summary>
        /// The text that used to display the letter for this card.
        /// </summary>
        private TextMeshProUGUI _showText = default;

        #endregion

        #region Mono

        private void Awake()
        {
            _showText = GetComponentInChildren<TextMeshProUGUI>();
        }

        private void OnEnable()
        {
            EventManager.OnCardPressed += ReceiveTouchInput;

            EventManager.OnTouchInputEnded += TouchInputRemoved;
        }

        private void OnDisable()
        {
            EventManager.OnCardPressed -= ReceiveTouchInput;

            EventManager.OnTouchInputEnded -= TouchInputRemoved;
        }

        private void Start()
        {
            _showText.SetText(letterInCard.ToString());
        }

        #endregion

        #region Main

        /// <summary>
        /// Called when the card get touched by player. Send letter information to letter collector and activated line.
        /// </summary>
        private void ReceiveTouchInput(GameObject card)
        {
            if (!_hasTouched && card == gameObject)
            {
                _hasTouched = true;
                
                EventManager.BroadcastOnSendLetterInformation(letterInCard);
                
                EventManager.BroadcastOnActivatedLine(gameObject.transform.position);
            }
        }

        /// <summary>
        /// Called when player removed the touch input from screen. Reset the card condition.
        /// </summary>
        private void TouchInputRemoved()
        {
            _hasTouched = false;
        }

        #endregion
    }
}