public interface IGameFlow
{
    void PreInitialize();

    void Initialize();

    void Refresh();

    void PhysicRefresh();

    void LateRefresh();

    void Terminate();
}