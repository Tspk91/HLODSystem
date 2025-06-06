using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace Unity.HLODSystem
{
    [CustomEditor(typeof(MaterialMapping))]
    public class MaterialMappingEditor : Editor
    {
        bool textureSlotFoldout = false;

        public override void OnInspectorGUI()
        {
            var materialMapping = target as MaterialMapping;
            materialMapping.DrawGUI(null, ref textureSlotFoldout);
        }
    }
}