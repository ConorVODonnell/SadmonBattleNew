using System.Collections.Generic;

public interface IMapGenerator
{
    void AssignStaringSademon(Dictionary<CubeCoordinate, B_Tile> map);
    Dictionary<CubeCoordinate, B_Tile> CreateMap();
}