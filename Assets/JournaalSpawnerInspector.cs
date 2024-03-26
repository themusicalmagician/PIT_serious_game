using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(JournaalSpawner))]
public class JournaalSpawnerInspector : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        JournaalSpawner spawner = (JournaalSpawner)target;

        // Display loaded document information
        if (spawner.currentDocument != null)
        {
            DocumentDataHolder dataHolder = spawner.currentDocument.GetComponent<DocumentDataHolder>();

            if (dataHolder != null)
            {
                EditorGUILayout.Space();
                EditorGUILayout.LabelField("Loaded Document Information", EditorStyles.boldLabel);

                EditorGUILayout.LabelField("Document Name: ", dataHolder.documentData.name);

                EditorGUILayout.Space();
                EditorGUILayout.LabelField("Categories:");

                // Display categories, their correct amounts, and whether they are debit or credit
                foreach (var category in dataHolder.documentData.categories)
                {
                    string debitCredit = category.isDebit ? " (Debit)" : " (Credit)";
                    EditorGUILayout.LabelField($"- {category.categoryName}: {category.correctAmount}{debitCredit}");
                }
            }
        }
    }
}
