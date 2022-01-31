using UnityEngine;

namespace Asteroids.ScreenWrapper
{
    public class ScreenWrapper : MonoBehaviour
    {
        [SerializeField]
        private Transform parentToWrap;

        private void OnBecameInvisible()
        {
            Vector3 position = parentToWrap.position;
            if (position.x <= ScreenConfig.ScreenLeft.x || position.x >= ScreenConfig.ScreenRight.x)
                position.x = 2 * ScreenConfig.ScreenCenter.x - position.x;
            if (position.y <= ScreenConfig.ScreenButtom.y || position.y >= ScreenConfig.ScreenTop.y)
                position.y = 2 * ScreenConfig.ScreenCenter.y - position.y;

            parentToWrap.position = position;
        }
    }
}