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

    public Sprite unlockedSprite;

    public Text textPoints;

    private static AchievementManager instance;

    private int fadeTime = 2;

    public static AchievementManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<AchievementManager>();
            }

            return AchievementManager.instance;
        }


    }

    // Start is called before the first frame update
    void Start()
    {
        //REMEMBER TO REMOVE
        PlayerPrefs.DeleteAll();

        activeButton = GameObject.Find("GeneralBtn").GetComponent<AchievementButton>();
        CreateAchievement("General", "Prestatie ontgrendeld", "Duw op W", "Je hebt op W geduwt :D", 5);
        CreateAchievement("General", "Prestatie ontgrendeld", "Duw op S", "Je hebt op S geduwt :D", 5);
        CreateAchievement("General", "Prestatie ontgrendeld", "Duw op alle knoppen", "Duw op alle knoppen om dit te ontgrendelen", 10, new string[] { "Duw op W", "Duw op S" });

        foreach (GameObject achievmentList in GameObject.FindGameObjectsWithTag("AchievementList"))
        {
            achievmentList.SetActive(false);
        }

        activeButton.Click();

        achievementMenu.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backslash))
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

        if (Input.GetKeyDown(KeyCode.S))
        {
            EarnAchievement("Duw op S");
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
            textPoints.text = "Punten: " + PlayerPrefs.GetInt("Points");
            StartCoroutine(FadeAchievement(achievement));
        }
    }

    public IEnumerator HideAchievement(GameObject achievement)
    {
        yield return new WaitForSeconds(3);
        Destroy(achievement);
    }

    public void CreateAchievement(string parent, string unlocked, string title, string description, int points, string[] dependencies = null)
    {
        GameObject achievement = (GameObject)Instantiate(achievementPrefab);

        Achievement newAchievement = new Achievement(name, description, points, achievement);

        achievements.Add(title, newAchievement);

        SetAchievementInfo(parent, achievement, title);

        if (dependencies != null)
        {
            foreach (string achievementTitle in dependencies)
            {
                Achievement dependency = achievements[achievementTitle];
                dependency.Child = title;
                newAchievement.AddDependency(dependency);
            }
        }
    }

    public void SetAchievementInfo(string parent, GameObject achievement, string title)
    {
        achievement.transform.SetParent(GameObject.Find(parent).transform);
        achievement.transform.localScale = new Vector3(1, 1, 1);

        achievement.transform.GetChild(1).GetComponent<Text>().text = title;
        achievement.transform.GetChild(2).GetComponent<Text>().text = achievements[title].Description;
        achievement.transform.GetChild(3).GetComponent<Text>().text = achievements[title].Points.ToString();
    }

    public void ChangeCategorty(GameObject button)
    {
        AchievementButton achievementButton = button.GetComponent<AchievementButton>();

        scrollRect.content = achievementButton.achievementList.GetComponent<RectTransform>();

        achievementButton.Click();
        activeButton.Click();
        activeButton = achievementButton;

    }

    private IEnumerator FadeAchievement(GameObject achievement)
    {
        CanvasGroup canvasGroup = achievement.GetComponent<CanvasGroup>();

        float rate = 1.0f / fadeTime;

        int startAlpha = 0;
        int endAlpha = 1;

        for (int i = 0; i < 2; i++)
        {
            float progress = 0.0f;

            while (progress < 1.0f)
            {
                canvasGroup.alpha = Mathf.Lerp(startAlpha, endAlpha, progress);

                progress += rate * Time.deltaTime;

                yield return null;
            }
            yield return new WaitForSeconds(4);
            startAlpha = 1;
            endAlpha = 0;
        }

        Destroy(achievement);
    }
}
