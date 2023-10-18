using CrossWord.Scripts.Manager;
using UnityEngine;

namespace CrossWord.Scripts
{
    /// <summary>
    /// SHow the line that connected each card when player touch the screen.
    /// </summary>
    public class LineConnector : MonoBehaviour
    {
        #region Variable

        /// <summary>
        /// Component that used to modify the line.
        /// </summary>
        private LineRenderer _lineRenderer = null;

        #endregion

        #region Mono

        private void Awake()
        {
            _lineRenderer = GetComponent<LineRenderer>();

            EventManager.OnActivatedLine += ActivateLine;
        }

        private void OnDestroy()
        {
            EventManager.OnActivatedLine -= ActivateLine;
        }

        private void OnEnable()
        {
            EventManager.OnLineUpdatePosition += UpdateLinePosition;

            EventManager.OnTouchInputEnded += TouchInputRemoved;
        }

        private void OnDisable()
        {
            EventManager.OnLineUpdatePosition -= UpdateLinePosition;
            
            EventManager.OnTouchInputEnded -= TouchInputRemoved;

            _lineRenderer.positionCount = 1;
        }

        private void Start()
        {
            gameObject.SetActive(false);
        }

        #endregion

        #region Main

        /// <summary>
        /// Called when card touched by player. Activate the line and set point position.
        /// </summary>
        /// <param name="cardPos">
        /// The transform of the card that get touched by player.
        /// </param>
        private void ActivateLine(Vector3 cardPos)
        {
            var positionCount = _lineRenderer.positionCount;
            positionCount += 1;
            _lineRenderer.positionCount = positionCount;
            
            _lineRenderer.SetPosition(positionCount - 2, cardPos);
            
            gameObject.SetActive(true);
        }

        /// <summary>
        /// Update the line position to match the input touch position.
        /// </summary>
        /// <param name="pos">
        /// Position the input touch.
        /// </param>
        private void UpdateLinePosition(Vector3 pos)
        {
            var pointCount = _lineRenderer.positionCount;
            
            _lineRenderer.SetPosition(pointCount - 1, pos);
        }

        /// <summary>
        /// Called when player removed the touch input from screen. Deactivate the line.
        /// </summary>
        private void TouchInputRemoved()
        {
            gameObject.SetActive(false);
        }

        #endregion
    }
}
