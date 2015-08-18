namespace Tests
open NUnit.Framework
open FsUnit
open Perch

[<TestFixture>] 
type ``Hash tests``() =

    let customerGenders = Enum.getValues<CustomerGender>()

    [<Test>] member test.
        ``Can create`` ()=
        Hash.fromSeq int32 id customerGenders 
            |> Hash.toTuples 
            |> should equal ([ 
                                (0,CustomerGender.Other)
                                (1,CustomerGender.Male)
                                (2,CustomerGender.Female)
                ])
    [<Test>] member test.
        ``tryGet`` ()=
        (Hash.fromSeq int32 id customerGenders)
            |> Hash.tryGet 0
            |> should equal (Some(CustomerGender.Other))

    [<Test>] member test.
        ``get`` ()=
        Hash.fromSeq int32 id (Enum.getValues<CustomerGender>()) 
            |> Hash.get 1
            |> should equal CustomerGender.Male