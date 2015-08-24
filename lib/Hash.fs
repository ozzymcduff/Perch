namespace Perch
open System.Collections.Generic
open System.Linq
open System
#if net46
open System.Collections.ObjectModel
#endif

    module Hash =
        #if net46
        type Hash<'key,'value> = ReadOnlyDictionary<'key,'value>
        #else
        type Hash<'key,'value> = IDictionary<'key,'value>
        #endif

        let fromSeq keyMap valueMap list : Hash<'a,'c> = 
            let d = Enumerable.ToDictionary(list, 
                        Func<'b,'a>(keyMap), Func<'b,'c>(valueMap), 
                        HashIdentity.Structural) 
            #if net46
            Hash(d)
            #else
            d :> Hash<'a,'c>
            #endif


        let get key (hash:Hash<_,_>) =
            hash.[key]
        
        let keys (hash:Hash<'a,_>) : 'a array =
            hash.Keys |> Seq.toArray

        let values (hash:Hash<_,'b>) : 'b array =
            hash.Values |> Seq.toArray

        let tryGet (key : 'a) (hash:Hash<'a,'b>) : 'b option =
            if hash.ContainsKey key then Some(hash.[key]) else None

        let keyValue key value =
            new KeyValuePair<_,_>(key,value)

        let toSeq (hash:Hash<_,_>)=
            hash :> seq<_>

        let toArray (hash:Hash<_,_>)=
            hash |> Seq.toArray

        let toTuples (hash:Hash<'a,'b>) : ('a*'b) seq =
            let toTuple (kv:KeyValuePair<'a,'b>)=
                (kv.Key,kv.Value)
            hash |> Seq.map toTuple

        let hash = dict
