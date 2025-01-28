using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public Toggle startLevel1Toggle;  // Toggle für Level 1
    public Toggle startLevel2Toggle;  // Toggle für Level 2
    public Toggle startLevel3Toggle;  // Toggle für Level 3
    public Button confirmButton;      // Bestätigungsbutton
    public int requiredPointsForLevel2 = 10;  // Punkte, die für Level 2 benötigt werden
    public int requiredPointsForLevel3 = 20;
    private string selectedLevel = "";  // Speichert das ausgewählte Level

    // Singleton-Pattern, um sicherzustellen, dass das Menü beim Szenenwechsel erhalten bleibt
    private static MainMenuController instance;

   

    void Start()
    {
        // `Confirm`-Button anfangs deaktivieren
        confirmButton.interactable = false;

        // Level 2 Toggle zunächst deaktivieren
        startLevel2Toggle.interactable = false;

        // Event-Listener für Level 1 Toggle
        startLevel1Toggle.onValueChanged.AddListener((isOn) => {
            if (isOn)
            {
                selectedLevel = "Scenes/Vormaier";  // Speichere die Auswahl für Level 1
                UpdateConfirmButtonState();
            }
            else if (selectedLevel == "Scenes/Vormaier")
            {
                selectedLevel = ""; // Lösche die Auswahl, wenn der Toggle deaktiviert wird
                UpdateConfirmButtonState();
            }
        });

        // Event-Listener für Level 2 Toggle
        startLevel2Toggle.onValueChanged.AddListener((isOn) => {
            if (isOn)
            {
                selectedLevel = "Scenes/Probst";  // Speichere die Auswahl für Level 2
                UpdateConfirmButtonState();
            }
            else if (selectedLevel == "Scenes/Probst")
            {
                selectedLevel = ""; // Lösche die Auswahl, wenn der Toggle deaktiviert wird
                UpdateConfirmButtonState();
            }
        });

        // Event-Listener für Level 3 Toggle
        startLevel3Toggle.onValueChanged.AddListener((isOn) => {
            if (isOn)
            {
                selectedLevel = "Scenes/ingo";  // Speichere die Auswahl für Level 3
                UpdateConfirmButtonState();
            }
            else if (selectedLevel == "Scenes/ingo")
            {
                selectedLevel = ""; // Lösche die Auswahl, wenn der Toggle deaktiviert wird
                UpdateConfirmButtonState();
            }
        });

        // Bestätigungsbutton-Listener
        confirmButton.onClick.AddListener(() => {
            if (!string.IsNullOrEmpty(selectedLevel))
            {
                StartLevel(selectedLevel);
            }
        });

        CheckLevelUnlock();
    }

    // Überprüfe, ob Level 2 freigeschaltet werden kann
    void CheckLevelUnlock()
    {
       
            HighScore[] components = GameObject.FindObjectsOfType<HighScore>();
            int points = components[0].score;
        if (points >= requiredPointsForLevel3 && components[0].level == 2)
        {
            Debug.Log("level3 freigeschaltet");
            startLevel3Toggle.interactable = true;
            startLevel2Toggle.interactable = true;

            // Aktiviert den Toggle für Level 2
        }
        if (points >= requiredPointsForLevel2 && components[0].level == 1)
            {
            Debug.Log("level2 freigeschaltet");
                startLevel2Toggle.interactable = true;  // Aktiviert den Toggle für Level 2
            }

            
        
    }

    // Diese Methode wird aufgerufen, wenn Level 1 abgeschlossen ist


    // Methode zum Starten eines Levels
    void StartLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);  // Lade das ausgewählte Level
    }

    // Diese Methode aktualisiert den Status des Bestätigungsbuttons
    private void UpdateConfirmButtonState()
    {
        // Aktivieren des Bestätigungsbuttons nur, wenn ein Level ausgewählt wurde
        confirmButton.interactable = !string.IsNullOrEmpty(selectedLevel);
    }
}

