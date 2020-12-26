using UnityEditor;
using UnityEngine;
using UnityEditor.Build.Reporting;

public class BuildClass
{
    public static void Build()
    {
        // ビルド対象シーンリスト
        string[] sceneList = {
            "./Assets/Scene/SampleScene.unity"
        };
        
        string[] args = System.Environment.GetCommandLineArgs();
        var outputPath = string.Empty;
        for (int i = 0; i < args.Length; ++i)
        {
            switch (args[i])
            {
                case "/output_path":
                    outputPath = args[i + 1];
                    break;
            }
        }

        // 実行
        var result = BuildPipeline.BuildPlayer(sceneList, outputPath, BuildTarget.WebGL, BuildOptions.None);
        var resultType = result.summary.result;
        var steps = result.steps;

        switch (resultType)
        {
            case BuildResult.Unknown:
            case BuildResult.Failed:
                Debug.LogError("[Error!]");
                foreach (var step in steps)
                {
                    foreach (var message in step.messages)
                    {
                        switch (message.type)
                        {
                            case LogType.Log:
                            case LogType.Warning:
                                break;
                            case LogType.Assert:
                                Debug.LogAssertion("[Assertion!] " + message.content);
                                break;
                            case LogType.Error:
                            case LogType.Exception:
                                Debug.LogError("[Error!]" +  message.content);
                                break;
                        }
                    }
                }
                break;
            case BuildResult.Cancelled:
                Debug.Log("[Cancelled!] ");
                break;
            case BuildResult.Succeeded:
                Debug.Log("[Success!]");
                break;
        }
    }
}