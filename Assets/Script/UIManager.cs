using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI gameOverText; 
    public TMP_InputField inputField;
    
    // Display the game over text with the specified message
    public void ShowGameOverText(string gameOverMessage)
    {
        // Set the text to the specified message
        gameOverText.text = gameOverMessage;

        // Show the game over text
        gameOverText.gameObject.SetActive(true);
    }
}
