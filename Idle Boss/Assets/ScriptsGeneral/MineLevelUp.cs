using UnityEngine;
using UnityEngine.UI;
using BreakInfinity;
using static Controller;

public class MineLevelUp : MonoBehaviour
{
    public MineLevelUp mineLevelUp;
    public Data data;
    public Controller controller;
    public Text MineLevelGainsText;
    public Text MineLevelText;

    public static MineLevelUp instance;
    private void Awake()
    {
        instance = this;
    }

    public BigDouble MineLevelGains;
    public BigDouble MineLevels;


    public BigDouble mineLevelGains()
    {
        return BigDouble.Sqrt(controller.data.gold / (BigDouble)500);
    }

    public BigDouble MineLevelEffect() => controller.data.MineLevels / (BigDouble)10 + (BigDouble)1;

    public void Update()
    {

        var data = Controller.instance.data;
        MineLevelGainsText.text = $"Mine Levels + " + mineLevelGains().ToString("E0");
        MineLevelText.text = $"{controller.data.MineLevels.ToString("E1")}";
    }

    public void MineLevelBoost()
    {
        var data = controller.data;
        if (data.gold > 500)
        {
            data.MineLevels += mineLevelGains();
            data.gold = 0;
            data.productionUpgradeLevel = 0;
            data.generationUpgradeLevel = 0;
            data.generation2UpgradeLevel = 0;
            data.generation3UpgradeLevel = 0;

        }
    }
}