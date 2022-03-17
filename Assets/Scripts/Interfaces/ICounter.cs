using Balls;

namespace Interfaces
{
    public interface ICounter
    {
        void AddBallInBox(Ball ball);
        void RemoveBallFromBox(Ball ball);
    }
}