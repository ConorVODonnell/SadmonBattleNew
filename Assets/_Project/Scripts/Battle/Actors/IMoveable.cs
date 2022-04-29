public interface IMoveable
{
    void OnEnter(CubeCoordinate newLocation);
    void OnLeave(CubeCoordinate oldLocation);

    void OnMove(CubeCoordinate newLocation, CubeCoordinate oldLocation) {
        OnLeave(oldLocation);
        OnEnter(newLocation);
    }
}
