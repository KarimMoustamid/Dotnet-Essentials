// ══ STEP 1: Import namespaces for JSON, models, MVC
using System.Text.Json;
using GameStore.Frontend.Models;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.Frontend.Clients;

// ══ STEP 2: Define a static class for extension methods on HttpResponseMessage
public static class HttpResponseMessageExtensions
{
    // ══ STEP 3: Default error detail list used when no specific error is found
    private static readonly List<string> defaultDetail = ["Unknown error."];

    // ══ STEP 4: Main extension method to convert HTTP response into a CommandResult
    public static async Task<CommandResult> HandleAsync(this HttpResponseMessage response)
    {
        // ══ STEP 5: If the status code indicates success, return success result
        if (response.IsSuccessStatusCode)
        {
            return new CommandResult(true);
        }

        // ══ STEP 6: Read the response body as a string
        var responseContent = await response.Content.ReadAsStringAsync();

        // ══ STEP 7: If body is empty, return failure with default detail
        if (string.IsNullOrEmpty(responseContent))
        {
            return new CommandResult(false) { Errors = defaultDetail };
        }

        // ══ STEP 8: Check if the content type is not 'application/problem+json'
        if (response.Content.Headers.ContentType?.MediaType != "application/problem+json")
        {
            // If not problem JSON, treat the whole body as a single error message
            return new CommandResult(false) { Errors = [responseContent] };
        }

        // ══ STEP 9: Deserialize as ProblemDetails (RFC 7807)
        var problemDetails = JsonSerializer.Deserialize<ProblemDetails>(responseContent);
        List<string> errors = [];

        // ══ STEP 10: Extract Detail or Title from ProblemDetails
        if (!string.IsNullOrEmpty(problemDetails?.Detail))
        {
            errors.Add(problemDetails.Detail);
        }
        else if (!string.IsNullOrEmpty(problemDetails?.Title))
        {
            errors.Add(problemDetails.Title);
        }

        // ══ STEP 11: Look for structured validation errors in the "errors" extension
        if (problemDetails?.Extensions.TryGetValue("errors", out var value) == true && value is JsonElement errorsElement)
        {
            foreach (var errorEntry in errorsElement.EnumerateObject())
            {
                errors.AddRange(
                    errorEntry.Value.EnumerateArray().Select(
                        e => e.GetString() ?? string.Empty)
                    .Where(e => !string.IsNullOrEmpty(e)));
            }
        }

        // ══ STEP 12: Return failure result with collected errors, default if none found
        return new CommandResult(false) { Errors = errors.Count == 0 ? defaultDetail : errors };
    }
}
