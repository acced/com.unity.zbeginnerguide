using UnityEngine;
using System.IO;
using System;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace ZBeginnerGuide
{
    public class ResourceManager
    {
        
        private const string EDITOR_IMAGE_PATH = "Packages/com.unity.zbeginnerguide/Resources/";
        
        /// <summary>
        /// 加载资源，根据运行环境使用不同的加载方式
        /// </summary>
        /// <param name="path">资源路径，不需要带扩展名</param>
        /// <typeparam name="T">资源类型</typeparam>
        /// <returns>资源</returns>
        public static T Load<T>(string path) where T : UnityEngine.Object
        {
            if (string.IsNullOrEmpty(path)) return null;
            
            #if UNITY_EDITOR
                // Editor环境下使用AssetDatabase
                return AssetDatabase.LoadAssetAtPath<T>($"{EDITOR_IMAGE_PATH}{path}.png");
            #else
                //Runtime环境下使用Resources
                Debug.Log($"Load {path}");
                return Resources.Load<T>(path);
             #endif
        }

        /// <summary>
        /// 加载图片资源
        /// </summary>
        /// <param name="imageName">图片名称，不需要带扩展名</param>
        /// <returns>图片精灵</returns>
        public static Sprite LoadImage(string imageName)
        {
            if (string.IsNullOrEmpty(imageName)) return null;
            #if UNITY_EDITOR
                return Load<Sprite>(imageName);
            #else
                return Load<Sprite>($"{IMAGE_PATH}{imageName}");
            #endif
        }

        /// <summary>
        /// 加载图片资源并执行回调
        /// </summary>
        public static void LoadImage(string imageName, Action<Sprite> onLoadFinish)
        {
            if (string.IsNullOrEmpty(imageName)) return;
            var sprite = LoadImage(imageName);
            onLoadFinish?.Invoke(sprite);
        }

        /// <summary>
        /// 获取Package中的资源路径
        /// </summary>
        public static string GetPackageResourcePath(string relativePath)
        {
            return $"Packages/com.unity.zbeginnerguide/{relativePath}";
        }

        /// <summary>
        /// 加载Package中的图片资源
        /// </summary>
        public static T LoadPackageResource<T>(string relativePath) where T : UnityEngine.Object
        {
            string fullPath = GetPackageResourcePath(relativePath);
            return AssetDatabase.LoadAssetAtPath<T>(fullPath);
        }
    }
}