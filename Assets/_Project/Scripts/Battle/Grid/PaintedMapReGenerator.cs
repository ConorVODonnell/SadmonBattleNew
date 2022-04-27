using System.Collections.Generic;

public class PaintedMapReGenerator : IMapGenerator
{

    List<CubeCoordinate> mapCoordinates;
    MapStartupData startupData;
    List<SadeTA> startingSademon;

    public PaintedMapReGenerator(List<CubeCoordinate> mapCoordinates, MapStartupData startupData, List<SadeTA> startingSademon) {
        this.mapCoordinates = mapCoordinates;
        this.startupData = startupData;
        this.startingSademon = startingSademon;
    }

    /// Called to create and assign map
    public Dictionary<CubeCoordinate, B_Tile> CreateMap() {
        var map = InitializeMap();

        return map;
    }

    Dictionary<CubeCoordinate, B_Tile> InitializeMap() {
        var baseMap = new Dictionary<CubeCoordinate, B_Tile>();

        foreach (var terrain in InitialTerrains())
            baseMap.Add(terrain.Key, CreateBattleTile(terrain.Value));

        return baseMap;
    }

    B_Tile CreateBattleTile(TerrainTA terrainTA) {
        return new B_Tile(terrainTA);
    }

    Dictionary<CubeCoordinate, TerrainTA> InitialTerrains() {
        var newTerrains = new Dictionary<CubeCoordinate, TerrainTA>();

        foreach (var position in mapCoordinates)
            newTerrains.Add(position, CreateTerrain(position));

        return newTerrains;
    }

    TerrainTA CreateTerrain(CubeCoordinate coord) {
        return new TerrainTA(DecideTerrain(coord), coord);
    }

    TerrainBase DecideTerrain(CubeCoordinate position) {
        return startupData.DecideTerrain(GetRandomNumberForTerrain());
    }

    float GetRandomNumberForTerrain() {
        return UnityEngine.Random.Range(0f, 1f);
    }

    // Called second to put Sademon down
    public void AssignStaringSademon(Dictionary<CubeCoordinate, B_Tile> map) {
        var coordinates = UniqueCoordinates(startingSademon.Count);

        for (int i = 0; i < startingSademon.Count; i++) {
            var sade = startingSademon[i];

            sade.MoveTo(coordinates[i]);
        }
    }

    List<CubeCoordinate> UniqueCoordinates(int sademonCount) {
        var uniqueCoordinates = new List<CubeCoordinate>();

        var coord = GetRandomCubeCoordinate();
        for (int i = 0; i < sademonCount; i++) {
            while (uniqueCoordinates.Contains(coord))
                coord = GetRandomCubeCoordinate();

            uniqueCoordinates.Add(coord);
        }

        return uniqueCoordinates;
    }

    CubeCoordinate GetRandomCubeCoordinate() {
        int choice = UnityEngine.Random.Range(0, mapCoordinates.Count);
        return mapCoordinates[choice];
    }
}
