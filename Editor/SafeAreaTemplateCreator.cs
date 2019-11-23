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
        private const string _SAFE_AREA_PREFAB_NAME = "SafeAreaTemplateCanvas";
        private static GameObject _templateInstance;

        static SafeAreaTemplateCreator() {
            EditorApplication.update += CheckTemplate;
        }

        static void CheckTemplate() {
            if ( Helper.IsEditorSafeAreaEmulationOn ) {
                if ( _templateInstance == null ) {
                    var safeAreaTemplatePrefab = Resources.Load( _SAFE_AREA_PREFAB_NAME );
                    _templateInstance = (GameObject)GameObject.Instantiate( safeAreaTemplatePrefab );
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
