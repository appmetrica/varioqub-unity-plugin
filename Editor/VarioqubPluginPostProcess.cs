#if UNITY_IPHONE || UNITY_IOS
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEditor.iOS.Xcode;
using UnityEditor.iOS.Xcode.Extensions;

namespace Com.Yandex.Varioqub.Editor {
    internal static class VarioqubPluginPostProcess {

        [PostProcessBuild]
        public static void OnPostProcessBuild(BuildTarget buildTarget, string buildPath) {
            if (buildTarget != BuildTarget.iOS) return;

            string projectPath = PBXProject.GetPBXProjectPath(buildPath);
            PBXProject project = new PBXProject();
            project.ReadFromFile(projectPath);
            string mainTargetGuid = project.GetUnityMainTargetGuid();

            List<string> frameworks = new List<string> {
                "Varioqub",
                "VQSwiftProtobuf",
                "MetricaAdapterReflection"
            };

            foreach (string framework in frameworks) {
                string frameworkName = framework + ".xcframework";
                var src = Path.Combine("Pods", "Varioqub", frameworkName);
                var frameworkPath = project.AddFile(src, src);
                project.AddFileToBuild(mainTargetGuid, frameworkPath);
                project.AddFileToEmbedFrameworks(mainTargetGuid, frameworkPath);
            }

            project.WriteToFile(projectPath);
        }

    }
}
#endif
