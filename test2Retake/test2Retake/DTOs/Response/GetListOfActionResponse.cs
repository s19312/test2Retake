using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test2Retake.DTOs.Responce
{
    public class GetListOfActionResponse
    {
        public int IdAction { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
    }
}
