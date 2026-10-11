using AlSaad.Application.Common.Exceptions;
using AlSaad.Infrastructure.ExternalServices.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AlSaad.Infrastructure.ExternalServices.Daftra.DaftraServices
{
    public class GenericDaftraApiClientBase
    {
        protected readonly HttpClient HttpClient;

        protected static readonly JsonSerializerOptions JsonOptions = new()
        {
            NumberHandling = JsonNumberHandling.AllowReadingFromString,
            PropertyNameCaseInsensitive = true
        };
        protected static readonly JsonSerializerOptions WriteOptions = new()
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };
        static GenericDaftraApiClientBase()
        {
            JsonOptions.Converters.Add(new FlexibleDictionaryConverter());
        }
        protected GenericDaftraApiClientBase(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }
      
        protected async Task<TResponse> GetListAsync<TResponse>(string url,CancellationToken cancellationToken)
            where TResponse : new()
        {
            var response = await HttpClient.GetAsync(url, cancellationToken);
            response.EnsureSuccessStatusCode();

            //var json = await response.Content.ReadAsStringAsync(cancellationToken);
            var result = await response.Content.ReadFromJsonAsync<TResponse>(JsonOptions, cancellationToken); 
            return result ?? new TResponse();

        }
        protected async Task<TResponse?> GetSingleAsync<TResponse>(string url, CancellationToken cancellationToken)
           where TResponse : class
        {
            var response = await HttpClient.GetAsync(url, cancellationToken);

            if (response.StatusCode == HttpStatusCode.NotFound)
                return null;

            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<TResponse>(JsonOptions, cancellationToken);
        }
        protected async Task<TResponse> PostAsync<TRequest, TResponse>(
           string url, TRequest body, CancellationToken cancellationToken)
        {
            var content = JsonContent.Create(body, options: WriteOptions);
            var response = await HttpClient.PostAsync(url, content, cancellationToken);

            if (!response.IsSuccessStatusCode)
                await ThrowForErrorAsync(response, cancellationToken);

            var result = await response.Content.ReadFromJsonAsync<TResponse>(JsonOptions, cancellationToken);
            return result ?? throw new InvalidOperationException("Daftra Response is empty");
        }
        protected async Task<bool> PutAsync<TRequest>(string url, TRequest body, CancellationToken cancellationToken)
        {
            var content = JsonContent.Create(body, options: WriteOptions);
            var response = await HttpClient.PutAsync(url, content, cancellationToken);

            if (response.StatusCode == HttpStatusCode.NotFound) return false;
            if (!response.IsSuccessStatusCode) await ThrowForErrorAsync(response, cancellationToken);
            return true;
        }
        protected async Task<bool> DeleteAsync(string url, CancellationToken cancellationToken)
        {
            var response = await HttpClient.DeleteAsync(url, cancellationToken);

            if (response.StatusCode == HttpStatusCode.NotFound) return false;
            if (!response.IsSuccessStatusCode)
                await ThrowForErrorAsync(response, cancellationToken,
                    HttpStatusCode.BadRequest, HttpStatusCode.InternalServerError);
            return true;
        }

        private static async Task ThrowForErrorAsync(HttpResponseMessage response, CancellationToken cancellationToken, params HttpStatusCode[] businessErrorCodes)
        {
            var codes = businessErrorCodes.Length > 0
                ? businessErrorCodes
                : new[] { HttpStatusCode.BadRequest };

            if (codes.Contains(response.StatusCode))
            {
                var body = await response.Content.ReadAsStringAsync(cancellationToken);
                var exception = TryParseValidationError(body);
                if (exception is not null) throw exception;
            }

            response.EnsureSuccessStatusCode();
        }

        private static ExternalServiceValidationException? TryParseValidationError(string body)
        {
            if (string.IsNullOrWhiteSpace(body)) return null;

            try
            {
                using var doc = JsonDocument.Parse(body);
                var root = doc.RootElement;
                if (root.ValueKind != JsonValueKind.Object) return null;

                var errors = new List<string>();

                if (root.TryGetProperty("message", out var message)
                    && message.ValueKind == JsonValueKind.String
                    && !string.IsNullOrWhiteSpace(message.GetString()))
                    errors.Add(message.GetString()!);

                if (root.TryGetProperty("validation_errors", out var validation)
                    && validation.ValueKind == JsonValueKind.Object)
                {
                    foreach (var field in validation.EnumerateObject())
                    {
                        if (field.Value.ValueKind == JsonValueKind.Array)
                            errors.AddRange(field.Value.EnumerateArray().Select(item => $"{field.Name}: {item}"));
                        else
                            errors.Add($"{field.Name}: {field.Value}");
                    }
                }

                var isDuplicate = root.TryGetProperty("error_type", out var type)
                    && type.ValueKind == JsonValueKind.String
                    && type.GetString() == "DUPLICATED";

                int? existingId = null;
                if (isDuplicate
                    && root.TryGetProperty("extra_data", out var extra)
                    && extra.ValueKind == JsonValueKind.Object
                    && extra.TryGetProperty("id", out var idElement))
                    existingId = ReadInt(idElement);

                return new ExternalServiceValidationException(errors, isDuplicate, existingId);
            }
            catch (JsonException)
            {
                return null;
            }
        }

        private static int? ReadInt(JsonElement element) => element.ValueKind switch
        {
            JsonValueKind.Number when element.TryGetInt32(out var n) => n,
            JsonValueKind.String when int.TryParse(element.GetString(), out var s) => s,
            _ => null
        };
    }
}

