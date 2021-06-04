using System;

namespace MLP_DbLibrary.Models
{
    public enum LessonLevel
    {
        Novice,
        Intermediate,
        Expert
    }

    public enum InstrumentStyle
    {
        Classic,
        Rock,
        Jazz,
        Pop,
        Reggae
    }

    public enum InstrumentName
    {
        Vocals,
        Piano,
        Guitar,
        Violin,
        Drums,
        Saxophone,
        Fluit,
        Cello,
        Clarinet,
        Trumpet,
        Harp
    }

    public enum PersonType
    {
        Admin = 1, 
        Teacher = 2, 
        Student = 3
    }
    
    public enum AlertType
    {
        Booked,
        Cancelled,
        Rate,
        Report
    }
    
}