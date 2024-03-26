using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

[ExecuteInEditMode]
public class DocumentDataHolder : MonoBehaviour
{
    public DocumentData documentData;
    public Image documentImage; // Reference to the Image component on the prefab

#if UNITY_EDITOR
    SerializedObject serializedDocumentData;

    private void OnEnable()
    {
        serializedDocumentData = new SerializedObject(documentData);
    }

    public void UpdateDocumentData()
    {
        if (documentData != null)
        {
            Debug.Log($"DocumentData: {documentData.name}");
            // ... other code ...
        }
        else
        {
            Debug.LogWarning("DocumentData is null. Make sure it's properly assigned.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //UpdateDocumentData();
    }

#endif
}
