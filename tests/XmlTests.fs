namespace Tests
open NUnit.Framework
open FsUnit
open Perch
open System.Text

[<TestFixture>] 
type ``XElem enum``() =
    let t = XName.Simple("t")

    [<Test>] member test.
        ``XElem.value Female`` ()=
        XElem.value t (CustomerGender.Female) 
            |> XElem.valueOf
            |> should equal (CustomerGender.Female.ToString())
    [<Test>] member test.
        ``XElem.value Some Female`` ()=
        XElem.value t (Some(CustomerGender.Female))
            |> XElem.valueOf
            |> should equal (CustomerGender.Female.ToString())
    [<Test>] member test.
        ``XElem.value None`` ()=
        XElem.value t (None) 
            |> XElem.valueOf
            |> should equal null
    [<Test>] member test.
        ``XElem.value Null`` ()=
        XElem.value t (null) 
            |> XElem.valueOf
            |> should equal null

[<TestFixture>] 
type ``XElem enum2``() =
    let xml = Xml.parse "<Customer><Name>Test</Name></Customer>"

    [<Test>] member test.
        ``XElem.withName Name value of`` ()=
        XElem.withName xml.Root (XName.Simple("Name")) 
            |> XElem.valueOf
            |> should equal ("Test")