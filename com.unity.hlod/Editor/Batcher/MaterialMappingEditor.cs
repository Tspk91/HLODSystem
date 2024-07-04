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
        public override void OnInspectorGUI()
        {
            var materialMapping = target as MaterialMapping;
            materialMapping.DrawGUI(null);
        }
    }
}