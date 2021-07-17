//using Live2D.Cubism.Core;
//using Live2D.Cubism.Framework.Json;
//using Live2D.Cubism.Framework.Motion;
//using Live2D.Cubism.Framework.MotionFade;
//using System;
//using System.IO;
//using System.Threading.Tasks;
//using UnityEngine;
//using UnityEngine.AddressableAssets;

//namespace Live2DTest
//{
//    public class Live2DBehaviour : MonoBehaviour
//    {
//        // Start is called before the first frame update
//        void Start()
//        {
//            _ = ShowModelAsync();
//        }

//        private async Task ShowModelAsync()
//        {
//            var model = await LoadModelAsync();
//            await InitializeModel(model);
//        }

//        private async Task<CubismModel> LoadModelAsync()
//        {
//            var directtoryPath = Application.dataPath + "/Live2DMaterials/momosehiyori_import/";

//            // モデル読み込み
//            //var model3JsonPath = directtoryPath + "桃瀬ひより_インポート_チュートリアル2_4.model3.json";
//            //"Assets/Live2DMaterials/momosehiyori_import/桃瀬ひより_インポート_チュートリアル2_4.model3.json"
//            var model3JsonPath = "Assets/Live2DMaterials/momosehiyori_import/桃瀬ひより_インポート_チュートリアル2_4.model3.json";
//            //var textAsset = await Addressables.LoadAssetAsync<TextAsset>(model3JsonPath).Task;
//            var modelJson = CubismModel3Json.LoadAtPath(model3JsonPath, BuiltInLoadAssetAtPath);
//            return modelJson.ToModel();
//        }

//        private async Task InitializeModel(CubismModel model)
//        {
//            var animationClipKey = "Assets/Live2DMaterials/momosehiyori_import/Scene1.anim";
//            var animationClip = await Addressables.LoadAssetAsync<AnimationClip>(animationClipKey).Task;

//            var scale = new Vector3(10, 10, 1);
//            var pos = new Vector3(0, -2, 0);
//            model.transform.localScale = scale;
//            model.transform.localPosition = pos;

//            // スクリプトでアニメーションさせる場合、CubismMotionControllerが必要。
//            // CubismMotionControllerはCubismFadeControllerに依存している。
//            // CubismFadeController.CubismFadeMotionListはモデルをインポートした際に生成されてるので、それを利用する。
//            var fadeMotionListKey = "Assets/Live2DMaterials/Live2DMaterials.fadeMotionList.asset";
//            var fadeMotionList = await Addressables.LoadAssetAsync<CubismFadeMotionList>(fadeMotionListKey).Task;

//            var fadeController = model.gameObject.GetComponent<CubismFadeController>() ?? model.gameObject.AddComponent<CubismFadeController>();
//            fadeController.CubismFadeMotionList = fadeMotionList;

//            var motionController = model.gameObject.AddComponent<CubismMotionController>();
//            motionController.PlayAnimation(animationClip);

//            // Animator と、スクリプトでアニメーションさせる CubismMotionControllerは競合する。
//        }

//        private static object BuiltInLoadAssetAtPath(Type assetType, string absolutePath)
//        {
//            if (assetType == typeof(byte[])) return File.ReadAllBytes(absolutePath);
//            if (assetType == typeof(string)) return File.ReadAllText(absolutePath);
//            if (assetType == typeof(Texture2D))
//            {
//                var texture = new Texture2D(1, 1);
//                texture.LoadImage(File.ReadAllBytes(absolutePath));

//                return texture;
//            }

//            throw new NotSupportedException();
//        }

//        // Update is called once per frame
//        void Update()
//        {

//        }
//    }
//}

