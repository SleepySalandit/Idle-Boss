using System.Collections.Generic;
using UnityEngine;
using BreakInfinity;
using System;

public class UpgradesManager : MonoBehaviour
{

    public static UpgradesManager instance;
    private void Awake()
    {
        instance = this;
    }

    public Data data;
    public Controller controller;

    public Upgrades productionUpgrade;
    public Upgrades generationUpgrade;
    public Upgrades generation2Upgrade;
    public Upgrades generation3Upgrade;

    public string productionUpgradeName;
    public string generationUpgradeName;
    public string generation2UpgradeName;
    public string generation3UpgradeName;

    public BigDouble productionUpgradeBaseCost;
    public BigDouble productionUpgradeCostMult;

    public BigDouble generationUpgradeBaseCost;
    public BigDouble generationUpgradeCostMult;

    public BigDouble generation2UpgradeBaseCost;
    public BigDouble generation2UpgradeCostMult;

    public BigDouble generation3UpgradeBaseCost;
    public BigDouble generation3UpgradeCostMult;


    public void StartUpgradeManager()
    {
        productionUpgradeName = "Hire Miner";
        productionUpgradeBaseCost = 50;
        productionUpgradeCostMult = 1.5;

        generationUpgradeName = "Job Flyers";
        generationUpgradeBaseCost = 10e3;
        generationUpgradeCostMult = 1.75;

        generation2UpgradeName = "Job Events";
        generation2UpgradeBaseCost = 10e6;
        generation2UpgradeCostMult = 1.92;

        generation3UpgradeName = "Job Sites";
        generation3UpgradeBaseCost = 10e9;
        generation3UpgradeCostMult = 2.1;
    }

    public BigDouble Cost()
    {
        return productionUpgradeBaseCost * BigDouble.Pow(productionUpgradeCostMult, controller.data.productionUpgradeLevel);
    }

    public BigDouble Cost2()
    {
        return generationUpgradeBaseCost * BigDouble.Pow(generationUpgradeCostMult, controller.data.generationUpgradeLevel);
    }

    public BigDouble Cost3()
    {
        return generation2UpgradeBaseCost * BigDouble.Pow(generation2UpgradeCostMult, controller.data.generation2UpgradeLevel);
    }

    public BigDouble Cost4()
    {
        return generation3UpgradeBaseCost * BigDouble.Pow(generation3UpgradeCostMult, controller.data.generation3UpgradeLevel);
    }
    public void UpdateUpgradeUI()
    {
        var data = Controller.instance.data;

        productionUpgrade.LevelText.text = controller.data.productionUpgradeLevel.ToString("E1");
        productionUpgrade.CostText.text = "Cost: " + Cost().ToString("E1") + " Gold";
        productionUpgrade.NameText.text = productionUpgradeName;

        generationUpgrade.LevelText.text = controller.data.generationUpgradeLevel.ToString("E1");
        generationUpgrade.CostText.text = "Cost: " + Cost2().ToString("E1") + " Gold";
        generationUpgrade.NameText.text = generationUpgradeName;

        generation2Upgrade.LevelText.text = controller.data.generation2UpgradeLevel.ToString("E1");
        generation2Upgrade.CostText.text = "Cost: " + Cost3().ToString("E1") + " Gold";
        generation2Upgrade.NameText.text = generation2UpgradeName;

        generation3Upgrade.LevelText.text = controller.data.generation3UpgradeLevel.ToString("E1");
        generation3Upgrade.CostText.text = "Cost: " + Cost4().ToString("E1") + " Gold";
        generation3Upgrade.NameText.text = generation3UpgradeName;
    }

    public void Update()
    {
        UpdateUpgradeUI();
    }
    public void BuyUpgrade()
    {
        if (controller.data.gold >= Cost())
        {
            controller.data.gold -= Cost();
            controller.data.productionUpgradeLevel += 1;
        }

        UpdateUpgradeUI();
    }

    public void BuyUpgrade2()
    {
        if (controller.data.gold >= Cost2())
        {
            controller.data.gold -= Cost2();
            controller.data.generationUpgradeLevel += 1;
        }

        UpdateUpgradeUI();
    }

    public void BuyUpgrade3()
    {
        if (controller.data.gold >= Cost3())
        {
            controller.data.gold -= Cost3();
            controller.data.generation2UpgradeLevel += 1;
        }

        UpdateUpgradeUI();
    }

    public void BuyUpgrade4()
    {
        if (controller.data.gold >= Cost4())
        {
            controller.data.gold -= Cost4();
            controller.data.generation3UpgradeLevel += 1;
        }

        UpdateUpgradeUI();
    }
}