using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLP_DbLibrary.DTO.RatingDTO
{
    public class GiveRatingDTO
    {
        public int LessonId { get; set; }
        public int TeacherId { get; set; }
        public int Rating { get; set; }
    }
}
