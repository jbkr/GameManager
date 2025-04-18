using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ModeUI : MonoBehaviour
{
    [SerializeField]
    private Button timeAttackButton;

    [SerializeField]
    private Button stageModeButton;

    public void AddTimeAttackEvent(UnityAction callback)
    {
        timeAttackButton.onClick.AddListener(callback);
    }

    public void AddStageModeEvent(UnityAction callback)
    {
        stageModeButton.onClick.AddListener(callback);
    }
}
