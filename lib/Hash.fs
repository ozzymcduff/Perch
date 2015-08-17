namespace Perch
open System.Collections.Generic
open System.Linq

    module Hash =
        let fromSeq map list : IDictionary<'a,'b> = 
            Enumerable.ToDictionary(list, System.Func<'b,'a>(map), System.Func<'b,'b>(id), HashIdentity.Structural) 
                :> IDictionary<'a,'b>

        let get key (hash:IDictionary<_,_>) =
            hash.[key]
        
        let keys (hash:IDictionary<'a,_>) : 'a array =
            hash.Keys |> Seq.toArray

        let values (hash:IDictionary<_,'b>) : 'b array =
            hash.Values |> Seq.toArray

        let tryGet (key : 'a) (hash:IDictionary<'a,'b>) : 'b option =
            if hash.ContainsKey key then Some(hash.[key]) else None

        let toTuples (hash:IDictionary<'a,'b>) : ('a*'b) seq =
            let toTuple (kv:KeyValuePair<'a,'b>)=
                (kv.Key,kv.Value)
            hash |> Seq.map toTuple