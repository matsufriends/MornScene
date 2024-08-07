using System;
using UnityEditor;
using UnityEngine;

namespace MornScene
{
    [CustomPropertyDrawer(typeof(MornSceneObject))]
    public class MornSceneObjectEditor : PropertyDrawer
    {
        private static SceneAsset GetSceneObject(string sceneName)
        {
            if (string.IsNullOrEmpty(sceneName))
            {
                return null;
            }

            foreach (var scene in EditorBuildSettings.scenes)
            {
                if (scene.path.IndexOf(sceneName, StringComparison.Ordinal) != -1)
                {
                    return AssetDatabase.LoadAssetAtPath(scene.path, typeof(SceneAsset)) as SceneAsset;
                }
            }

            return null;
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var nameProperty = property.FindPropertyRelative("_sceneName");
            var sceneObj = GetSceneObject(nameProperty.stringValue);
            var newScene = EditorGUI.ObjectField(position, label, sceneObj, typeof(SceneAsset), false);
            if (newScene == null)
            {
                nameProperty.stringValue = "";
            }
            else
            {
                if (newScene.name != nameProperty.stringValue)
                {
                    var scnObj = GetSceneObject(newScene.name);
                    if (scnObj == null)
                    {
                        MornSceneUtil.LogError($"{newScene.name}が'Scenes in the Build'に含まれていません");
                    }
                    else
                    {
                        nameProperty.stringValue = newScene.name;
                    }
                }
            }
        }
    }
}