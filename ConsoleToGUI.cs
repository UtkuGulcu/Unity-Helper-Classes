using UnityEngine;

public class ConsoleToGUI : MonoBehaviour
{
    [Header("Toggle Inputs")]
    [SerializeField] KeyCode toggle = KeyCode.BackQuote;
    [SerializeField] KeyCode toggleAlternative = KeyCode.DoubleQuote;
    

    [Header("Text area properties")]
    [SerializeField] [Range(0, 1920)] int textAreaXPosition = 15;
    [SerializeField] [Range(0, 1080)] int textAreaYPosition = 272;
    [SerializeField] [Range(0, 1920)] int textAreaWidth = 637;
    [SerializeField] [Range(0, 1080)] int textAreaHeight = 194;

    [Header("Button properties")]
    [SerializeField] [Range(0, 1920)] int buttonXPosition = 467;
    [SerializeField] [Range(0, 1080)] int buttonYPosition = 72;
    [SerializeField] [Range(0, 1920)] int buttonWidth = 185;
    [SerializeField] [Range(0, 1080)] int buttonHeight = 38;

    string myLog = "*begin log";
    bool doShow;
    int kChars = 700;

    void OnEnable() { Application.logMessageReceived += Log; }
    void OnDisable() { Application.logMessageReceived -= Log; }
    void Update() { if (Input.GetKeyDown(toggle) || Input.GetKeyDown(toggleAlternative)) { doShow = !doShow; } }
    public void Log(string logString, string stackTrace, LogType type)
    {
        myLog = myLog + "\n" + logString;
        if (myLog.Length > kChars) { myLog = myLog.Substring(myLog.Length - kChars); }
    }

    void OnGUI()
    {
        if (!doShow) { return; }

        GUI.TextArea(new Rect(textAreaXPosition, Screen.height - textAreaYPosition, textAreaWidth, textAreaHeight), myLog);

        if (GUI.Button(new Rect(buttonXPosition, Screen.height - buttonYPosition, buttonWidth, buttonHeight), "Clear"))
        {
            myLog = string.Empty;
        }
    }
}