namespace Tests
open NUnit.Framework
open FsUnit
open Perch
open System.Text

[<TestFixture>] 
type ``EnumTests``() =

    [<Test>] member test.
        ``CanParse`` ()=
        (Enum.tryParse("Female") : CustomerGender option) |> should equal (Some( CustomerGender.Female))

    [<Test>] member test.
        ``Parse`` ()=
        (Enum.parse("Female") : CustomerGender) |> should equal (CustomerGender.Female)
