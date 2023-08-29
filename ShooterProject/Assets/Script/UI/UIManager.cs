using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField] private TextMeshProUGUI lifesText;
    [SerializeField] private TextMeshProUGUI scoreText;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogError("Another UI instance is active");
            Destroy(this.gameObject);
        }

        SetupUI();
    }

    private void SetupUI()
    {
        lifesText.gameObject.SetActive(true);
        scoreText.gameObject.SetActive(true);
    }

    public void SetScoreText (int updatedScore)
    {
        scoreText.text = "Score: " + updatedScore;
    }

    public void SetlifesText (int updatedLife) 
    {
        lifesText.text = "Lifes: " + updatedLife;
    }
}
