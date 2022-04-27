using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using UnityEngine;
using UnityEditor;

namespace ConorV
{
    public class B_ActShapeEditor : EditorWindow
    {
        [MenuItem("Window/Shape Editor")]

        static void OpenWindow() {
            B_ActShapeEditor window = GetWindow<B_ActShapeEditor>();
            window.titleContent = new GUIContent("Shape Editor");
        }

        void OnGUI() {


            if (GUI.changed) {
                Repaint();
            }
        }

        void DrawGrid() {
            Grid grid = new Grid();

            
        }
    }
}
