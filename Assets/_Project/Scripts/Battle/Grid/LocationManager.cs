using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationManager : ConorV.Singleton<LocationManager>
{
    Dictionary<CubeCoordinate, B_Tile> TileDatas = new Dictionary<CubeCoordinate, B_Tile>();

    public void Init(IMapGenerator generator) {

        TileDatas = generator.CreateMap();

        generator.AssignStaringSademon(TileDatas);

    }

    public B_Tile GetTile(CubeCoordinate coordinate) {
        return TileDatas[coordinate]; 
    }

    public B_Tile GetTile(Vector3Int coordinate) {
        return GetTile(CubeCoordinate.ToCube(coordinate));
    }

}
