using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErgastApi.Responses
{
    public interface ISeasonResponse : IErgastResponse
    {

    }

    public class SeasonResponse : ErgastResponse, ISeasonResponse
    {

    }
}
