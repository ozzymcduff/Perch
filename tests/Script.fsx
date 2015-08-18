// Learn more about F# at http://fsharp.org. See the 'F# Tutorial' project
// for more guidance on F# programming.

#load "../lib/Enum.fs"
#load "../lib/Hash.fs"

#r "System.Xml.Linq.dll"
#load "../lib/Xml.fs"
open Perch

// Define your library scripting code here

// [] |> Array.head
let x = [| 1 |] in
     x |> Seq.head |> ignore

let y = [ 1 ] in
     y |> Seq.head |> ignore

let y = [ 1 ] in
     y |> List.head |> ignore

let y = [ 1 ] in
     y |> List.head |> ignore
