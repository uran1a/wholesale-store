using WholesaleStore.Common.Validator;
using WholesaleStore.Common.Helpers;
using FluentValidation.AspNetCore;

namespace WholesaleStore.Api.Configuration;

public static class ValidatorConfiguration
{
    public static IServiceCollection AddAppValidator(this IServiceCollection services)
    {
        services.AddFluentValidationAutoValidation(opt => { opt.DisableDataAnnotationsValidation = true; });

        FluentValidatorHelper.Register(services);

        services.AddSingleton(typeof(IModelValidator<>), typeof(ModelValidator<>));

        return services;
    }
}
