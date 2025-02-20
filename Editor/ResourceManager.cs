using UnityEngine;
using System.IO;
using System;
using UnityEditor;

namespace ZBeginnerGuide
{
    public class ResourceManager
    {
        /// <summary>
        /// 资源加载接口,用于加载Package内的资源
        /// </summary>
        /// <param name="path">相对于Assets的路径，需要带扩展名</param>
        /// <typeparam name="T">资源类型</typeparam>
        /// <returns>资源</returns>
        public static T Load<T>(string path) where T : UnityEngine.Object
        {
            if (string.IsNullOrEmpty(path)) return null;
            return AssetDatabase.LoadAssetAtPath<T>(path);
        }

        /// <summary>
        /// 同步加载资源并执行回调
        /// </summary>
        public static void Load<T>(string path, Action<T> onLoadFinish) where T : UnityEngine.Object
        {
            if (string.IsNullOrEmpty(path)) return;
            var asset = AssetDatabase.LoadAssetAtPath<T>(path);
            onLoadFinish?.Invoke(asset);
        }
    }
}