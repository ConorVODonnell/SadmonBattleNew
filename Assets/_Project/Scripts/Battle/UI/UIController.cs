using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] PlayerActionButton[] buttons;

    #region Setup
    void OnEnable() {
        PC_Battle.OnSademonSelected += UpdateButtons;
        PC_Battle.OnSademonDeselected += ClearButtons;
    }
    void OnDisable() {
        PC_Battle.OnSademonSelected -= UpdateButtons;
        PC_Battle.OnSademonDeselected -= ClearButtons;
    }

    void Awake() {
        Init();
    }
    #endregion

    private void Init() {
        for (int b = 0; b < buttons.Length; b++)
            buttons[b].Init(b);
        UpdateButtons(null);
    }

    void ClearButtons(SadeTA deselectedSade) {
        UpdateButtons(null);
    }

    void UpdateButtons(SadeTA nowActive) {
        int sademonActions = CountActions(nowActive);

        for (int b = 0; b < buttons.Length; b++) {
            if (ButtonIsActive(sademonActions, b)) 
                buttons[b].UpdateButton(nowActive.Acts[b]);
        }
    }

    private bool ButtonIsActive(int sademonActions, int b) {
        var hasMove = b < sademonActions;
        buttons[b].gameObject.SetActive(hasMove);
        return hasMove;
    }

    int CountActions(SadeTA nowActive) {
        int sademonActions = 0;
        if (nowActive != null) sademonActions = nowActive.Acts.Count;

        return sademonActions;
    }
}
