using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementManager : MonoBehaviour
{
    [SerializeField] private GameObject achievementPrefab;

    private AchievementButton activeButton;
    public ScrollRect scrollRect;

    public GameObject achievementMenu;
    public GameObject visualAchievement;

    public static bool gameIsPaused = false;

    public Dictionary<string, Achievement> achievements = new Dictionary<string, Achievement>();

    // Start is called before the first frame update
    void Start()
    {   
        activeButton = GameObject.Find("GeneralBtn").GetComponent<AchievementButton>();
        CreateAchievement("General", "Prestatie ontgrendeld", "Duw op W", "Je hebt op W geduwt :D");

        foreach(GameObject achievmentList in GameObject.FindGameObjectsWithTag("AchievementList"))
        {
            achievmentList.SetActive(false);
        }

        activeButton.Click(); 

        achievementMenu.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (gameIsPaused)
            {
                Resume();

            }
            else
            {
                Pause();
            }
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            EarnAchievement("Duw op W");
        }
    }

    public void Resume()
    {
        achievementMenu.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    private void Pause()
    {
        achievementMenu.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void EarnAchievement(string title)
    {
        if (achievements[title].EarnAchievement())
        {
            //DO SOMETHING AWESOME!
            GameObject achievement = (GameObject)Instantiate(visualAchievement);
            SetAchievementInfo("EarnCanvas", achievement, title);
            StartCoroutine(HideAchievement(achievement));
        }
    }

    public IEnumerator HideAchievement(GameObject achievement)
    {
        yield return new WaitForSeconds(3);
        Destroy(achievement);
    }

    public void CreateAchievement(string parent, string unlocked, string title, string description)
    {
        GameObject achievement = (GameObject)Instantiate(achievementPrefab);

        Achievement newAchievement = new Achievement(name, description, achievement);

        achievements.Add(title, newAchievement);

        SetAchievementInfo(parent, achievement, title);
    }

    public void SetAchievementInfo(string parent, GameObject achievement, string title)
    {
        achievement.transform.SetParent(GameObject.Find(parent).transform);
        achievement.transform.localScale = new Vector3(1, 1, 1);

        achievement.transform.GetChild(1).GetComponent<Text>().text = title;
        achievement.transform.GetChild(2).GetComponent<Text>().text = achievements[title].Description;
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
