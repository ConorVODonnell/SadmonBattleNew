using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System.Linq;

public class B_Start : MonoBehaviour
{
    [SerializeField] BattleSystem battleSystem;

    [SerializeField] Tilemap groundMap;
    [SerializeField] MapStartupData startupData;
    [SerializeField] LocationManager map;

    [SerializeField] List<SadeBase> playerSademon, enemySademon;
    SadeParty playerParty = new SadeParty(true), enemyParty = new SadeParty(false);

    void Start() {
        CreateMap();

        battleSystem.enabled = true;
    }

    void CreateMap() {
        var cellsInMap = CellsBasedOnPaintedTiles();

        CreatePartiesFromBase();

        var startingSademon = new List<SadeTA>();
        startingSademon.AddRange(playerParty.party);
        startingSademon.AddRange(enemyParty.party);
        var generator = new PaintedMapReGenerator(cellsInMap, startupData, startingSademon);
        map.Init(generator);
    }

    //map.TileDatas[CubeCoordinate.zero].Contents.Sademon

    // WHILE TESTING
    // Iterates through all the cells currently painted on the groundMap
    // and returns a list of their CubeCoordinates
    List<CubeCoordinate> CellsBasedOnPaintedTiles() {
        var cellsInMap = new List<CubeCoordinate>();

        groundMap.CompressBounds();
        Vector3Int pos = Vector3Int.zero;
        Vector3Int botLeft = groundMap.origin;
        Vector3Int topRight = botLeft + groundMap.size;
        for (int x = botLeft.x; x < topRight.x; x++) {
            for (int y = botLeft.y; y < topRight.y; y++) {
                pos.x = x;
                pos.y = y;

                if (groundMap.HasTile(pos))
                    cellsInMap.Add(CubeCoordinate.ToCube(pos));
            }
        }

        return cellsInMap;
    }

    void CreatePartiesFromBase() {
        foreach (var sadeBase in playerSademon)
            SademonFromBase(sadeBase, playerParty);
        foreach (var enemyBase in enemySademon)
            SademonFromBase(enemyBase, enemyParty);
    }

    void SademonFromBase(SadeBase sadeBase, SadeParty party) {
        var sadeTA = new SadeTA(sadeBase);
        party.AssignToParty(sadeTA);
    }
}
