
using MediatR;
using MediatR.Extensions.FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using POne.Core.Contracts;
using System;
using System.Reflection;

namespace POne.Api.Extensions
{
    public static class POneServiceCollectionExtensions
    {
        public static void AddPOneApi(this IServiceCollection services, Action<POneApiBuilder> configure)
        {
            var builer = new POneApiBuilder();

            configure(builer);

            var configuration = builer.Build();

            if (configuration.UowType is Type uowType)
                services.AddScoped(typeof(IUow), uowType);

            if (configuration.HandlersAssembly is Assembly handlersAssembly)
                services.AddMediatR(opts => opts.AsScoped(), handlersAssembly);

            if (configuration.ValidatorsAssembly is Assembly validatorsAssembly)
                services.AddFluentValidation(new[] { validatorsAssembly }, ServiceLifetime.Scoped);

        }
    }

    internal class POneApi
    {
        public Assembly HandlersAssembly { get; set; }
        public Assembly ValidatorsAssembly { get; set; }
        public Type UowType { get; set; }
    }

    public class POneApiBuilder
    {
        private Assembly _validatorsAssembly;
        private Assembly _handlersAssembly;
        private Type _uowType;

        public POneApiBuilder WithValidatorsFromAssemblyOf<T>()
        {
            _validatorsAssembly = typeof(T).GetTypeInfo().Assembly;
            return this;
        }

        public POneApiBuilder WithCQRSFromAssemblyOf<T>()
        {
            _handlersAssembly = typeof(T).GetTypeInfo().Assembly;
            return this;
        }

        public POneApiBuilder WithUow<T>() where T : IUow
        {
            _uowType = typeof(T);
            return this;
        }

        internal POneApi Build() => new()
        {
            HandlersAssembly = _handlersAssembly,
            ValidatorsAssembly = _validatorsAssembly,
            UowType = _uowType
        };

    }

}
