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
        }
    }
    
}
    