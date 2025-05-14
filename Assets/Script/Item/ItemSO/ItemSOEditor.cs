#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using System;
using System.Linq;
using System.Reflection;

[CustomEditor(typeof(ItemSO))]
public class ItemSOEditor : Editor
{
    private Type[] itemSubclasses;
    private string[] typeNames;
    private int selectedIndex;
    private SerializedProperty itemDefinitionProp;

    private void OnEnable()
    {
        itemDefinitionProp = serializedObject.FindProperty("itemDefinition");
        itemSubclasses = GetItemSubclasses();
        typeNames = itemSubclasses.Select(t => t.Name).ToArray();
        ItemSO itemSO = (ItemSO)target;
        selectedIndex = Array.FindIndex(itemSubclasses, t => t == itemSO.itemDefinition?.GetType());
    }

    public override void OnInspectorGUI()
    {
        ItemSO itemSO = (ItemSO)target;
        serializedObject.Update();

        // Dessiner les propriétés standard
        DrawPropertiesExcluding(serializedObject, "itemDefinition");

        // Sélecteur de type
        EditorGUI.BeginChangeCheck();
        selectedIndex = EditorGUILayout.Popup("Item Type", selectedIndex, typeNames);

        if (EditorGUI.EndChangeCheck())
        {
            Undo.RecordObject(itemSO, "Change Item Type");
            itemSO.itemDefinition = (Item)Activator.CreateInstance(itemSubclasses[selectedIndex]);
            EditorUtility.SetDirty(itemSO);
        }

        // Dessiner les propriétés spécifiques
        if (itemSO.itemDefinition != null)
        {
            var definition = serializedObject.FindProperty("itemDefinition");
            EditorGUILayout.PropertyField(definition, true);
        }

        serializedObject.ApplyModifiedProperties();
    }

    private Type[] GetItemSubclasses()
    {
        return AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(assembly => assembly.GetTypes())
            .Where(t => t.IsClass &&
                       !t.IsAbstract &&
                       t.IsSubclassOf(typeof(Item)))
            .OrderBy(t => t.Name)
            .ToArray();
    }
}
#endif