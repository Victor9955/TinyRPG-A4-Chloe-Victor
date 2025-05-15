#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using System;
using System.Linq;
using System.Reflection;
using NUnit.Framework;
using System.Collections.Generic;

[CustomEditor(typeof(ItemSO))]
public class ItemSOEditor : Editor
{
    private List<Type> itemSubclasses;
    private List<string> typeNames;
    private int selectedIndex;
    private SerializedProperty itemDefinitionProp;

    private void OnEnable()
    {
        itemDefinitionProp = serializedObject.FindProperty("itemDefinition");
        itemSubclasses = GetItemSubclasses();
        typeNames = itemSubclasses.Select(t => t.Name).ToList();
        ItemSO itemSO = (ItemSO)target;
        selectedIndex = itemSubclasses.IndexOf(itemSO.itemDefinition?.GetType());
    }

    public override void OnInspectorGUI()
    {
        ItemSO itemSO = (ItemSO)target;
        serializedObject.Update();

        DrawPropertiesExcluding(serializedObject, "itemDefinition");
        EditorGUI.BeginChangeCheck();
        selectedIndex = EditorGUILayout.Popup("Item Type", selectedIndex, typeNames.ToArray());

        if (EditorGUI.EndChangeCheck())
        {
            Undo.RecordObject(itemSO, "Change Item Type");
            itemSO.itemDefinition = (Item)Activator.CreateInstance(itemSubclasses[selectedIndex]);
            EditorUtility.SetDirty(itemSO);
        }

        if (itemSO.itemDefinition != null)
        {
            var definition = serializedObject.FindProperty("itemDefinition");
            EditorGUILayout.PropertyField(definition, true);
        }

        serializedObject.ApplyModifiedProperties();
    }

    private List<Type> GetItemSubclasses()
    {
        return AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(assembly => assembly.GetTypes())
            .Where(t => t.IsClass &&
                       t.IsSubclassOf(typeof(Item)))
            .ToList();
    }
}
#endif