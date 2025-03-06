using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.Editor;
using UnityEngine.UI;

public class MoneyClicker : MonoBehaviour
{

    [Header("ClickerUpgrade")]
    public float clickerIncome = 1f;
    private float wallet;

    [Header("ClickerUpgrade")]
    [SerializeField]float clickerUpgradeCost;

    [Header("PassiveIncomeUpgrade")]
    public float passiveIncome = 0f;
    [SerializeField]float passiveUpgradeCost;
    bool passiveIncomeActive = false;

    [Header("DoubleTap")]
    [SerializeField]float doubleTapCost;
    bool doubleTapActive = false;
    
    public TextMeshProUGUI currentclickerIncomeText;
    public TextMeshProUGUI currentPassiveIncome;
    public TextMeshProUGUI totalMoneyText;

    public TextMeshProUGUI clickerUpgradeCostText;
    public TextMeshProUGUI passiveUpgradeCostText;
    public TextMeshProUGUI doubleTapCostText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        clickerUpgradeCostText.text = clickerUpgradeCost.ToString();
        passiveUpgradeCostText.text = passiveUpgradeCost.ToString();
        doubleTapCostText.text = doubleTapCost.ToString();
    }

    // Update is called once per frame
    void Update()
    {
       if (passiveIncomeActive == true)
       {
              wallet += (clickerIncome + passiveIncome) * Time.deltaTime;
       }   
       totalMoneyText.text = wallet.ToString();
    }

    public void Clicker()
    {
       wallet += clickerIncome;
       Debug.Log(wallet);

       if (doubleTapActive == true)
       {
          wallet += clickerIncome;
          doubleTapCostText.text = "Bought";
       }
       //totalMoneyText.text = wallet.ToString();
    }
    public void ClickerUpgrade()
    {  
       if (wallet >= clickerUpgradeCost)
       {
          wallet -= clickerUpgradeCost;
          clickerUpgradeCost = clickerUpgradeCost * Random.Range(1.2f,1.5f);
          clickerUpgradeCostText.text = clickerUpgradeCost.ToString();
          clickerIncome += Random.Range(2f,3f);
       }
    }
    public void DoubleTap()
    {  
       if (wallet >= doubleTapCost)
       {
          doubleTapActive = true;
          wallet -= doubleTapCost;
       }
    }

    public void MoneyOverTime()
    {  
       if (wallet >= passiveUpgradeCost)
       {
          passiveIncomeActive = true;
          wallet -= passiveUpgradeCost;
          passiveUpgradeCost = passiveUpgradeCost * Random.Range(1.5f,2.0f);
          passiveUpgradeCostText.text = passiveUpgradeCost.ToString();
          passiveIncome += Random.Range(2f,3f);
       }
    }


}
