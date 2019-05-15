using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class OrbMaker : EditorWindow
{   
    GameObject prevObject;
    GameObject gameObjectToInstant;
    string gameObjectName = "Orb";
    string scriptableObjectName = "OrbData";
    Editor gameObjectEditor;
    OrbData gameData;
    OrbType orbType;
    float value;
    GameObject particleSystem;
    OrbType prevType = OrbType.BounceOrb;   



    [MenuItem("Window/OrbMaker")]
    static void Init()
    {
        OrbMaker window = (OrbMaker)EditorWindow.GetWindow(typeof(OrbMaker));
        window.Show();
    }

    private void OnGUI()
   {
      DrawName();
      DrawGUIObjectPreview();

      orbType = (OrbType)EditorGUILayout.EnumPopup("Orb Type: ", prevType);

      if (orbType != prevType)
      {
         EditorGUILayout.Space();
         EditorGUILayout.LabelField("Orb Data:");
         gameData = (OrbData)EditorGUILayout.ObjectField(null, typeof(OrbData), true);
         prevType = orbType;
      }
      else
      {
         if (gameData != null)
         {
            EditorGUILayout.Space();
            GUILayout.BeginVertical(EditorStyles.helpBox);
            EditorGUILayout.LabelField("Orb Data:");
            gameData = (OrbData)EditorGUILayout.ObjectField(gameData, typeof(OrbData), true);
            List<dynamic> dataTab = gameData.GetData();
            for (int i = 0; i < dataTab.Count / 2; i += 2)
            {
               EditorGUILayout.Space();
               EditorGUILayout.LabelField(Convert.ToString(dataTab[i]));
               value = (float)EditorGUILayout.Slider(value, 0f, 5f);
               dataTab[i + 1] = value;
            }
            particleSystem = (GameObject)EditorGUILayout.ObjectField(particleSystem, typeof(GameObject), true);
            if (particleSystem != null)
            {
               if (particleSystem.GetComponent<ParticleSystem>() == null)
               {
                  particleSystem = null;
                  EditorUtility.DisplayDialog("ALERT", "THERE IS NO PARTICLE SYSTEM COMPONENT ON OBJECT!", "OK");
               }
               else
               {
                  gameData.ParticleSystem = particleSystem.GetComponent<ParticleSystem>();
               }
            }

            GUILayout.EndVertical();
            gameData.SetData(dataTab);
         }
      }

      if (gameData == null)
      {
         GUILayout.FlexibleSpace();
         if (GUILayout.Button("Create Data"))
            ParseOrb(orbType);
      }
      else
      {
         GUILayout.FlexibleSpace();
         if (GUILayout.Button("Export to Prefab"))
         {
            switch (orbType)
            {
               case OrbType.BounceOrb:
                  CreatePrefab<BounceOrb, BounceOrbData>();
                  break;
               case OrbType.ChargingOrb:
                  CreatePrefab<ChargingOrb, ChargingOrbData>();
                  break;
               case OrbType.GrayOrb:
                  CreatePrefab<GrayOrb, GrayOrbData>();
                  break;
               case OrbType.HomingOrb:
                  CreatePrefab<HomingOrb, HomingOrbData>();
                  break;
            }

         }
      }
   }

   private void DrawGUIObjectPreview()
   {
      GUILayout.BeginHorizontal(EditorStyles.helpBox);
      GUIStyle bgColor = new GUIStyle();
      bgColor.normal.background = EditorGUIUtility.whiteTexture;

      if (gameObjectToInstant != null)
      {
         if (gameObjectToInstant != prevObject)
         {
            gameObjectEditor = null;
         }
         if (gameObjectEditor == null)
         {
            gameObjectEditor = Editor.CreateEditor(gameObjectToInstant);
            prevObject = gameObjectToInstant;
         }

         gameObjectEditor.OnInteractivePreviewGUI(GUILayoutUtility.GetRect(128, 256), bgColor);
      }

      GUILayout.EndHorizontal();
   }

   private void DrawName()
   {
      GUILayout.BeginVertical(EditorStyles.helpBox);
      gameObjectName = (string)EditorGUILayout.TextField(gameObjectName);
      gameObjectToInstant = (GameObject)EditorGUILayout.ObjectField(gameObjectToInstant, typeof(GameObject), true);
      GUILayout.EndVertical();
   }

   private void ParseOrb(OrbType orbType) {
        switch(orbType) {
            case OrbType.BounceOrb:
                gameData = InstantiateOrb<BounceOrbData>(gameObjectName);
                break;
            case OrbType.ChargingOrb:
                gameData = InstantiateOrb<ChargingOrbData>(gameObjectName);
                break;
            case OrbType.GrayOrb:
                gameData = InstantiateOrb<GrayOrbData>(gameObjectName);
                break;
            case OrbType.HomingOrb:
                gameData = InstantiateOrb<HomingOrbData>(gameObjectName);
                break;
        }
    }

    private void CreatePrefab<T,W>() 
        where W : OrbData  
        where T : OrbGameObject<W>
    {
        if(gameObjectToInstant != null && particleSystem != null) {
            Debug.Log(gameObjectToInstant);
            GameObject prefabToInstantiate = gameObjectToInstant;
            prefabToInstantiate.AddComponent<T>();
            prefabToInstantiate.GetComponent<T>().OrbData = (gameData as W);
            particleSystem.gameObject.transform.position = Vector3.zero;
            particleSystem.gameObject.transform.SetParent(prefabToInstantiate.transform);

            PrefabUtility.SaveAsPrefabAsset(prefabToInstantiate, "Assets/Prefabs/Orbs/" + gameObjectName + ".prefab");
            gameObjectToInstant = null;
        }
        else {
            EditorUtility.DisplayDialog("ALERT","SOMETHING IS NULL!", "OK" );
        }
    }

    private T InstantiateOrb<T>(string gameObjectName) 
        where T : Data
    {
        T asset = ScriptableObject.CreateInstance<T>();

        AssetDatabase.CreateAsset(asset, "Assets/_ScriptableObjects/OrbsData/" + scriptableObjectName + ".asset");
        AssetDatabase.SaveAssets();

        return asset;
    }
}


