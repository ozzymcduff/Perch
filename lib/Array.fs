namespace Perch
open System
open System.Linq

module Array = 
    let unbox<'t> (array : Array)=
        Enumerable.Cast<'t> array |> Seq.toArray
