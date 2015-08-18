namespace Perch
open System
open System.Linq
open System.Collections

module Seq = 
    let unbox<'t> (array : IEnumerable)=
        Enumerable.Cast<'t> array 