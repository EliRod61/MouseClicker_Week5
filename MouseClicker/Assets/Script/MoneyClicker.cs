using System.Collections;
using TMPro;
using UnityEngine;
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

    [Header("TriplePickles")]
    [SerializeField] float triplePicklesCost;

    float picklesMultiplier;
    float ppm;
    
    public TextMeshProUGUI currentClickingMultiplier;
    public TextMeshProUGUI currentPPM;
    public TextMeshProUGUI totalMoneyText;

    public TextMeshProUGUI clickerUpgradePriceText;
    public TextMeshProUGUI passiveUpgradePriceText;
    public TextMeshProUGUI doubleTapPriceText;
    public TextMeshProUGUI triplePicklesPriceText;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        clickerUpgradePriceText.text = clickerUpgradeCost.ToString();
        passiveUpgradePriceText.text = passiveUpgradeCost.ToString();
        doubleTapPriceText.text = doubleTapCost.ToString();
    }

    // Update is called once per frame
    void Update()
    {
       if (passiveIncomeActive == true)
       {
              wallet += (clickerIncome + passiveIncome) * Time.deltaTime;
       }   
        totalMoneyText.text = wallet.ToString();
        currentClickingMultiplier.text = picklesMultiplier.ToString();
        currentPPM.text = ppm.ToString();
        triplePicklesPriceText.text = triplePicklesCost.ToString();

        if (doubleTapActive == true)
        {
            doubleTapPriceText.text = "Bought";
        }
    }

    public void Clicker()
    {
       wallet += clickerIncome;

       if (doubleTapActive == true)
       {
          wallet += clickerIncome;
       }
       //totalMoneyText.text = wallet.ToString();
    }
    public void ClickerUpgrade()
    {  
       if (wallet >= clickerUpgradeCost)
       {
            //Take away the amount from the wallet
            wallet -= clickerUpgradeCost;

            //Increases the price by random range
            clickerUpgradeCost = clickerUpgradeCost * Random.Range(1.5f, 1.7f);

            //Displays the new price
            clickerUpgradePriceText.text = clickerUpgradeCost.ToString();

            //Random Increase in click amount when bought 
            float randomMultiplierIncrease = Random.Range(5f, 12f);

            //Displays the multiplier
            picklesMultiplier += randomMultiplierIncrease;

            //Adds the multiplier to the click amount
            clickerIncome += randomMultiplierIncrease;
       }
    }
    public void DoubleTap()
    {  
        if (wallet >= doubleTapCost && doubleTapActive == false)
        {
          doubleTapActive = true;
          wallet -= doubleTapCost;
        }
    }

    public void MoneyOverTime()
    {  
       if (wallet >= passiveUpgradeCost)
       {
            //PPM activates -- start earning money passively
            passiveIncomeActive = true;

            //Takes price from wallet
            wallet -= passiveUpgradeCost;

            //Increase price by random range
            passiveUpgradeCost = passiveUpgradeCost * Random.Range(1.5f, 1.8f);

            //Displays new price
            passiveUpgradePriceText.text = passiveUpgradeCost.ToString();

            //Random increase to PPM when bought
            float randomMultiplierIncrease = Random.Range(35f, 50f);

            //displays the ppm
            ppm += randomMultiplierIncrease;

            //Sets the new ppm
            passiveIncome += randomMultiplierIncrease;
       }
    }

    public void TripleProfits()
    {
        if (wallet >= triplePicklesCost)
        {
            //Takes price from wallet
            wallet -= triplePicklesCost;

            //Increase price by random range
            triplePicklesCost = triplePicklesCost * 1.5f;

            //Displays new price
            triplePicklesPriceText.text = triplePicklesCost.ToString();

            //Triples current clicker multiplier
            clickerIncome = clickerIncome * 3;
        }
    }


}
