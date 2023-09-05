using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpLifePlus : MonoBehaviour
{
    [Header ("PowerUpLifePlus Up Info")]
    [SerializeField] private Button button;
    [SerializeField] private string name;
    [SerializeField] private Sprite icon;

    [Header ("Prefab child component")]
    [SerializeField] private Image powerUpIcon;
    [SerializeField] private TextMeshProUGUI powerUpText;

    private void Awake()
    {
        button.onClick.AddListener(LifeIncrease);
        powerUpIcon.sprite = icon;
        powerUpText.text = name;
    }

    private void Start()
    {
    }

    private void LifeIncrease()
    {
        PlayerInfo.instance.LifeHandler(1);
        Time.timeScale = 1;
        UIManager.instance.SetPowerUpContainer(false);
    }
}
