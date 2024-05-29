using UnityEngine;

namespace CodeBase.Gameplay.Services
{
    public class InputService
    {
        private const string HorizontalAxisName = "Horizontal";
        private const string VerticalAxisName = "Vertical";

        public Vector3 InputAxis() => 
            new(x: Input.GetAxis(HorizontalAxisName), 
                y: 0, 
                z: Input.GetAxis(VerticalAxisName));

        public bool IsFire() => 
            Input.GetKeyDown(KeyCode.Space);
    }
}