

To execute the API:
```dotnet run```

To access the controller:
```https://localhost:5001/weatherforecast```

See the JSON returned in a browser:

![JsonSample](ReturnedJson.JPG)

#### REST

REST stands for: 
> Representational State Transfer

Rest isn't a technology, it's a design concept. A programming paradigm built on top of HTTP. The idea is use URIs to access resources. And Rest uses HTTP to give us functionality like http verbs, or http headers.

Contrains:
 * It's uniform, so we must have one URI for each resource.
 * It's client-server: that means the client and the server are differents.
 * It's stateless
 * Can be cached.
 * Need layered system: rest it's a layer of the architecture.
 * Code on demand: you can return code that will be execute on the client (in addition to return data).