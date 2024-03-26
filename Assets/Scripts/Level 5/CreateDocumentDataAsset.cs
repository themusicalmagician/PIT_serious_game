using UnityEditor;
using UnityEngine;

public class CreateDocumentDataAsset
{
    [MenuItem("Assets/Create/Document Data")]
    public static void CreateAsset()
    {
        DocumentData documentData = ScriptableObject.CreateInstance<DocumentData>();
        documentData.InitializeCategories();  // Call this method to load categories
        AssetDatabase.CreateAsset(documentData, "Assets/NewDocumentData.asset");
        AssetDatabase.SaveAssets();
        EditorUtility.FocusProjectWindow();
        Selection.activeObject = documentData;
    }
}
