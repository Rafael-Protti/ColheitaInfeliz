using TMPro;
using UnityEngine;

public class HUDManager : MonoBehaviour
{
    public TextMeshProUGUI cointText;
    
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
        UpdateText();
    }
    public void UpdateText()
    {
        cointText.text = "Moedas: " + Player.instance.coins.ToString();
    }
}
