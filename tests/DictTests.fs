namespace Tests
open NUnit.Framework
open FsUnit
open Perch

[<TestFixture>] 
type ``Dictionary tests``() =

    let customerGenders = Enum.getValues<CustomerGender>()

    [<Test>] member test.
        ``Can create`` ()=
        Dict.fromSeq int32 customerGenders 
            |> Dict.toTuples 
            |> should equal ([ 
                                (0,CustomerGender.Other)
                                (1,CustomerGender.Male)
                                (2,CustomerGender.Female)
                ])
    [<Test>] member test.
        ``tryGet`` ()=
        (Dict.fromSeq int32 customerGenders)
            |> Dict.tryGet 0
            |> should equal (Some(CustomerGender.Other))

    [<Test>] member test.
        ``get`` ()=
        Dict.fromSeq int32 (Enum.getValues<CustomerGender>()) 
            |> Dict.get 1
            |> should equal CustomerGender.Male