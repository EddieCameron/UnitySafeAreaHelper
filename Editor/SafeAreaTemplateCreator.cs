/* SafeAreaTemplateCreator.cs
 * © Eddie Cameron 2019
 * ----------------------------
 */
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using Random = UnityEngine.Random;

namespace SafeAreaHelper {
    [InitializeOnLoad]
    public static class SafeAreaTemplateCreator {
        private const string _SAFE_AREA_PREFAB_NAME_PORTRAIT = "SafeAreaTemplateCanvasPortrait";
        private const string _SAFE_AREA_PREFAB_NAME_LANDSCAPE = "SafeAreaTemplateCanvasLandscape";
        private static GameObject _templateInstance;
        private static bool _templateIsLandscape;

        static SafeAreaTemplateCreator() {
            EditorApplication.update += CheckTemplate;
        }

        static void CheckTemplate() {
            if ( Helper.IsEditorSafeAreaEmulationOn ) { 
                bool isLandscape = Helper.IsLandscape;
                if ( _templateInstance == null || isLandscape != _templateIsLandscape ) {

                    if ( _templateInstance != null )
                        GameObject.DestroyImmediate( _templateInstance );

                    var safeAreaTemplatePrefab = Resources.Load( isLandscape ? _SAFE_AREA_PREFAB_NAME_LANDSCAPE : _SAFE_AREA_PREFAB_NAME_PORTRAIT );
                    _templateInstance = (GameObject)GameObject.Instantiate( safeAreaTemplatePrefab );
                    _templateIsLandscape = isLandscape;
                    _templateInstance.hideFlags = HideFlags.HideAndDontSave;
                    if ( EditorApplication.isPlayingOrWillChangePlaymode )
                        GameObject.DontDestroyOnLoad( _templateInstance );
                }
            }
            else {
                if ( _templateInstance != null ) {
                    GameObject.DestroyImmediate( _templateInstance );
                    _templateInstance = null;
                }
            }

        }
    }
}
