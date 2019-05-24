# DotNetCore.Objects

The package provides generic classes for **objects**.

## FileBinary

```cs
public class FileBinary
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public byte[] Bytes { get; set; }

    public string ContentType { get; set; }

    public long Length { get; set; }
}
```

## Order

```cs
public class Order
{
    public Order() { }

    public Order(string property, bool ascending) { }

    public bool Ascending { get; set; }

    public string Property { get; set; }
}
```

## Page

```cs
public class Page
{
    public Page() { }

    public Page(int index, int size) { }

    public int Index { get; set; }

    public int Size { get; set; }
}
```

## PagedListParameters

```cs
public class PagedListParameters
{
    public PagedListParameters() { }

    public PagedListParameters(Order order) { }

    public PagedListParameters(Page page) { }

    public PagedListParameters(Order order, Page page) { }

    public PagedListParameters(string property, bool ascending) { }

    public PagedListParameters(int index, int size) { }

    public PagedListParameters(string property, bool ascending, int index, int size) { }

    public Order Order { get; set; }

    public Page Page { get; set; }
}
```

## PagedList

The **PagedList\<T\>** class performs the sort and pagination logic, and return the total count and the paged list.

```cs
public class PagedList<T>
{
    public PagedList(IQueryable<T> queryable, PagedListParameters parameters) { }

    public long Count { get; }

    public IEnumerable<T> List { get; }
}
```

## IResult

```cs
public interface IResult
{
    string Message { get; }

    bool Success { get; }
}
```

## Result

```cs
public class Result : IResult
{
    public Result(bool success, string message) : this(success) { }

    public Result(bool success) { }

    public string Message { get; }

    public bool Success { get; }

    public Task<IResult> ToTask() { }
}
```

## SuccessResult

```cs
public sealed class SuccessResult : Result
{
    public SuccessResult(string message) : base(true, message) { }

    public SuccessResult() : base(true) { }
}
```

## ErrorResult

```cs
public sealed class ErrorResult : Result
{
    public ErrorResult(string message) : base(false, message) { }

    public ErrorResult() : base(false) { }
}
```

## IDataResult

```cs
public interface IDataResult<out T> : IResult
{
    T Data { get; }
}
```

## DataResult

```cs
public class DataResult<T> : Result, IDataResult<T>
{
    public DataResult(T data, bool success, string message) : base(success, message) { }

    public DataResult(T data, bool success) : base(success) { }

    public T Data { get; }

    public new Task<IDataResult<T>> ToTask() { }
}
```

## ErrorDataResult

```cs
public sealed class ErrorDataResult<T> : DataResult<T>
{
    public ErrorDataResult(T data, string message) : base(data, false, message) { }

    public ErrorDataResult(T data) : base(data, false) { }

    public ErrorDataResult(string message) : base(default, false, message) { }

    public ErrorDataResult() : base(default, false) { }
}
```

## SuccessDataResult

```cs
public sealed class SuccessDataResult<T> : DataResult<T>
{
    public SuccessDataResult(T data, string message) : base(data, true, message) { }

    public SuccessDataResult(T data) : base(data, true) { }

    public SuccessDataResult(string message) : base(default, true, message) { }

    public SuccessDataResult() : base(default, true) { }
}
```

## Examples

```cs
var resultFalse = new Result(false);

var resultFalseMessage = new Result(false, "Error");

var dataResultFalse = new DataResult<object>(default, false);

var dataResultFalseMessage = new DataResult<object>(default, false, "Error");

var errorResult = new ErrorResult();

var errorResultMessage = new ErrorResult("Error");

var errorDataResult = new ErrorDataResult<object>(default);

var errorDataResultMessage = new ErrorDataResult<object>(default, "Error");

var resultTrue = new Result(true);

var resultTrueMessage = new Result(true, "Success");

var dataResultTrue = new DataResult<object>(default, true);

var dataResultTrueMessage = new DataResult<object>(default, true, "Success");

var successResult = new SuccessResult();

var successResultMessage = new SuccessResult("Success");

var successDataResult = new SuccessDataResult<object>(default);

var successDataResultMessage = new SuccessDataResult<object>(default, "Success");
```
