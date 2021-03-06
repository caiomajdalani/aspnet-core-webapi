﻿using System;
using System.Net;
using System.Net.Http;
using Framework.Core.Helpers;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using Polly.Extensions.Http;
using Polly.Timeout;

namespace Demo.Core.Data.ApiClient.Google
{
    public static class ApiDI
    {
        /// <summary>
        /// Adiciona todas as dependências de requisições http
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddAPIRepositories(this IServiceCollection services)
        {
            services.AddSingleton(new GoogleApiConfiguration
            {
                GeoCodeURI = CommonHelpers.GetValueFromEnv<string>("GOOGLE_GEOCODE_URI"),
                MapsKey = CommonHelpers.GetValueFromEnv<string>("GOOGLE_MAPS_KEY")
            });

            var timeoutPolicy = Policy.TimeoutAsync<HttpResponseMessage>(10);


            services.AddHttpClient<GoogleMapsRepository>()
                .AddPolicyHandler(GetRetryPolicy())
                .AddPolicyHandler(timeoutPolicy);

            return services;
        }

        /// <summary>
        ///  É adicionado uma política para tentar 3 vezes com uma repetição exponencial, começando em um segundo.
        /// </summary>
        /// <returns></returns>
        static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
        {
            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .OrResult(msg => msg.StatusCode == HttpStatusCode.InternalServerError)
                .Or<TimeoutRejectedException>()
                .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(1, retryAttempt)));
        }
    }
}
