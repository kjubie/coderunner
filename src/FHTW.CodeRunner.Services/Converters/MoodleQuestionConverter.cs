using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlEntities = FHTW.CodeRunner.BusinessLogic.Entities;
using EsEntities = FHTW.CodeRunner.ExportService.Entities;

namespace FHTW.CodeRunner.Services.Converters
{
    public class MoodleQuestionConverter : IValueConverter<BlEntities.Exercise, EsEntities.Question>, IValueConverter<EsEntities.Question, BlEntities.Exercise>
    {
        public EsEntities.Question Convert(BlEntities.Exercise sourceMember, ResolutionContext context)
        {
            EsEntities.Question question = new EsEntities.Question();



            return question;
        }

        public BlEntities.Exercise Convert(EsEntities.Question sourceMember, ResolutionContext context)
        {
            throw new NotImplementedException();
        }
    }
}
