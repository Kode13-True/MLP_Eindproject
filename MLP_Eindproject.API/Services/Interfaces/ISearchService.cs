using MLP_DbLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MLP_Eindproject.API.Services.Interfaces
{
    public interface ISearchService
    {
        List<Lesson> SearchLessons(InstrumentName? instrumentName = null,
                                    InstrumentStyle? instrumentStyle = null,
                                    decimal? price = null,
                                    string postal = "",
                                    string teacherName = "");
    }
}
