using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI gameOverText; // Reference to the TextMeshProUGUI component for displaying game over text
    public TMP_InputField inputField;

    // Start is called before the first frame update
    void Start()
    {
        // Hide the game over text at the start of the game
        // gameOverText.gameObject.SetActive(false);
    }

    // Display the game over text with the specified message
    public void ShowGameOverText(string gameOverMessage)
    {
        // Set the text to the specified message
        gameOverText.text = gameOverMessage;

        // Show the game over text
        gameOverText.gameObject.SetActive(true);
    }
}
