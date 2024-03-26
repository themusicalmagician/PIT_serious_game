using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class JournaalSpawner : MonoBehaviour
{
    public GameObject[] documentPrefabs;
    public TMP_Dropdown[] categoryDropdowns;
    public TMP_InputField[] debitAmountInputs;
    public TMP_InputField[] creditAmountInputs;
    public Button checkButton;
    public Image imageDisplay;
    public TMP_Text scoreText;
    public GameObject currentDocument;
    public int maxScore = 15;
    private int currentScore = 0;
    public bool failSafe = false;
    public GameObject wrongScreen;
    public GameObject rightAnswerScreen;
    public GameObject errorScreen;
    public GameObject enlargedImagePanel; // Reference to the panel for displaying the enlarged image
    public Image enlargedImage; // Reference to the Image component for displaying the enlarged image

    private void Start()
    {
        UpdateScoreText();
        PopulateDropdowns();
        SpawnDocument();
        checkButton.onClick.AddListener(CheckDocument);
    }

    private void PopulateDropdowns()
    {
        if (documentPrefabs.Length > 0)
        {
            DocumentDataHolder dataHolder = documentPrefabs[0].GetComponent<DocumentDataHolder>();

            if (dataHolder != null)
            {
                for (int i = 0; i < categoryDropdowns.Length; i++)
                {
                    categoryDropdowns[i].ClearOptions();
                    categoryDropdowns[i].AddOptions(dataHolder.documentData.categories.ConvertAll(c => c.categoryName));
                }
            }
        }
    }

    public void SpawnDocument()
    {
        if (currentDocument != null)
        {
            Destroy(currentDocument);
        }

        GameObject selectedPrefab = documentPrefabs[Random.Range(0, documentPrefabs.Length)];

        currentDocument = Instantiate(selectedPrefab, transform.position, Quaternion.identity);

        DocumentDataHolder dataHolder = currentDocument.GetComponent<DocumentDataHolder>();

        if (dataHolder != null)
        {
            if (imageDisplay != null && dataHolder.documentImage != null)
            {
                imageDisplay.sprite = dataHolder.documentImage.sprite;
            }
        }
    }

    public void CheckDocument()
    {
        DocumentDataHolder dataHolder = currentDocument.GetComponent<DocumentDataHolder>();

        if (dataHolder != null)
        {
            bool conditionsMet = true;
            int categoryCount = dataHolder.documentData.categories.Count;

            for (int i = 0; i < categoryCount; i++)
            {
                if (dataHolder.documentData.categories[i].correctAmount != 0f)
                {
                    float enteredAmount = 0f;

                    if (dataHolder.documentData.categories[i].isDebit)
                    {
                        if (!float.TryParse(debitAmountInputs[i].text, out enteredAmount))
                        {
                            Debug.LogError("Invalid input format for debit amount. Please enter a valid numeric value.");
                            ShowErrorScreen();
                            return;
                        }
                    }
                    else
                    {
                        if (!float.TryParse(creditAmountInputs[i].text, out enteredAmount))
                        {
                            Debug.LogError("Invalid input format for credit amount. Please enter a valid numeric value.");
                            ShowErrorScreen();
                            return;
                        }
                    }

                    if (enteredAmount != dataHolder.documentData.categories[i].correctAmount)
                    {
                        conditionsMet = false;
                        break;
                    }
                }
            }

            if (conditionsMet)
            {
                Debug.Log("GOOD JOB ;3");
                currentScore++;
                if (currentScore == maxScore)
                {
                    SceneManager.LoadScene("WinScreen");
                }
                else
                {
                    ShowRightAnswerScreen();
                }
            }
            else
            {
                Debug.Log("Some conditions are not met. Please check the document.");
                ShowWrongScreen();
                if (!failSafe)
                {
                    currentScore--;
                    if (currentScore == -maxScore)
                    {
                        SceneManager.LoadScene("LoseScreen");
                    }
                }
            }
            UpdateScoreText();
        }
    }

    private void ShowWrongScreen()
    {
        wrongScreen.SetActive(true);
        Invoke("HideWrongScreen", 3f);
    }

    private void HideWrongScreen()
    {
        wrongScreen.SetActive(false);
    }

    public void ShowErrorScreen()
    {
        errorScreen.SetActive(true);
        
    }

    public void HideErrorScreen()
    {
        errorScreen.SetActive(false);
    }

    private void ShowRightAnswerScreen()
    {
        rightAnswerScreen.SetActive(true);
        Invoke("HideRightAnswerScreen", 1f);
    }

    private void HideRightAnswerScreen()
    {
        rightAnswerScreen.SetActive(false);
    }

    private void UpdateScoreText()
    {
        scoreText.text = currentScore + " / " + maxScore;
    }

    public void ShowEnlargedImage()
    {
        // Get the sprite of the current document
        Sprite documentSprite = imageDisplay.sprite;

        // Set the sprite of the enlarged image
        enlargedImage.sprite = documentSprite;

        // Display the enlarged image panel
        enlargedImagePanel.SetActive(true);
    }

    public void CloseEnlargedImage()
    {
        // Hide the enlarged image panel
        enlargedImagePanel.SetActive(false);
    }

  
}
