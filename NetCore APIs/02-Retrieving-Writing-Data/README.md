
## 02-Retrieving and writing data

#### 02.01 Returnig complex data

We can retrieve a List of a DTO object like this:

```C#
[HttpGet]
public IEnumerable<WeatherForecast> Get()
{
    var rng = new Random();
    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
    {
        Date = DateTime.Now.AddDays(index),
        TemperatureC = rng.Next(-20, 55),
        Summary = Summaries[rng.Next(Summaries.Length)]
    }).ToArray();
}
```
The `IEnumerable<WeatherForecast>` object returned is parsed like a JSON object and returned.


#### 02.02 Returnig IActionResult

A second approach to return something is to use `IActionResult` return type. This is a general type that indicates that this actions simply returns 'something'. 

For `IActionResult` return type we can use helpers methods like `Ok()`, `BadRequest()`, and so on... each helper method builds an valid HTTP status answer and, in addition, send encapsulate stuff like data, messages or something relative to the specific answer.

For example `Ok()` helpers method returns and HTTP status 200 and in adition returns the JSON representation of the object that receives as parameter:

```C#
[HttpGet]
public IActionResult Get()
{
    var rng = new Random();
    var objResult = Enumerable.Range(1, 5).Select(index => new WeatherForecast
    {
        Date = DateTime.Now.AddDays(index),
        TemperatureC = rng.Next(-20, 55),
        Summary = Summaries[rng.Next(Summaries.Length)]
    }).ToArray();
    return Ok(objResult);
}
```

Using `IActionResult` helps us return things like a bad request or unauthorized http status codes. In the first approach returning a complex object it's more difficult to return this http status codes.

```C#
[HttpGet("GetByGenre/{genre}")]
public IActionResult GetByGenre(string genre)
{
    if (string.IsNullOrWhiteSpace(genre))
        return BadRequest();

    IEnumerable<BookDTO> listBooks = _lib.GetByGenre(genre);
    if (listBooks == null || listBooks.Count() == 0)
        return NotFound();

    return Ok(listBooks);
}
```

*Important* Having the `[ApiController]` attribute class in our controller class will return a bas request automatically if the parameters are not valid. For example, if we have an integer argument receive by URL and we pass a string like '/controller/action/xyz' we'll receive a bad request response.

For the same request: '/controller/get/xyz' (passing an string when the action expects a integer):

If we have the code:
```C#
[HttpGet("id")]
public IActionResult Get(int id){}
```
We'll receive a bad request.

But if we have this code:
```C#
[HttpGet("id:int")]
public IActionResult Get(int id){}
```
We'll receive a 404 Not Found because the action anloy handles the integers request.


#### 02.03 Asynchronous actions

The key are the async, Task<> and await keywords.

```C#
[HttpGet]
public async Task<IEnumerable<WeatherForecast>> Get()
{
    var rng = new Random();
    return await Enumerable.Range(1, 5).Select(index => new WeatherForecast
    {
        Date = DateTime.Now.AddDays(index),
        TemperatureC = rng.Next(-20, 55),
        Summary = Summaries[rng.Next(Summaries.Length)]
    }).ToArrayAsync();
}
```


```C#
[HttpGet]
public async Task<IActionResult> Get()
{
    var rng = new Random();
    var objResult = await Enumerable.Range(1, 5).Select(index => new WeatherForecast
    {
        Date = DateTime.Now.AddDays(index),
        TemperatureC = rng.Next(-20, 55),
        Summary = Summaries[rng.Next(Summaries.Length)]
    }).ToArrayAsync();
    return Ok(objResult);
}
```


#### 02.04 HTTP Verbs

Get --> Read data.
Post --> Create data.
Put --> Update data.
Delete --> Erase data.

HEAD, OPTIONS and TRACE are other Http verbs.

Idempotency with HTTP Methods:
> An idempotent HTTP method is an HTTP method that can be called many times without different outcomes. It would not matter if the method is called only once, or ten times over. The result should be the same.

POST is NOT idempotent. Each time you execute a Post, a new record is created.
GET, PUT, DELETE, HEAD, OPTIONS and TRACE are idempotent. Once a Put is executed, the nexts executions won't change the application status.

#### 02.04 Model Binding

[FromBody] ---> Data from the body of the http request (post and put mostly)
[FromRoute] --> Data from the route: [HttpGet("{id}")] /controller/action/123
[FromQuery] --> Data from the URL: controller/action?id=123

#### 02.04 Model Validation

Using `[ApiController]` provide our API with automatic model validation (we can supress this automatic validation in the Starup.cs file, ConfigureService method).

In addition, we can use some attribute annotations in our DTO to complete validations like: [Required] or [MaxLenght(255)]