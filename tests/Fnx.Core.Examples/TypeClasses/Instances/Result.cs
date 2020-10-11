using Fnx.Core.DataTypes;

namespace Fnx.Core.Examples.TypeClasses.Instances
{
    public class ResultDisplay<TOk, TError> : IDisplay<Result<TOk, TError>>
    {
        private readonly IDisplay<TOk> _displayOk;
        private readonly IDisplay<TError> _displayError;

        public ResultDisplay(IDisplay<TOk> displayOk, IDisplay<TError> displayError)
        {
            _displayOk = displayOk;
            _displayError = displayError;
        }

        public string Output(Result<TOk, TError> value)
        {
            return value switch
            {
                Ok<TOk, TError>(var ok) => $"Got a value of {_displayOk.Output(ok)}",
                Error<TOk, TError>(var error) => $"Sorry, {_displayError.Output(error)}"
            };
        }
    }

    public static class ResultK
    {
        public static IDisplay<Result<TOk, TError>> Display<TOk, TError>(
            IDisplay<TOk> displayOk, IDisplay<TError> displayError) =>
            new ResultDisplay<TOk, TError>(displayOk, displayError);
    }
}