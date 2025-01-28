using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public Toggle startLevel1Toggle;  // Toggle f�r Level 1
    public Toggle startLevel2Toggle;  // Toggle f�r Level 2
    public Toggle startLevel3Toggle;  // Toggle f�r Level 3
    public Button confirmButton;      // Best�tigungsbutton
    public int requiredPointsForLevel2 = 10;  // Punkte, die f�r Level 2 ben�tigt werden
    public int requiredPointsForLevel3 = 20;
    private string selectedLevel = "";  // Speichert das ausgew�hlte Level

    // Singleton-Pattern, um sicherzustellen, dass das Men� beim Szenenwechsel erhalten bleibt
    private static MainMenuController instance;

   

    void Start()
    {
        // `Confirm`-Button anfangs deaktivieren
        confirmButton.interactable = false;

        // Level 2 Toggle zun�chst deaktivieren
        startLevel2Toggle.interactable = false;

        // Event-Listener f�r Level 1 Toggle
        startLevel1Toggle.onValueChanged.AddListener((isOn) => {
            if (isOn)
            {
                selectedLevel = "Scenes/Vormaier";  // Speichere die Auswahl f�r Level 1
                UpdateConfirmButtonState();
            }
            else if (selectedLevel == "Scenes/Vormaier")
            {
                selectedLevel = ""; // L�sche die Auswahl, wenn der Toggle deaktiviert wird
                UpdateConfirmButtonState();
            }
        });

        // Event-Listener f�r Level 2 Toggle
        startLevel2Toggle.onValueChanged.AddListener((isOn) => {
            if (isOn)
            {
                selectedLevel = "Scenes/Probst";  // Speichere die Auswahl f�r Level 2
                UpdateConfirmButtonState();
            }
            else if (selectedLevel == "Scenes/Probst")
            {
                selectedLevel = ""; // L�sche die Auswahl, wenn der Toggle deaktiviert wird
                UpdateConfirmButtonState();
            }
        });

        // Event-Listener f�r Level 3 Toggle
        startLevel3Toggle.onValueChanged.AddListener((isOn) => {
            if (isOn)
            {
                selectedLevel = "Scenes/ingo";  // Speichere die Auswahl f�r Level 3
                UpdateConfirmButtonState();
            }
            else if (selectedLevel == "Scenes/ingo")
            {
                selectedLevel = ""; // L�sche die Auswahl, wenn der Toggle deaktiviert wird
                UpdateConfirmButtonState();
            }
        });

        // Best�tigungsbutton-Listener
        confirmButton.onClick.AddListener(() => {
            if (!string.IsNullOrEmpty(selectedLevel))
            {
                StartLevel(selectedLevel);
            }
        });

        CheckLevelUnlock();
    }

    // �berpr�fe, ob Level 2 freigeschaltet werden kann
    void CheckLevelUnlock()
    {
       
            HighScore[] components = GameObject.FindObjectsOfType<HighScore>();
            int points = components[0].score;
        if (points >= requiredPointsForLevel3 && components[0].level == 2)
        {
            Debug.Log("level3 freigeschaltet");
            startLevel3Toggle.interactable = true;
            startLevel2Toggle.interactable = true;

            // Aktiviert den Toggle f�r Level 2
        }
        if (points >= requiredPointsForLevel2 && components[0].level == 1)
            {
            Debug.Log("level2 freigeschaltet");
                startLevel2Toggle.interactable = true;  // Aktiviert den Toggle f�r Level 2
            }

            
        
    }

    // Diese Methode wird aufgerufen, wenn Level 1 abgeschlossen ist


    // Methode zum Starten eines Levels
    void StartLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);  // Lade das ausgew�hlte Level
    }

    // Diese Methode aktualisiert den Status des Best�tigungsbuttons
    private void UpdateConfirmButtonState()
    {
        // Aktivieren des Best�tigungsbuttons nur, wenn ein Level ausgew�hlt wurde
        confirmButton.interactable = !string.IsNullOrEmpty(selectedLevel);
    }
}

