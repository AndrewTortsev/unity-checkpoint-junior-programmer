using UnityEngine;
namespace RunnerApi
{
    public interface Controlable
    {
        void Move(Vector3 direction);

        void Jump();

        void CrouchRoll(Vector3 direction);
    }
}
