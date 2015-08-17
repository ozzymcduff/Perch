namespace Tests
open NUnit.Framework
open FsUnit
open Perch
open System.Text

[<TestFixture>] 
type ``XElem``() =
    let t = XName.Simple("t")
    let xml = Xml.parse "<Customer><Name>Test</Name></Customer>"

    [<Test>] member test.
        ``XElem.value Female`` ()=
        XElem.value t (CustomerGender.Female) 
            |> XElem.valueOf
            |> should equal (CustomerGender.Female.ToString())
    [<Test>] member test.
        ``XElem.value Female?`` ()=
        XElem.value t ( "Female" )
            |> XElem.valueOf
            |> should equal ("Female")
    [<Test>] member test.
        ``XElem.value Female = null`` ()=
        XElem.value t ( null )
            |> XElem.valueOf
            |> should equal (null)
    [<Test>] member test.
        ``XElem.value Some Female`` ()=
        XElem.optionValue t (Some(CustomerGender.Female))
            |> XElem.valueOf
            |> should equal (CustomerGender.Female.ToString())
    [<Test>] member test.
        ``XElem.value None`` ()=
        XElem.optionValue t (None) 
            |> XElem.valueOf
            |> should equal null
    [<Test>] member test.
        ``XElem.value Null`` ()=
        XElem.value t (null) 
            |> XElem.valueOf
            |> should equal null
    [<Test>] member test.
        ``XElem.withName Name value of`` ()=
            xml.Root 
            |> XElem.withName (XName.Simple("Name")) 
            |> XElem.valueOf
            |> should equal ("Test")