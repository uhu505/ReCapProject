using Core.Utilities.Results.Abstract;
using System.Linq;

namespace Core.Utilities.Business
{
    public class BusinessRules
    {
        public static IResult Run(params IResult[] logics)
        {
            return logics.FirstOrDefault(logic => !logic.Success);
        }
    }
}