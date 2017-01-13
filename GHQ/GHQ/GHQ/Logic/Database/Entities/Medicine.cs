using SQLite;
using System;

namespace GHQ.Logic.Database.Entities
{
    class Medicine
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public bool IsMissed { get; set; }

        public string Name { get; set; }

        public string DoctorName { get; set; }

        public string DiseaseName { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public DateTime NexDate { get; set; }

        public string ImagePath { get; set; }

        public string VoiceNotePath { get; set; }

        public string Note { get; set; }
    }
}
