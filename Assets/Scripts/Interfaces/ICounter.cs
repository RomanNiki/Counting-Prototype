using Balls;

namespace Interfaces
{
    public interface ICounter
    {
        int GetCount();
        void AddBall(Ball ball);
        void RemoveBall(Ball ball);
    }
}