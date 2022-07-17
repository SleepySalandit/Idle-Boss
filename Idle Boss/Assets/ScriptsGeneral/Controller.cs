using UnityEngine;
using UnityEngine.UI;
using BreakInfinity;

public class Controller : MonoBehaviour
{
    public static Controller instance;
    private void Awake()
    {
        instance = this;
    }

    public Data data;
    
    public Text goldText;

    public BigDouble GetGoldpersecond()
    {
        return 0 + (data.productionUpgradeLevel * MineLevelUp.instance.MineLevelEffect());
    }

    public BigDouble MinersPerSecond() => 0 + data.generationUpgradeLevel * 0.2;

    public BigDouble FlyersPerSecond() => 0 + data.generation2UpgradeLevel * 0.15;

    public BigDouble EventsPerSecond() => 0 + data.generation3UpgradeLevel * 0.1;

    private void Start()
    {
        data = new Data();

        UpgradesManager.instance.StartUpgradeManager();
        MineLevelUp.instance.MineLevelEffect();
        

    }

    private void Update()
    {
        goldText.text = $"{data.gold.ToString("E1")} Gold";

        data.gold += GetGoldpersecond() * Time.deltaTime;
        data.productionUpgradeLevel += MinersPerSecond() * Time.deltaTime;
        data.generationUpgradeLevel += FlyersPerSecond() * Time.deltaTime;
        data.generation2UpgradeLevel += EventsPerSecond() * Time.deltaTime;
    }

    public void GenerateGold()
    {
        data.gold += 1 * MineLevelUp.instance.MineLevelEffect();
        
    }
}
