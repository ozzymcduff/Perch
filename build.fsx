#I "packages/FAKE/tools/"
#r "FakeLib.dll"

open Fake
let libDir  = "./lib/bin/Debug/"
let testDir   = "./tests/bin/Debug/"

let appReferences  = 
    !! "lib/*.fsproj" 

let testReferences = 
    !! "tests/*.fsproj"

Target "build" (fun _ ->
    MSBuildDebug libDir "Build" appReferences 
        |> Log "LibBuild-Output: "
)
Target "build_test" (fun _ ->
    MSBuildDebug testDir "Build" testReferences 
        |> Log "LibBuild-Output: "
)

Target "test" (fun _ ->  
    !! (testDir + "/Tests*.dll")
        |> NUnit (fun p -> 
            {p with
                DisableShadowCopy = true; 
                OutputFile = testDir + "TestResults.xml"})
)

Target "install" DoNothing

"build"
    ==> "build_test"

"build_test"
    ==> "test"



RunTargetOrDefault "build"
