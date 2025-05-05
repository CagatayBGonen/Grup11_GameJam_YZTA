using UnityEngine;
using TMPro;

public class GameUI : MonoBehaviour
{
    public TextMeshProUGUI energyCountText;
    public GameManager gameManager;


    private void Update()
    {
        energyCountText.text = $"Energy Collected: {gameManager.energyCount}/{gameManager.energyGoal}";
    }
}
