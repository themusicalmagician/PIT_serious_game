using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "DocumentData", menuName = "Custom/Document Data", order = 1)]
public class DocumentData : ScriptableObject
{
    [System.Serializable]
    public class CategoryInfo
    {
        public string categoryName;
        public float correctAmount;
        public bool isDebit;
    }

    public float totalAmount;
    public float debitAmount;
    public float creditAmount;
    public List<CategoryInfo> categories;

    [Header("References")]
    public CategoriesData categoriesData;  // Reference to CategoriesData

    // Initialize categories based on data from CategoriesData
    public void InitializeCategories()
    {
        if (categoriesData != null)
        {
            categories = new List<CategoryInfo>();

            foreach (CategoriesData.Category categoryData in categoriesData.categories)
            {
                CategoryInfo newCategory = new CategoryInfo
                {
                    categoryName = categoryData.categoryName,
                    correctAmount = 0f,  // You may set a default value here
                    isDebit = true       // You may set a default value here
                };

                categories.Add(newCategory);
            }
        }
        else
        {
            Debug.LogError("CategoriesData reference is not set in DocumentData.");
        }
    }
}
