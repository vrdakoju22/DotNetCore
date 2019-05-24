# DotNetCore.AspNetCore

The package provides action results, attributes, extensions, middlewares and providers for **ASP.NET Core**.

## Attributes

### AuthorizeEnumAttribute

```cs
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
public sealed class AuthorizeEnumAttribute : AuthorizeAttribute
{
    public AuthorizeEnumAttribute(params object[] roles) { }
}
```

### RouteControllerAttribute

```cs
[AttributeUsage(AttributeTargets.Class)]
public sealed class RouteControllerAttribute : RouteAttribute
{
    public RouteControllerAttribute() : base("[controller]") { }
}
```

## Extensions

### ApplicationBuilderExtensions

```cs
public static class ApplicationBuilderExtensions
{
    public static void UseCorsAllowAny(this IApplicationBuilder application) { }

    public static void UseExceptionMiddleware(this IApplicationBuilder application, IHostingEnvironment environment) { }

    public static void UseHttps(this IApplicationBuilder application) { }

    public static void UseSpaAngularServer(this IApplicationBuilder application, IHostingEnvironment environment, string sourcePath, string npmScript) { }

    public static void UseSpaProxyServer(this IApplicationBuilder application, IHostingEnvironment environment, string sourcePath, string baseUri) { }

    public static void UseSwaggerDefault(this IApplicationBuilder application) { }

    public static void ConfigureFormOptions(this IServiceCollection services) { }
}
```

### HttpRequestExtensions

```cs
public static class HttpRequestExtensions
{
    public static IList<FileBinary> Files(this HttpRequest request) { }
}
```

### HostingEnvironmentExtensions

```cs
public static class HostingEnvironmentExtensions
{
    public static IConfiguration Configuration(this IHostingEnvironment environment) { }
}
```

### ServiceCollectionExtensions

```cs
public static class ServiceCollectionExtensions
{
    public static AuthenticationBuilder AddAuthenticationJwtBearer(this IServiceCollection services) { }

    public static IDataProtectionBuilder AddDataProtectionService(this IServiceCollection services) { }

    public static void AddFileService(this IServiceCollection services) { }

    public static IMvcBuilder AddMvcDefault(this IServiceCollection services) { }

    public static void AddSpaStaticFiles(this IServiceCollection services, string rootPath) { }

    public static void AddSwaggerDefault(this IServiceCollection services) { }
}
```

## Middlewares

### ExceptionMiddleware

It centralizes exception handling and saves logs.

## Results

### DefaultResult

```cs
public class DefaultResult : IActionResult
{
    public DefaultResult(IResult result) { }

    public async Task ExecuteResultAsync(ActionContext context) { }
}
```

## Services

### IFileService

```cs
public interface IFileService
{
    string GetContentType(string path);
}
```

### FileService

```cs
public class FileService
{
    public string GetContentType(string path) { }
}
```

### IDataProtectionService

```cs
public interface IDataProtectionService
{
    string Hash(string value);

    string Protect(string value);

    string Unprotect(string value);
}
```

### DataProtectionService

```cs
public class DataProtectionService : IDataProtectionService
{
    public DataProtectionService(IDataProtectionProvider provider) { }

    public string Hash(string value) { }

    public string Protect(string value) { }

    public string Unprotect(string value) { }
}
```
