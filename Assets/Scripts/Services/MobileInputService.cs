using UnityEngine;

namespace Screpts.Services
{
    public class MobileInputService : InputService
    {
        public override Vector2 Axis => SimplInputAxis();
    }
}