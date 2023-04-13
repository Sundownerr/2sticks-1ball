using System;
using UnityEngine;

namespace SDW.Input
{
    public interface IMobileInput
    {
        Vector2 PointerDelta { get; }
        Vector2 PointerDeltaNormalized { get; }
        Vector2 PointerPosition { get; }
        Vector2 PointerPositionNormalized { get; }
        bool IsPressed { get; }
        event Action TapStart;
        event Action TapEnd;
    }
}