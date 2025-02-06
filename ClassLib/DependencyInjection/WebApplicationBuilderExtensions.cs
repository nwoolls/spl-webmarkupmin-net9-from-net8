using System.IO.Compression;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using WebMarkupMin.AspNet.Common.Compressors;
using WebMarkupMin.AspNetCoreLatest;

namespace ClassLib.DependencyInjection;

public static class WebApplicationBuilderExtensions
{
    public static WebApplicationBuilder AddMarkupOptimization(this WebApplicationBuilder webApplicationBuilder)
    {
        IServiceCollection services = webApplicationBuilder.Services;

        WebMarkupMinServicesBuilder builder = services.AddWebMarkupMin();

        builder.AddHtmlMinification();
        builder.AddXhtmlMinification();
        builder.AddXmlMinification();

        builder.AddHttpCompression(options =>
        {
            var brotliCompressionSettings = new BuiltInBrotliCompressionSettings
            {
                Level = CompressionLevel.Optimal
            };
            var brotliCompressorFactory = new BuiltInBrotliCompressorFactory(brotliCompressionSettings);
            options.CompressorFactories.Insert(0, brotliCompressorFactory);
        });

        return webApplicationBuilder;
    }
}