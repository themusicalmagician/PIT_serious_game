using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementManager : MonoBehaviour
{
    [SerializeField] private GameObject achievementPrefab;

    private AchievementButton activeButton;
    public ScrollRect scrollRect; 


    // Start is called before the first frame update
    void Start()
    {
        activeButton = GameObject.Find("GeneralBtn").GetComponent<AchievementButton>();
        CreateAchievement("General", "Prestatie ontgrendeld", "Test titel", "Dit is de beschrijving");

        foreach(GameObject achievmentList in GameObject.FindGameObjectsWithTag("AchievementList"))
        {
            achievmentList.SetActive(false);
        }

        activeButton.Click(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateAchievement(string category, string unlocked, string title, string description)
    {
        GameObject achievement = (GameObject)Instantiate(achievementPrefab);
        SetAchievementInfo(category, achievement, unlocked, title, description);
    }

    public void SetAchievementInfo(string category, GameObject achievement, string unlocked, string title, string description)
    {
        achievement.transform.SetParent(GameObject.Find(category).transform);
        achievement.transform.localScale = new Vector3(1, 1, 1);

        achievement.transform.GetChild(0).GetComponent<Text>().text = unlocked;
        achievement.transform.GetChild(1).GetComponent<Text>().text = title;
        achievement.transform.GetChild(2).GetComponent<Text>().text = description;
    }

    public void ChangeCategorty(GameObject button)
    {
        AchievementButton achievementButton = button.GetComponent<AchievementButton>();

        scrollRect.content = achievementButton.achievementList.GetComponent<RectTransform>();

        achievementButton.Click();
        activeButton.Click();
        activeButton = achievementButton;

    }
}
