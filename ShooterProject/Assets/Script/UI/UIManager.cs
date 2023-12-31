using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header ("Containers")]
    public static UIManager instance;
    [SerializeField] private Transform powerUpContainer;

    [Header ("Top view-Texts")]
    [SerializeField] private TextMeshProUGUI lifesText;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI xPInfoText;
    [SerializeField] private TextMeshProUGUI currentLevelXPText;

    private void Awake()
    {
        //singleton = referência das informações do jogador
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
        SetPowerUpContainer(false);
    }

    public void SetPowerUpContainer(bool isActive)
    {
        powerUpContainer.gameObject.SetActive(isActive);
    }

    public void SetScoreText (int updatedScore)
    {
        scoreText.text = "Score: " + updatedScore;
    }

    public void SetlifesText (int updatedLife) 
    {
        lifesText.text = "Lifes: " + updatedLife;
    }

    public void SetXPInfoText(int currentXP, int toLevelUpXP)
    {
        xPInfoText.text = currentXP + " / " + toLevelUpXP;
    }

    public void SetPlayerLevelText(int newLevel)
    {
        currentLevelXPText.text = "Level: " + newLevel.ToString();
    }
}
