using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class StartUI : MonoBehaviour
{
    [SerializeField]
    private Button startButton;

    public void AddStartButtonEvent(UnityAction callback)
    {
        startButton.onClick.AddListener(callback);
    }
}
