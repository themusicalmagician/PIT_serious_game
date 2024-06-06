using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(DocumentDataHolder))]
public class DocumentDataHolderEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        DocumentDataHolder dataHolder = (DocumentDataHolder)target;

        GUILayout.Space(10);

        if (GUILayout.Button("Update DocumentData"))
        {
            dataHolder.UpdateDocumentData();
        }

        GUILayout.Space(10);

        if (dataHolder.documentData != null)
        {
            GUILayout.Label($"DocumentData Name: {dataHolder.documentData.name}");
        }
        else
        {
            GUILayout.Label("DocumentData is null.");
        }
    }
}
[CustomEditor(typeof(DocumentData))]
public class DocumentDataEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        DocumentData documentData = (DocumentData)target;

        if (GUILayout.Button("Initialize Categories"))
        {
            documentData.InitializeCategories();
        }
    }
}
