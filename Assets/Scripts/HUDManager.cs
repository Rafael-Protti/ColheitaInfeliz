using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    public TextMeshProUGUI coinsText;
    public TextMeshProUGUI currentCoinsText;
    public TextMeshProUGUI neededCoinsText;
    public UnityEngine.UI.Slider slider;
    
    public static HUDManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        currentCoinsText.text = Player.instance.coinsNeeded.ToString();
        UpdateText();
    }
    public void UpdateText()
    {
        coinsText.text = "Moedas: " + Player.instance.coins.ToString();
        currentCoinsText.text = Player.instance.coins.ToString();
        slider.value = Player.instance.coins;
        slider.maxValue = Player.instance.coinsNeeded;
    }
}
