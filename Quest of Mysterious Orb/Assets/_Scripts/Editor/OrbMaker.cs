using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class OrbMaker : EditorWindow
{   
    GameObject prevObject;
    GameObject gameObject;
    string gameObjectName = "OrbData";
    Editor gameObjectEditor;
    OrbData gameData;
    OrbType orbType;

    float value;

    OrbType prevType = OrbType.BOUNCE;   

    [MenuItem("Window/OrbMaker")]
    static void Init()
    {
        OrbMaker window = (OrbMaker)EditorWindow.GetWindow(typeof(OrbMaker));
        window.Show();
    }

    void OnGUI()
    {
        gameObjectName = (string) EditorGUILayout.TextField(gameObjectName);
        gameObject = (GameObject) EditorGUILayout.ObjectField(gameObject, typeof(GameObject), true);

        GUIStyle bgColor = new GUIStyle();
        bgColor.normal.background = EditorGUIUtility.whiteTexture;

        if (gameObject != null)
        {
            Debug.Log(gameObject.name);
            if(gameObject != prevObject) {
                gameObjectEditor = null;
            }
            if (gameObjectEditor == null) {
                gameObjectEditor = Editor.CreateEditor(gameObject);
                prevObject = gameObject;
            }

            gameObjectEditor.OnInteractivePreviewGUI(GUILayoutUtility.GetRect(256, 256), bgColor);
        }
        
        orbType = (OrbType)EditorGUILayout.EnumPopup("Orb Type: ", prevType);

        if(orbType != prevType) {
            if (GUILayout.Button("Create Data"))
                ParseOrb(orbType);
            gameData = (OrbData) EditorGUILayout.ObjectField(null, typeof(OrbData), true);
            prevType = orbType;
        }
        else {
            if(gameData != null) {
                gameData = (OrbData) EditorGUILayout.ObjectField(gameData, typeof(OrbData), true);
                List<dynamic> dataTab = gameData.GetData();
                for(int i = 0; i < dataTab.Count / 2; i += 2) {
                    EditorGUILayout.Space();
                    EditorGUILayout.LabelField(Convert.ToString(dataTab[i]));
                    value = (float) EditorGUILayout.Slider(value, 0f, 5f);
                    dataTab[i + 1] = value;
                }
                gameData.SetData(dataTab);
            }

            if (GUILayout.Button("Save To Prefab"))
                ParseOrb(orbType);
        }

        

        
    }

    private void ParseOrb(OrbType orbType) {
        switch(orbType) {
            case OrbType.BOUNCE:
                gameData = InstantiateOrb<BounceOrbData>(gameObjectName);
                break;
            case OrbType.CHARGING:
                gameData = InstantiateOrb<ChargingOrbData>(gameObjectName);
                break;
            case OrbType.GRAY:
                gameData = InstantiateOrb<GrayOrbData>(gameObjectName);
                break;
            case OrbType.HOMING:
                gameData = InstantiateOrb<HomingOrbData>(gameObjectName);
                break;
        }
    }

    private T InstantiateOrb<T>(string gameObjectName) 
    where T : Data
    {
        T asset = ScriptableObject.CreateInstance<T>();

        AssetDatabase.CreateAsset(asset, "Assets/_ScriptableObjects/OrbsData/" + gameObjectName + ".asset");
        AssetDatabase.SaveAssets();

        return asset;
    }
}


