using CrossWord.Scripts.Manager;
using UnityEngine;

namespace CrossWord.Scripts.Input
{
    /// <summary>
    /// Handle the touch input when player touch the screen.
    /// </summary>
    public class TouchInput : MonoBehaviour
    {
        #region Variable

        /// <summary>
        /// The main camera component to detect the touch position.
        /// </summary>
        private Camera _mainCamera = null;

        /// <summary>
        /// Condition where the player is touching the screen or not.
        /// </summary>
        private bool _isPlayerTouching = default;

        /// <summary>
        /// The input touch when player touch the screen.
        /// </summary>
        private Touch _touch = default;

        #endregion

        #region Mono

        private void Start()
        {
            _mainCamera = Camera.main;
        }

        private void Update()
        {
            if (UnityEngine.Input.touchCount > 0)
            {
                _touch = UnityEngine.Input.GetTouch(0);

                if (_touch.phase == TouchPhase.Ended)
                {
                    EventManager.BroadcastOnTouchInputEnded();

                    return;
                }
                
                _isPlayerTouching = true;

                var cameraTouchPos = _mainCamera.ScreenToWorldPoint(_touch.position);
                cameraTouchPos.z = 0.0f;
                
                EventManager.BroadcastOnLineUpdatePosition(cameraTouchPos);
            }
            else
            {
                _isPlayerTouching = false;
            }
        }

        private void FixedUpdate()
        {
            if (_isPlayerTouching && _touch.phase != TouchPhase.Ended)
            {
                RaycastHit2D hit = Physics2D.Raycast(_mainCamera.ScreenToWorldPoint(_touch.position), Vector2.zero);

                if (hit.collider != null && hit.collider.CompareTag("InteractableCard"))
                {
                    var hitCollider = hit.collider;
                    
                    EventManager.BroadcastOnCardPressed(hitCollider.gameObject);
                }
            }
        }

        #endregion


    }
}