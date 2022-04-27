using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.Tilemaps;
using UnityEditor.SceneManagement;

namespace ConorV
{
    public class B_ActShapeGenerator : EditorWindow
    {
        static string previousScene = "Assets/_Project/Scenes/PrototypeScene.unity";
        static string protypeScenePath = "Assets/_Project/Scenes/PrototypeScene.unity";
        string shapePath = "Assets/Resources/Shapes/Shape.asset";
        static string ShapeScenePath = "Assets/Editor/ShapeEditor/ShapeScene.unity";

        Vector2Int Target;
        static Object TargetMap, ShapeMap;

        static Tile targeterTile;

        void Awake() {
            Init();
        }

        [MenuItem("Sademon/Shape Generator")]
        public static void OpenWindow() {
            B_ActShapeGenerator window = GetWindow<B_ActShapeGenerator>();
            window.titleContent = new GUIContent("Shape Generator");
            window.minSize = new Vector2(300, 200);
            SwitchToScene(ShapeScenePath);
            Init();
        }

        void OnGUI() {

            EditorGUILayout.BeginHorizontal("Box");
            if (GUILayout.Button("Open Shape Editor")) {
                SwitchToScene(ShapeScenePath);
                Init();
            }
            if (GUILayout.Button("Return To Previous")) {
                if(CurrentScene(ShapeScenePath))
                    SwitchToScene(previousScene);
            }
            EditorGUILayout.EndHorizontal();
            if(CurrentScene(ShapeScenePath))
                ShapeGeneratorGUI();
        }

        void ShapeGeneratorGUI() {
            EditorGUILayout.Space();

            EditorGUILayout.LabelField("Shape Generator", EditorStyles.boldLabel);
            EditorGUILayout.Space();

            EditorGUILayout.BeginHorizontal("Box");
            EditorGUILayout.LabelField("Target", EditorStyles.boldLabel, GUILayout.MaxWidth(100));
            EditorGUI.BeginDisabledGroup(true);
            EditorGUILayout.Vector2IntField("", GetTarget(), GUILayout.MaxWidth(175), GUILayout.MinWidth(175));
            EditorGUI.EndDisabledGroup();
            EditorGUILayout.EndHorizontal();
            /*
             * 
                        EditorGUILayout.BeginVertical();
                        TargetMap = EditorGUILayout.ObjectField("Target Map", TargetMap, typeof(Tilemap), true);
                        ShapeMap = EditorGUILayout.ObjectField("Shape Map", ShapeMap, typeof(Tilemap), true);
                        EditorGUILayout.EndVertical();*/

            if (GUILayout.Button("Generate Shape")) {
                GenerateShape();
            }

        }

        private static void Init() {
            targeterTile = (Tile)AssetDatabase.LoadMainAssetAtPath("Assets/Editor/ShapeEditor/TargetTile.asset");

            if (previousScene == "")
                previousScene = protypeScenePath;

            var tilemaps = FindObjectsOfType<Tilemap>();
            foreach (Tilemap tilemap in tilemaps) {
                if (tilemap.name == "Target")
                    TargetMap = tilemap;
                else if (tilemap.name == "Shape")
                    ShapeMap = tilemap;
            }
        }

        bool IsTargetValid() {
            return true;
        }

        void GenerateShape() {

        }



        void Reset() {
            
        }

        Vector2Int GetTarget() {
            var tMap = TargetMap as Tilemap;
            var targetCells = TilemapTools.V3IntInMap(tMap);
            if (targetCells.Count != 1) throw new System.Exception($"Exactly 1 target must be set. Instead, {targetCells.Count} tiles were found.");
            if (tMap.GetTile(targetCells[0]) != targeterTile) throw new System.Exception($"Tile in target map must be {targeterTile.name}.");
            return (Vector2Int)targetCells[0];
        }

        #region Scene Buttons
        static bool CurrentScene(string scenePath) {
            var currentScene = EditorSceneManager.GetActiveScene().path;
            return currentScene.Equals(scenePath);
        }

        static void SwitchToScene(string scenePath) {
            if (!CurrentScene(scenePath)) OpenScene(scenePath);
        }

        static void OpenScene(string scenePath) {
            CloseCurrentScene();
            EditorSceneManager.OpenScene(scenePath);
        }

        static void CloseCurrentScene() {
            EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
            previousScene = EditorSceneManager.GetActiveScene().path;
        }
        #endregion
    }
}
