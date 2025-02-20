using UnityEditor;
using UnityEngine;

namespace ZBeginnerGuide
{
    public class GuideMenu
    {
        [MenuItem("ZBeginnerGuide/Create Beginner Guide", false, 55)]
        public static void AddList()
        {
            Debug.Log("Create Beginner Guide");
            
            // 通过路径加载
            var circleFill = ResourceManager.LoadPackageResource<Sprite>("Image/beginnerguide_atlas/CircleFill.png");
            if (circleFill != null)
            {
                Debug.Log($"成功加载图片: {circleFill.name}");
            }
        }
    }
}
    