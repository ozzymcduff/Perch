namespace Perch
open System.Collections.Generic
open System.Linq
open System

    module Hash =
        let fromSeq keyMap valueMap list : IDictionary<'a,'c> = 
            Enumerable.ToDictionary(list, 
                Func<'b,'a>(keyMap), Func<'b,'c>(valueMap), 
                HashIdentity.Structural) 
                    :> IDictionary<'a,'c>

        let get key (hash:IDictionary<_,_>) =
            hash.[key]
        
        let keys (hash:IDictionary<'a,_>) : 'a array =
            hash.Keys |> Seq.toArray

        let values (hash:IDictionary<_,'b>) : 'b array =
            hash.Values |> Seq.toArray

        let tryGet (key : 'a) (hash:IDictionary<'a,'b>) : 'b option =
            if hash.ContainsKey key then Some(hash.[key]) else None

        let keyValue key value =
            new KeyValuePair<_,_>(key,value)

        let toSeq (hash:IDictionary<_,_>)=
            hash :> seq<_>

        let toArray (hash:IDictionary<_,_>)=
            hash |> Seq.toArray

        let toTuples (hash:IDictionary<'a,'b>) : ('a*'b) seq =
            let toTuple (kv:KeyValuePair<'a,'b>)=
                (kv.Key,kv.Value)
            hash |> Seq.map toTuple