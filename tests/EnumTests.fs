namespace Tests
open NUnit.Framework
open FsUnit
open Perch
open System.Text

type CustomerGender = 
    |Other=0
    |Male=1
    |Female=2

[<TestFixture>] 
type ``EnumTests``() =

    [<Test>] member test.
        ``CanParse`` ()=
        (Enum.tryParse("Female") : CustomerGender option) |> should equal (Some( CustomerGender.Female))
