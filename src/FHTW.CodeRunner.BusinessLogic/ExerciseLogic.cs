using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using FHTW.CodeRunner.BusinessLogic.Interfaces;
using FHTW.CodeRunner.DataAccess.Interfaces;
using BlEntities = FHTW.CodeRunner.BusinessLogic.Entities;
using DalEntities = FHTW.CodeRunner.DataAccess.Entities;

namespace FHTW.CodeRunner.BusinessLogic
{
    public class ExerciseLogic : IExerciseLogic
    {
        private readonly IMapper mapper;
        private readonly IExerciseRepository exerciseRepository;

        public ExerciseLogic(IMapper mapper, IExerciseRepository exerciseRepository)
        {
            this.mapper = mapper;
            this.exerciseRepository = exerciseRepository;
        }

        public BlEntities.Exercise GetTestExercise(int id)
        {
            var dalExercise = this.exerciseRepository.GetExerciseById(id);
            var blExercise = this.mapper.Map<BlEntities.Exercise>(dalExercise);

            return blExercise;
        }
    }
}
