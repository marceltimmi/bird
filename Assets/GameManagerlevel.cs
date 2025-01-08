using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // Singleton-Instanz
    public Text pointsText; // Textfeld für die Punkteanzeige (optional)
    public int points = 0; // Punktestand
    public LogicScript logicScript; // Referenz zum LogicScript

    void Awake()
    {
        // Singleton-Pattern: Nur eine Instanz des GameManagers sollte existieren
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);  // Verhindert das Löschen des GameManagers bei Szenenwechsel
        }
        else
        {
            Destroy(gameObject);  // Zerstört das doppelte GameObject
        }
    }

    void Start()
    {
        // Initialisiere den Punktestand mit den Punkten aus dem LogicScript
        if (logicScript != null)
        {
            points = logicScript.playerScore; // Hole den Punktestand aus dem LogicScript
            UpdatePointsText(); // Aktualisiere das Textfeld mit den Punkten
        }
    }

    // Methode zum Aktualisieren des Punktestands im Textfeld
    public void UpdatePointsText()
    {
        if (pointsText != null)
        {
            pointsText.text = points.ToString(); // Zeige die Punkte im Textfeld an
        }
    }

    // Methode zum Hinzufügen von Punkten
    public void AddPoints(int amount)
    {
        points += amount;
        UpdatePointsText(); // Aktualisiere das Textfeld nach dem Hinzufügen von Punkten
    }
}

