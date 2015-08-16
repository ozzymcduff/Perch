namespace Tests
open NUnit.Framework
open FsUnit
open Perch

type Case = 
    |Null=0
    |None=1
    |Some=2
    |Other=3

[<TestFixture>] 
type ``Option UnionCase can identify type``() =

    let whatCase (value: obj)=
        match value with
            | null -> Case.Null
            | Option.UnionCase <@ None @> _ -> Case.None
            | Option.UnionCase <@ Some @> _ -> Case.Some
            | _ -> Case.Other

    let whatCase' (value: obj)=
        match value with
            | Option.UnionCase <@ None @> _ -> Case.None
            | Option.UnionCase <@ Some @> _ -> Case.Some
            | null -> Case.Null
            | _ -> Case.Other


    [<Test>] member test.
        ``Some`` ()=
             whatCase (Some(1)) |> should equal Case.Some

    [<Test>] member test.
        ``None should not be matched since there is a null case above`` ()=
             whatCase (None) |> should equal Case.Null

    [<Test>] member test.
        ``None`` ()=
             whatCase' (None) |> should equal Case.None

    [<Test>] member test.
        ``Null`` ()=
             whatCase (null) |> should equal Case.Null

    [<Test>] member test.
        ``Null should not be matched since there is a none case above`` ()=
             whatCase' (null) |> should equal Case.None

    [<Test>] member test.
        ``Other`` ()=
             whatCase (1) |> should equal Case.Other

[<TestFixture>] 
type ``Option UnionCase can pick out value``() =
    let valueOf (value: obj)=
        match value with
            | null -> None
            | Option.UnionCase <@ None @> [] -> None
            | Option.UnionCase <@ Some @> [v] ->Some(v)
            | _ as v -> Some(v)

    [<Test>] member test.
        ``Some`` ()=
             valueOf (Some(1)) |> should equal (Some(box 1))

    [<Test>] member test.
        ``Other`` ()=
             valueOf (1) |> should equal (Some(box 1))

type AUnionType=
    | A
    | B of string
    | C of string*string
    | Other

[<TestFixture>] 
type ``Option UnionCase can pick out values``() =
    let valueOf (value: obj)=
        match value with
            | Option.UnionCase <@ AUnionType.A @> _ -> AUnionType.A
            | Option.UnionCase <@ AUnionType.B @> [v] -> AUnionType.B(v :?> string) 
            | Option.UnionCase <@ AUnionType.C @> [a;b] -> AUnionType.C(a :?> string, b :?> string) 
            | _ as v -> AUnionType.Other

    [<Test>] member test.
        ``Without any fields`` ()=
             valueOf (AUnionType.A) |> should equal (box AUnionType.A)


    [<Test>] member test.
        ``With one field`` ()=
             valueOf (AUnionType.B("1")) |> should equal (box (AUnionType.B("1")))

    [<Test>] member test.
        ``With two fields`` ()=
             valueOf (AUnionType.C("1","2")) |> should equal (box (AUnionType.C("1","2"))) 