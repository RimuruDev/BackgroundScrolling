// **************************************************************** //
//
//   Copyright (c) RimuruDev. All rights reserved.
//   Contact me: 
//          - Gmail:    rimuru.dev@gmail.com
//          - GitHub:   https://github.com/RimuruDev
//          - LinkedIn: https://www.linkedin.com/in/rimuru/
//          - GitHub Organizations: https://github.com/Rimuru-Dev
//
// **************************************************************** //

using UnityEngine;
using UnityEngine.UI;

namespace RimuruDev
{
    [SelectionBase]
    [DisallowMultipleComponent]
    [RequireComponent(typeof(RawImage))]
    public sealed class BackgroundScrolling : MonoBehaviour
    {
        [SerializeField] private Vector2 scrollPositionXY;
        private RawImage rawImage;

        private void Start() =>
            rawImage = GetComponent<RawImage>();

        private void Update() =>
            SetNewRawImageUV(Time.deltaTime);

        private void SetNewRawImageUV(float delta) =>
            rawImage.uvRect = CalculateRectPosition(delta);

        private Rect CalculateRectPosition(float delta)
        {
            var offset = new Vector2(scrollPositionXY.x, scrollPositionXY.y);
            var position = rawImage.uvRect.position + offset * delta;
            var size = rawImage.uvRect.size;

            return new Rect(position, size);
        }
    }
}
