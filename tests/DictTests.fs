namespace Tests
open NUnit.Framework
open FsUnit
open Perch
open System.Text

[<TestFixture>] 
type ``Dictionary tests``() =

    [<Test>] member test.
        ``Can create`` ()=
        Dict.fromSeq int32 (Enum.getValues<CustomerGender>()) 
            |> Dict.toTuples 
            |> should equal ([ 
                                (0,CustomerGender.Other)
                                (1,CustomerGender.Male)
                                (2,CustomerGender.Female)
                ])
       