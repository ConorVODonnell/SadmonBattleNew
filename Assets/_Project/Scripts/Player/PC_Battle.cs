using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState { Selection, Paused }
public enum SelectionState { Sademon, Target }
public class PC_Battle : MonoBehaviour
{
    [SerializeField] MouseData mouse;
    [SerializeField] LocationManager map;

    PlayerState state;
    SelectionState selection;

    SadeTA selectedSade;

    #region --- Player Events ---
    public static event Action<B_Tile> OnTileSelected;
    void TileSelected(B_Tile tile) {
        PC_TileSelected(tile);
        if (OnTileSelected != null) OnTileSelected(tile);
    }
    public static event Action<SadeTA> OnSademonSelected;
    void SademonSelected(SadeTA sadeTA) {
        PC_SademonSelected(sadeTA);
        if (OnSademonSelected != null) OnSademonSelected(sadeTA);
    }
    public static event Action<SadeTA> OnSademonDeselected;
    void SademonDeselected() {
        var toDeselect = PC_SademonDeselected();
        if (OnSademonDeselected != null) OnSademonDeselected(toDeselect);
    }
    #endregion

    void Update() {
        if (state == PlayerState.Selection) {
            HandleSelection();
        }
    }

    void HandleSelection() {
        if (selection == SelectionState.Sademon)
            HandleSademonSelection();
    }

    void HandleSademonSelection() {
        if (!mouse.ClickedGround()) return;

        var selectedTile = mouse.ToBattleTile();
        TileSelected(selectedTile);

        if (selectedTile.HasSademon(out selectedSade))
            SademonSelected(selectedSade);
        else
            SademonDeselected();
    }

    void PC_SademonSelected(SadeTA selectedSademon) {

    }

    SadeTA PC_SademonDeselected() {
        var toDeselect = selectedSade;
        selectedSade = null;
        return toDeselect;
    }

    void PC_TileSelected(B_Tile tile) {

    }
}
