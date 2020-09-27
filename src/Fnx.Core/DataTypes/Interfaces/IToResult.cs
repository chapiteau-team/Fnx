using System;

namespace Fnx.Core.DataTypes.Interfaces
{
    public interface IToResult<TOk>
    {
        Result<TOk, TError> ToResult<TError>(TError error);

        Result<TOk, TError> ToResult<TError>(Func<TError> error);
    }

    public interface IToResult<TOk, TError>
    {
        Result<TOk, TError> ToResult();
    }
}