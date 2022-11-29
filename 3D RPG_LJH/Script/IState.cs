public interface IState
{
    void Enter(Boss parent);

    void Update();

    void Exit();
}



