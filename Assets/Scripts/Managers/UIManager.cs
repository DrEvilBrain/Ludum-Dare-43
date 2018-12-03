using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI waveNumber;

    public RectTransform sacraficeMenu;
    public RectTransform statSacraficeMenu;
    public RectTransform weaponSacraficeMenu;

    public Button statSacraficeButton;
    public Button weaponSacraficeButton;

    public Button vitality;
    public Button strength;
    public Button dexterity;
    public Button wisdom;
    public TextMeshProUGUI vitalityNumber;
    public TextMeshProUGUI strengthNumber;
    public TextMeshProUGUI dexterityNumber;
    public TextMeshProUGUI wisdomNumber;

    public Button weapon1;
    public Button weapon2;

    private string waveText;
    public bool inMenu { get; private set; }

    #region Singleton

    public static UIManager instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    // Use this for initialization
    void Start()
    {
        waveText = waveNumber.text;

        // disable sacrafice menus until round ends
        sacraficeMenu.gameObject.SetActive(false);
        statSacraficeMenu.gameObject.SetActive(false);
        weaponSacraficeMenu.gameObject.SetActive(false);
        inMenu = false;

        // stat sacrafice menu buttons
        vitality.onClick.AddListener(SacraficeVitality);
        strength.onClick.AddListener(SacraficeStrength);
        dexterity.onClick.AddListener(SacraficeDexterity);
        wisdom.onClick.AddListener(SacraficeWisdom);

        // weapon sacrafice menu buttons
        weapon1.onClick.AddListener(ChangeToWeapon1);
        weapon2.onClick.AddListener(ChangeToWeapon2);
    }
	
	// Update is called once per frame
	void Update()
    {
		
	}

    public void UpdateWaveNumber(int roundNumber)
    {
        waveNumber.text = waveText + roundNumber;
    }

    public void OpenSacraficeMenu()
    {
        sacraficeMenu.gameObject.SetActive(true);
        inMenu = true;
        SacraficeMenu();
    }

    private void SacraficeMenu()
    {
        // stat sacrafice
        statSacraficeButton.onClick.AddListener(delegate { StatSacraficeMenu(); });

        // weapon sacrafice
        weaponSacraficeButton.onClick.AddListener(delegate { WeaponSacraficeMenu(); });
    }

    public void CloseSacraficeMenu()
    {
        sacraficeMenu.gameObject.SetActive(false);
    }

    private void OpenStatSacraficeMenu()
    {
        sacraficeMenu.gameObject.SetActive(true);
        StatSacraficeMenu();
    }

    private void StatSacraficeMenu()
    {
        // close sacrafice menu
        CloseSacraficeMenu();

        // open stat sacrafice menu
        statSacraficeMenu.gameObject.SetActive(true);
    }

    private void SacraficeVitality()
    {
        PlayerManager.instance.SacrificeVitality();
    }

    private void SacraficeStrength()
    {
        PlayerManager.instance.SacrificeStrength();
    }

    private void SacraficeDexterity()
    {
        PlayerManager.instance.SacrificeDexterity();
    }

    private void SacraficeWisdom()
    {
        PlayerManager.instance.SacrificeWisdom();
    }

    private void WeaponSacraficeMenu()
    {
        // close sacrafice menu
        CloseSacraficeMenu();

        // open weapon menu
        weaponSacraficeMenu.gameObject.SetActive(true);
    }

    private void ChangeToWeapon1()
    {

    }

    private void ChangeToWeapon2()
    {

    }

    public void CloseAllMenus()
    {
        sacraficeMenu.gameObject.SetActive(false);
        statSacraficeMenu.gameObject.SetActive(false);
        weaponSacraficeMenu.gameObject.SetActive(false);
        inMenu = false;
    }
}
