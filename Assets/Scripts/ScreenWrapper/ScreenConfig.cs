using UnityEngine;

namespace Asteroids.ScreenWrapper
{
    public static class ScreenConfig
    {
        public static Vector3 ScreenLeft { get; private set; }
        public static Vector3 ScreenRight { get; private set; }
        public static Vector3 ScreenTop { get; private set; }
        public static Vector3 ScreenButtom { get; private set; }
        public static Vector3 ScreenCenter => Vector3.zero;
    
        public static void Initialize()
        {
            ScreenLeft = Camera.main.ViewportToWorldPoint(new Vector3(0f, 0.5f));
            ScreenRight = Camera.main.ViewportToWorldPoint(new Vector3(1f, 0.5f));
            ScreenTop = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0f));
            ScreenButtom = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 1f));
        }
    }
}
