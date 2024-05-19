using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class WelcomeUI : MonoBehaviour
{
    public GameObject Panel; // Assign the UI Panel here
    public MonoBehaviour lookAroundScript; // Assign the Look Around script here
    public MonoBehaviour rotDestroyScript; // Assign the Rot Destroy script here

    void Start()
    {
        // Ensure the welcome panel is active at the start
        if (Panel != null)
        {
            Panel.SetActive(true);
            Time.timeScale = 0; // Pause the game
            Debug.Log("Welcome panel is active and game is paused.");
        }
        else
        {
            Debug.LogError("Welcome panel is not assigned.");
        }

        // Deactivate the scripts at the start
        if (lookAroundScript != null)
        {
            lookAroundScript.enabled = false;
        }
        else
        {
            Debug.LogError("Look Around script is not assigned.");
        }

        if (rotDestroyScript != null)
        {
            rotDestroyScript.enabled = false;
        }
        else
        {
            Debug.LogError("Rot Destroy script is not assigned.");
        }
    }

    public void OnStartButtonClicked()
    {
        // Hide the welcome panel and start the game
        if (Panel != null)
        {
            Panel.SetActive(false);
            Time.timeScale = 1; // Resume the game
            Debug.Log("Start button clicked, welcome panel hidden and game resumed.");
        }
        else
        {
            Debug.LogError("Welcome panel is not assigned.");
        }

        // Activate the scripts when the game starts
        if (lookAroundScript != null)
        {
            lookAroundScript.enabled = true;
        }

        if (rotDestroyScript != null)
        {
            rotDestroyScript.enabled = true;
        }
    }

    void Update()
    {
        // Prevent game input when the welcome panel is active
        if (Panel.activeSelf && EventSystem.current.IsPointerOverGameObject())
        {
            // Prevent in-game actions when interacting with the UI
            return;
        }

        // Add your in-game input handling logic here
        // For example, movement logic should be here, not affecting the UI interaction
    }
}
