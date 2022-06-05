using Exercises.API.Entities;
using MongoDB.Driver;

namespace Exercises.API.Data
{
    public class ExerciseContextSeed
    {
        public static void SeedData(IMongoCollection<Exercise> exerciseCollection)
        {
            bool existExercises = exerciseCollection.Find(q => true).Any();
            if (!existExercises)
                exerciseCollection.InsertManyAsync(GetPreConfiguredExercises());
        }

        private static IEnumerable<Exercise> GetPreConfiguredExercises()
        {
            return new List<Exercise>
            {
                new Exercise
                {
                    Name = "Bench press",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "bench-press.png"
                },
                new Exercise
                {
                    Name = "Dumbbell row",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "dumbbell-row.png"
                },
                new Exercise
                {
                    Name = "Back squat",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "back-squat.png"
                }
            };
        }
    }
}
