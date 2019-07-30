using UnityEngine;
using TMPro;

public class UIHandler : MonoBehaviour
{
    public static Canvas Instance { get; private set; }

    public TextMeshProUGUI spawnJuiceIndicator;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = GameObject.Find("UI").GetComponent<Canvas>();
        }
        else
        {
            DestroyImmediate(this);
        }
    }

    private void Start()
    {
        foreach (GameObject control in GameObject.FindGameObjectsWithTag("UIControl"))
        {
            if(control.name == "SpawnJuiceIndicator")
            {
                spawnJuiceIndicator = control.GetComponent<TextMeshProUGUI>();
            }
        }
    }
}
