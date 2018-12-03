using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI waveNumber;

    public RectTransform sacraficeMenu;
    public RectTransform statSacrificeMenu;
    public RectTransform weaponSacrificeMenu;

    public Button statSacrificeButton;
    public Button weaponSacrificeButton;

    public Button vitality;
    public Button strength;
    public Button dexterity;
    public Button wisdom;
    public TextMeshProUGUI vitalityNumber;
    public TextMeshProUGUI strengthNumber;
    public TextMeshProUGUI dexterityNumber;
    public TextMeshProUGUI wisdomNumber;
    public TextMeshProUGUI statDescription;

    public Button weapon1;
    public Button weapon2;
    public TextMeshProUGUI weaponDescription;

    public SpriteRenderer playerHealthBar;

    private string waveText;
    public bool inMenu { get; private set; }

    #region Singleton

    public static UIManager instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    private void Start()
    {
        waveText = waveNumber.text;

        // disable sacrafice menus until round ends
        sacraficeMenu.gameObject.SetActive(false);
        statSacrificeMenu.gameObject.SetActive(false);
        weaponSacrificeMenu.gameObject.SetActive(false);
        inMenu = false;
    }

    private void Update()
    {
        Vector3 healthBarScale = playerHealthBar.transform.localScale;
        healthBarScale.x = PlayerManager.instance.GetCurrentHealth() / PlayerManager.instance.GetMaxHealth();
        playerHealthBar.transform.localScale = healthBarScale;
    }

    public void UpdateWaveNumber(int roundNumber)
    {
        waveNumber.text = waveText + roundNumber;
    }

    public void OpenSacraficeMenu()
    {
        sacraficeMenu.gameObject.SetActive(true);
        inMenu = true;
    }

    private void CloseSacraficeMenu()
    {
        sacraficeMenu.gameObject.SetActive(false);
    }

    public void StatSacraficeMenu()
    {
        // close sacrafice menu
        CloseSacraficeMenu();

        // open stat sacrafice menu
        statSacrificeMenu.gameObject.SetActive(true);
    }

    public void UpdateStatDescription(string description)
    {
        statDescription.text = description;
    }

    public void WeaponSacraficeMenu()
    {
        // close sacrafice menu
        CloseSacraficeMenu();

        // open weapon menu
        weaponSacrificeMenu.gameObject.SetActive(true);
    }

    public void UpdateWeaponDescription(int weaponNumber)
    {
        if(weaponNumber == 1)
        {
            weaponDescription.text = GameManager.instance.weapon1.description;
        }
        else if(weaponNumber == 2)
        {
            weaponDescription.text = GameManager.instance.weapon2.description;
        }
    }

    public void CloseAllMenus()
    {
        sacraficeMenu.gameObject.SetActive(false);
        statSacrificeMenu.gameObject.SetActive(false);
        weaponSacrificeMenu.gameObject.SetActive(false);
        inMenu = false;
    }
}
