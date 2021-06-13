using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.HttpOverrides;

namespace AirportDistance.Infrastructure.Extensions.ApplicationBuilder {
    public static class ForwardHeadersExtensions {
        /// <summary>
        ///     Enables support for headers X-FORWARDED-FOR and X-FORWARDED-PROTO
        /// </summary>
        /// <param name="applicationBuilder"></param>
        public static void UseCustomForwardHeaders(this IApplicationBuilder applicationBuilder) {
            var forwardOptions = new ForwardedHeadersOptions {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto,
                RequireHeaderSymmetry = false
            };

            forwardOptions.KnownNetworks.Clear();
            forwardOptions.KnownProxies.Clear();

            // ref: https://github.com/aspnet/Docs/issues/2384
            applicationBuilder.UseForwardedHeaders(forwardOptions);
        }
    }
}