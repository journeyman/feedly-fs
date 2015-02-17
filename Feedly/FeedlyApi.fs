namespace FeedlyApi

open HttpClient
open FSharp.Data

module FeedlyApi = 

    type Opml = XmlProvider<"http://directory.opml.org/?format=opml">
    
    //dev stuff for use in sandbox, expires 2015-05-18, https://groups.google.com/forum/#!topic/feedly-cloud/YHLdeRAkn-c
    let userId = "524b9004-b2e9-47cd-ae40-132a5abee3cc"
    let accessTokenDev = "AmkimLB7ImEiOiJGZWVkbHkgRGV2ZWxvcGVyIiwiZSI6MTQzMTk4Nzk4Mzg5NCwiaSI6IjUyNGI5MDA0LWIyZTktNDdjZC1hZTQwLTEzMmE1YWJlZTNjYyIsInAiOjYsInQiOjEsInYiOiJwcm9kdWN0aW9uIiwidyI6IjIwMTMuMjciLCJ4Ijoic3RhbmRhcmQifQ:feedlydev"

    let host = "https://cloud.feedly.com" //"http://sandbox.feedly.com"
    let opmlEndpoint = host + "/v3/opml"

    let opmlRequest = 
        createRequest Get opmlEndpoint
        |> withHeader  (Authorization ("OAuth " + accessTokenDev))

    let opmlString = Option.get <| (getResponse opmlRequest).EntityBody
