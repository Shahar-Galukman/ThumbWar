using UnityEngine;
using TMPro;


public class Spawner : MonoBehaviour
{
    public GameObject[] units;
    public Transform spawnPoint;

    [SerializeField]
    private UIHandler uiHandler;

    private void Awake()
    {
        uiHandler = GetComponent<UIHandler>();
    }

    public void SpawnUnit(string type)
    {
        for (int i = 0; i < units.Length; i++ )
        {
            if (units.Length > 0 && units[i].name == type)
            {
                Instantiate(units[i], new Vector2(spawnPoint.position.x, spawnPoint.position.y), Quaternion.identity);
            }
        }
    }
}
