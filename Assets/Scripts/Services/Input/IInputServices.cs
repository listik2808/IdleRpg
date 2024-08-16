using Scripts.Infrastructure.Services;
using UnityEngine;

namespace Screpts.Services.Input
{
    public interface IInputServices : IService
    {
        Vector2 Axis { get; }
    }

     public abstract class InputService : IInputServices
     {
        protected const string Horizontal = "Horizontal";
        protected const string Vertical = "Vertical";

        public abstract Vector2 Axis { get; }

        protected static Vector2 SimplInputAxis() =>
            new Vector2(SimpleInput.GetAxis(Horizontal), SimpleInput.GetAxis(Vertical));
     }
}