/* SafeAreaHelper.cs
 * © Eddie Cameron 2019
 * ----------------------------
 */
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace SafeAreaHelper {
    public static class Helper {
        public static bool HasSafeArea => GetSafeArea().y > 0;

        public static Rect GetSafeArea() {
#if UNITY_EDITOR
            if ( IsEditorSafeAreaEmulationOn ) {
                // return fake safe area rect
                return new Rect( 0, 0.04187192118f * Screen.height, Screen.width, 0.9039408867f * Screen.height );
            }
#endif
            return Screen.safeArea;
        }

#if UNITY_EDITOR
        private const string _SAFE_AREA_ON_KEY = "EditorSafeAreaEmulation";

        public static bool IsEditorSafeAreaEmulationOn {
            get {
                return UnityEditor.EditorPrefs.GetBool( _SAFE_AREA_ON_KEY );
            }
            private set {
                UnityEditor.EditorPrefs.SetBool( _SAFE_AREA_ON_KEY, value );
            }
        }

        [UnityEditor.MenuItem( "Tools/Safe Area Helper/Toggle Editor Safe Area" )]
        private static void ToggleEditorSafeZoneMode() {
            IsEditorSafeAreaEmulationOn = !IsEditorSafeAreaEmulationOn;
            UnityEditor.EditorApplication.QueuePlayerLoopUpdate();
        }

        [UnityEditor.MenuItem( "Tools/Safe Area Helper/Toggle Editor Safe Area", true )]
        public static bool ToggleEditorSafeZoneModeValidate() {
            UnityEditor.Menu.SetChecked( "Tools/Safe Area Helper/Toggle Editor Safe Area", IsEditorSafeAreaEmulationOn );
            return true;
        }
#endif
    }
}