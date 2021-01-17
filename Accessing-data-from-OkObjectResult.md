# Accessing data from OkObjectResult

Someone asked, "When I get the data from my controller it's of type OkObjectResult. I can successfully make an assertion of this fact. However, when I try to access the data with result.Value it does not work." I understood some of the actual context of this and the fact that the controller is returning IActionResult.

Anyway, I don't spend a lot of time these days building APIs so I don't have any of this internalized or memorized. So my first step was to understand the problem to form a hypothesis that I can test. So I focused on "accessing data from OkObjectResult" as my problem. So, I searched for accessing data from OkObjectResult.

https://www.google.com/search?q=accessing+data+from+OkObjectResult

This lead me to an answer [Stackoverflow](https://stackoverflow.com/questions/39378873/how-to-get-content-value-in-xunit-when-result-returned-in-iactionresult-type) that spoke on getting content value from IActionResult. The important clue was that we have to cast the results to the expected type. So, if I am expecting a Contact object in the result, my hypothesis is "to access data from OkObjectResult, I can cast the results to the type of data I am expecting."

When I am trying to understand how some code should work I usually want documentation on the code and a way to trace through or step through calls so I can see what the code is doing. I've found that I get this when I write a test. I get IntelliSense that provide a little documentation and at the least the basic specs on classes, method calls, and return types. With a test I also get a way to step through the code if I run the test with debugging.

So, I created a test to test my hypothesis. I setup to call my controller and assign the result to a variable. I ran the test and inspected the return type of the controller.

To get a little more understanding on the return type, I pulled up some docs from Microsoft, https://docs.microsoft.com/en-us/aspnet/core/web-api/action-return-types?view=aspnetcore-5.0. Reading this, I see that IActionResult may not be the best return type. Because the controller is just returning a plain csharp object it may be better to just return the strongly typed object. I digress, but there are examples in my [GitHub repo](https://github.com/charleslbryant/dotnet-jumpstart) that just return specific types from the controller, no need to jump through hoops unless you need the hoops.

To round out my return type research I read https://exceptionnotfound.net/asp-net-core-demystified-action-results/. This gave a little bit more color on action results.

With my research complete I took the results of my controller call and cast it to an OkObjectResult. This succeeded because OkObjectResult is a type of IActionResult. Now I can get the Value property of the OkObjectResult and cast it to my expected type. Finally, I can assert the expected values. You can see an example of this on my GetContactById test in my [GitHub repo](https://github.com/charleslbryant/dotnet-jumpstart).