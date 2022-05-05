using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerActionButton : MonoBehaviour
{
    Button button;
    TMPro.TMP_Text buttonText;
    int buttonOrder;

    internal void Init(int order) {
        // Get Components
        button = GetComponent<Button>();
        buttonText = GetComponentInChildren<TMPro.TMP_Text>();

        // UIController sorts the buttons into an order that matches their order in its List<Buttons>
        buttonOrder = order;

        // When clicked, the PC_Battle calls on the action of the currentSademon that matches this buttonOrder
        // button.onClick.AddListener(() => { PC_Battle.OnActionSelected(buttonOrder); });
    }

    public void UpdateButton() {

    }

    // OnMouseOver()
    public void ShowDescription() {

    }
}
