using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public Toggle startLevel1Toggle;  // Toggle für Level 1
    public Toggle startLevel2Toggle;  // Toggle für Level 2
    public Button confirmButton;      // Bestätigungsbutton
    public int requiredPointsForLevel2 = 3;  // Punkte, die für Level 2 benötigt werden
    private string selectedLevel = "";  // Speichert das ausgewählte Level

    // Singleton-Pattern, um sicherzustellen, dass das Menü beim Szenenwechsel erhalten bleibt
    private static MainMenuController instance;

    void Awake()
    {
        // Stelle sicher, dass nur eine Instanz des MainMenuControllers existiert
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);  // Verhindert das Zerstören des Objekts beim Szenenwechsel
        }
        else
        {
            Destroy(gameObject);  // Zerstört das Objekt, wenn eine Instanz schon existiert
        }
    }

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

        // Bestätigungsbutton-Listener
        confirmButton.onClick.AddListener(() => {
            if (!string.IsNullOrEmpty(selectedLevel))
            {
                StartLevel(selectedLevel);
            }
        });
    }

    // Überprüfe, ob Level 2 freigeschaltet werden kann
    public void CheckLevelUnlock()
    {
        if (GameManager.instance != null)
        {
            int points = GameManager.instance.points; // Greife auf den Punktestand im GameManager zu

            if (points >= requiredPointsForLevel2)
            {
                startLevel2Toggle.interactable = true;  // Aktiviert den Toggle für Level 2
            }
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

