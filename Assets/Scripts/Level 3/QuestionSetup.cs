using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionSetup : MonoBehaviour
{
    [SerializeField] private List<QuestionData> questions;
    [SerializeField] private List<ScriptableObject> scriptableObjects;
    private QuestionData currentQuestion;

    [SerializeField] private Text questionText;
    [SerializeField] private Text catergoryText;
    [SerializeField] private AnswerButton[] answerButtons;

    [SerializeField] private int correctAnswerChoice;


    // Start is called before the first frame update
    void Awake()
    {
        StartCoroutine(waitForAnswers());
        
    }

    IEnumerator waitForAnswers()
    {
        yield return new WaitForSeconds(1);
        GetQuestionAssets();

        SelectNewQuestion();

        SetQuestionValues();

        SetAnswerValues();
    }

    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void GetQuestionAssets()
    {
        questions = new List<QuestionData>(Resources.LoadAll<QuestionData>("Questions"));
    }

    private void SelectNewQuestion()
    {
        int randomQuestionIndex = Random.Range(0, questions.Count);
        currentQuestion = questions[randomQuestionIndex];
        questions.RemoveAt(randomQuestionIndex);
    }

    private void SetQuestionValues()
    {
        questionText.text = currentQuestion.question;
        catergoryText.text = currentQuestion.category;
    }

    private void SetAnswerValues()
    {
        List<string> answers = RandomizeAnswers(new List<string>(currentQuestion.answers));

        for (int i = 0; i < answerButtons.Length; i++)
        {
            bool isCorrect = false;

            if (i == correctAnswerChoice)
            {
                isCorrect = true;
            }

            answerButtons[i].SetIsCorrect(isCorrect);
            answerButtons[i].SetAnswerSprite(answers[i]);
        }
    }

    private List<string> RandomizeAnswers(List<string> originalList)
    {
        bool correctAnswerChosen = false;

        List<string> newList = new List<string>();

        for (int i = 0; i < answerButtons.Length; i++)
        {
            int random = Random.Range(0, originalList.Count);

            if (random == 0 && !correctAnswerChosen)
            {
                correctAnswerChoice = i;
                correctAnswerChosen = true;
            }

            newList.Add(originalList[random]);
            originalList.RemoveAt(random);
        }


        return newList;
    }
}