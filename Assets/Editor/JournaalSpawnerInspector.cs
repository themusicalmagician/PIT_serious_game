using UnityEngine;
using UnityEditor;
using System.Linq;

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

                // Filter and sort categories based on non-zero correct amounts
                var relevantCategories = dataHolder.documentData.categories
                    .Where(category => category.correctAmount != 0f)
                    .OrderByDescending(category => Mathf.Abs(category.correctAmount));

                // Display relevant categories, their correct amounts, and whether they are debit or credit
                foreach (var category in relevantCategories)
                {
                    string debitCredit = category.isDebit ? " (Debit)" : " (Credit)";
                    EditorGUILayout.LabelField($"- {category.categoryName}: {category.correctAmount}{debitCredit}");
                }
            }
        }
    }
}
