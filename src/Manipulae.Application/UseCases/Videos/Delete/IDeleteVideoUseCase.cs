using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manipulae.Application.UseCases.Videos.Delete
{
    public interface IDeleteVideoUseCase
    {
        Task Execute(long id);
    }
}
