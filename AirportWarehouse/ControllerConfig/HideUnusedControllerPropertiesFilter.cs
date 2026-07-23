using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.OpenApi.Models;
using NSwag.Generation.AspNetCore;
using NSwag.Generation.Processors;
using NSwag.Generation.Processors.Contexts;

namespace AirportWarehouse.ControllerConfig;

public class HideUnusedControllerPropertiesFilter : IOperationProcessor
{
    public bool Process(OperationProcessorContext context)
    {
        var actionOptsIn = context.MethodInfo
                          .GetCustomAttributes(typeof(UsesControllerQueryFilterAttribute), inherit: true)
                          .Length != 0;
        if (actionOptsIn) return true;

        if (context is not AspNetCoreOperationProcessorContext aspCotext)
            return true;

        var controllerPropertyParamsNames = aspCotext.ApiDescription.ParameterDescriptions
            .Where(p => p.ModelMetadata?.ContainerType == context.ControllerType)
            .Select(p => p.Name)
            .ToList();
        if (controllerPropertyParamsNames.Count == 0) return true;

        var operation = context.OperationDescription.Operation;

        foreach (var paramName in controllerPropertyParamsNames)
        {
            var param = operation.Parameters.FirstOrDefault(p => p.Name == paramName);
            if (param is not null)
                operation.Parameters.Remove(param);
            
        }

        return true;

    }
}
