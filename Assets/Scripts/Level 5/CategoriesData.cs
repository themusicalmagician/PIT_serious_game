using UnityEngine;

[CreateAssetMenu(fileName = "CategoriesData", menuName = "Custom/Categories Data", order = 1)]
public class CategoriesData : ScriptableObject
{
    [System.Serializable]
    public class Category
    {
        public string categoryName;
    }

    public Category[] categories;
}
