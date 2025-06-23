// ReSharper disable InconsistentNaming
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BudgetApp.Services;

/// <remarks>
/// Add JavaScript code to "wwwroot/scripts". Be sure to link the script in "wwwroot/index.html".
/// </remarks>
public class JSInteropComponent<TComponent> : ComponentBase, IDisposable where TComponent : class
{
    [Inject] private IJSRuntime? JSRuntime { get; set; }

    private DotNetObjectReference<TComponent>? _dotNetObjectReference;

    protected async Task InvokeJSFunctionWithCallbackAsync(
        TComponent componentInstance, string jsFunctionName, string callbackFunctionName)
    {
        _dotNetObjectReference ??= DotNetObjectReference.Create(componentInstance);

        if (JSRuntime is not null)
            await JSRuntime.InvokeVoidAsync(jsFunctionName, _dotNetObjectReference, callbackFunctionName);
    }

    /// <remarks>
    /// The DotNetObjectReference used for JSInterop must be disposed to prevent a memory leak.
    /// See <see href="https://learn.microsoft.com/en-us/aspnet/core/blazor/javascript-interoperability/call-dotnet-from-javascript?view=aspnetcore-3.1#pass-a-dotnetobjectreference-to-an-individual-javascript-function">Microsoft's article</see>.
    /// </remarks>
    public void Dispose()
    {
        _dotNetObjectReference?.Dispose();
    }
}