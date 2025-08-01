/*
* Tencent is pleased to support the open source community by making Puerts available.
* Copyright (C) 2020 Tencent.  All rights reserved.
* Puerts is licensed under the BSD 3-Clause License, except for the third-party components listed in the file 'LICENSE' which may be subject to their corresponding license terms. 
* This file is subject to the terms and conditions defined in file 'LICENSE', which is part of this source code package.
*/

using System;
using System.IO;
using UnrealBuildTool;

public class DeclarationGenerator : ModuleRules 
{
    public DeclarationGenerator(ReadOnlyTargetRules Target) : base(Target) 
    {
        PublicIncludePaths.AddRange(
            new string[] {
                "Programs/UnrealHeaderTool/Public",
            }
        );
        PublicDependencyModuleNames.AddRange(
            new string[]
            {
                "Core",
                "CoreUObject",
                "UMG",
                "UnrealEd",
                "LevelEditor",
                "Engine",
                "Slate",
                "SlateCore",
                "EditorStyle",
                "InputCore",
                "Projects",
                "JsEnv",
                "Puerts",
#if UE_5_0_OR_LATER
                "ToolMenus",
#endif
            }
        );

        if (Target.Platform == UnrealTargetPlatform.Win64 ||Target.Platform == UnrealTargetPlatform.Mac)
        {
            PublicDependencyModuleNames.AddRange(
                new string[]
                {
                    "AssetRegistry"
                }
            );
        }
        
        if (JsEnv.WithSourceControl)
        {
            PrivateDependencyModuleNames.Add("PuertsEditor");
        }

        //PublicDefinitions.Add(string.Format("DECL_OUTPUT_PATH={0}", Path.GetFullPath(Path.Combine(ModuleDirectory, "..", "..", "Content", "Scripts"))));
    }
}
