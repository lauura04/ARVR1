using TMPro;
using UnityEngine;

public class PumpkingCounter : MonoBehaviour
{
    [SerializeField] public int maxNPumpkins = 0;
    int nPumpkins = 0;

    [SerializeField] TextMeshProUGUI textMeshProUGUI;
    public void Awake()
    {
        StartCoinCount();
    }
    public void StartCoinCount()
    {
        GameObject[] pumpkins = GameObject.FindGameObjectsWithTag("PickUp");
        Debug.Log(pumpkins.Length);
        maxNPumpkins = pumpkins.Length;

        nPumpkins = 0;
        textMeshProUGUI.text = $"{nPumpkins} / {maxNPumpkins}";
    }

    public void ResetCoinCount()
    {
        nPumpkins = 0;
        maxNPumpkins = 0;
       
        textMeshProUGUI.text = $"{nPumpkins} / {maxNPumpkins}";
    }

    public void OnTriggerEvent()
    {
        nPumpkins++;
        textMeshProUGUI.text = $"{nPumpkins} / {maxNPumpkins}";
    }
}