using UnityEngine;

namespace Screpts.Services.Input
{
    public class MobileInputService : InputService
    {
        public override Vector2 Axis => SimplInputAxis();
    }
}