using UnityEngine;

public class EventScript : MonoBehaviour
{
    public DialogScriptableObject dialogAsset;
    public GameObject setPoint;

    public bool isMiniGame = false;
    public bool isChangeSceneDoor = false;

    public GameObject minigameCamera;
    public GameObject defaultCamera;
    public GameObject minigameObj;
    //public GameObject interactionIcon;
    public Sprite intIconSprite;

    public string newSceneName;

    private static EventScript _instance;

    public static EventScript Instance
    {
        get
        {
            return _instance;
        }
    }
    private void Awake()
    {
        _instance = this;
        GetComponentInChildren<SpriteRenderer>().sprite = intIconSprite;
    }

    public void SwitchCam()
    {
        GameController.Instance.SwitchCam(minigameCamera, minigameObj);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerEventCheck p = collision.gameObject.GetComponent<PlayerEventCheck>();

        if (p != null)
        {
            GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        PlayerEventCheck p = collision.gameObject.GetComponent<PlayerEventCheck>();

        if (p != null)
        {
            GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);
        }
    }
}
