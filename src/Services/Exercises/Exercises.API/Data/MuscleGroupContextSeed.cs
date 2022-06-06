using Exercises.API.Entities;
using MongoDB.Driver;

namespace Exercises.API.Data
{
    public class MuscleGroupContextSeed
    {
        public static void SeedData(IMongoCollection<MuscleGroup> muscleGroupsCollection)
        {
            bool existMuscleGroups = muscleGroupsCollection.Find(q => true).Any();
            if (!existMuscleGroups)
                muscleGroupsCollection.InsertManyAsync(GetPreConfiguredExercises());
        }

        private static IEnumerable<MuscleGroup> GetPreConfiguredExercises()
        {
            return new List<MuscleGroup>
            {
                new MuscleGroup
                {
                    Id = "602d2149e773f2a3990b47f5",
                    Name = "Chest",
                    IsMain = false,
                },
                new MuscleGroup
                {
                    Id = "602d2149e773f2a3990b47f6",
                    Name = "Back",
                    IsMain = false,
                },
                new MuscleGroup
                {
                    Id = "602d2149e773f2a3990b47f7",
                    Name = "Biceps",
                    IsMain = false,
                },
                new MuscleGroup
                {
                    Id = "602d2149e773f2a3990b47f8",
                    Name = "Legs",
                    IsMain = false,
                },
                new MuscleGroup
                {
                    Id = "602d2149e773f2a3990b47f9",
                    Name = "Calf",
                    IsMain = false,
                },
            };
        }
    }
}
