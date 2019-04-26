using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;

namespace Forte.Functions.Testable.Tests.InMemoryOrchestration.TestFunctions
{
    public partial class Funcs
    {
        [FunctionName(nameof(DurableFunctionWithTimer))]
        public static async Task DurableFunctionWithTimer(
            [OrchestrationTrigger] DurableOrchestrationContextBase context)
        {
            var input = context.GetInput<DurableFunctionWithTimerInput>();
            await context.CreateTimer(context.CurrentUtcDateTime.Add(input.Timer), CancellationToken.None);
        }
    }

    public class DurableFunctionWithTimerInput
    {
        public DurableFunctionWithTimerInput(TimeSpan timer)
        {
            Timer = timer;
        }

        public TimeSpan Timer { get; }
    }
}