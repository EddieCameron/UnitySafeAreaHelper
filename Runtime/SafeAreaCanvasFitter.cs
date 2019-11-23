/* SafeAreaCanvasFitter.cs
 * © Eddie Cameron 2019
 * ----------------------------
 */
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace SafeAreaHelper
{
    /// <summary>
    /// Resizes the attached RectTransform to fill it's parent but adjusted to avoid safe areas
    /// E.G: Put on a child of a screen/overlay canvas to have it fill the safe area of the screen
    /// </summary>
    [RequireComponent( typeof( RectTransform ) )]
    [ExecuteInEditMode]
    public class SafeAreaCanvasFitter : MonoBehaviour {
        private Rect _lastAdjustedSafeArea;

        private RectTransform _rectTransform;
        public RectTransform RectT {
            get {
                if ( _rectTransform == null )
                    _rectTransform = GetComponent<RectTransform>();
                return _rectTransform;
            }
        }

        void OnEnable() {
            _lastAdjustedSafeArea = Helper.GetSafeArea();
            AdjustCanvasToArea( _lastAdjustedSafeArea );
        }

        void Update() {
            Rect newSafeArea = Helper.GetSafeArea();
            if ( newSafeArea != _lastAdjustedSafeArea ) {
                _lastAdjustedSafeArea = newSafeArea;
                AdjustCanvasToArea( _lastAdjustedSafeArea );
            }
        }

        private void AdjustCanvasToArea( Rect safeArea ) {
            Debug.Log( "Adjusting Canvas to fit in safe area: " + safeArea );
            // normalize area to viewspace
            Vector2 newAnchorMin = safeArea.min;
            newAnchorMin.x /= Screen.width;
            newAnchorMin.y /= Screen.height;
            Vector2 newAnchorMax = safeArea.max;
            newAnchorMax.x /= Screen.width;
            newAnchorMax.y /= Screen.height;

            RectT.anchorMin = newAnchorMin;
            RectT.anchorMax = newAnchorMax;
        }
    }
}