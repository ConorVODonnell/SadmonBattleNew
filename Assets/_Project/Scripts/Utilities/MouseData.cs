using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class MouseData : MonoBehaviour
{
    Mouse m;
    EventSystem eventSystem;
    Camera cam;
    Vector3 camOffset;
    [SerializeField] LocationManager map;
    [SerializeField] Grid grid;
    [SerializeField] UnityEngine.Tilemaps.Tilemap groundMap;

    public Vector3Int CurrentCell { get; private set; } = Vector3Int.zero;

    void Start() {
        m = Mouse.current;
        if (m == null) Debug.LogError("Mouse not found/unassigned.");
        eventSystem = EventSystem.current;
        cam = Camera.main;

        camOffset = new Vector3(0, 0, cam.transform.position.z - grid.gameObject.transform.position.z);

        CurrentCell = ToCell();
    }

    public Vector3Int ToCell() {
        Vector3 mousePos = cam.ScreenToWorldPoint(m.position.ReadValue()) - camOffset;

        return grid.WorldToCell(mousePos);
    }

    public CubeCoordinate ToCube() {
        return CubeCoordinate.ToCube(ToCell());
    }

    public bool TargetChanged(out Vector3Int newCell) {
        if(!IsInWindow()) { newCell = CurrentCell; return false; }
        newCell = ToCell();
        if (CurrentCell != newCell) { CurrentCell = newCell; return true; }
        else return false;
    }

    public bool ClickedGround() {
        if (!ClickedGame()) return false;

        return groundMap.HasTile(ToCell());
    }

    public bool ClickedGame() {
        if (!ClickedInWindow()) return false;
        else return !IsOverUI();
    }

    public bool IsOverUI() {
        return eventSystem.IsPointerOverGameObject();
    }

    public bool ClickedInWindow() {
        if (!Clicked()) return false;
        return IsInWindow();
    }

    public bool Clicked() {
        return m.leftButton.wasPressedThisFrame;
    }

    public bool IsInWindow() {
        var mPos = m.position.ReadValue();
        if (mPos.x < 0 || mPos.y < 0 || mPos.x > Screen.width || mPos.y > Screen.height) return false;
        else return true;
    }

    public B_Tile ToBattleTile() {
        return map.GetTile(ToCube());
    }
}
