public interface IMoveable
{


    void OnLeave(CubeCoordinate oldLocation);
    void OnEnter(CubeCoordinate newLocation);

    void OnMove(CubeCoordinate newLocation, CubeCoordinate oldLocation) {
        OnLeave(oldLocation);
        OnEnter(newLocation);
    }
}
