// <copyright file="Base64Converter.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BlEntities = FHTW.CodeRunner.BusinessLogic.Entities;
using SvcEntities = FHTW.CodeRunner.Services.DTOs;

namespace FHTW.CodeRunner.Services.Converters
{
    public class Base64Converter : IValueConverter<string, string>
    {
        public string Convert(string sourceMember, ResolutionContext context)
        {
            if (sourceMember == null)
            {
                return null;
            }

            byte[] data = System.Convert.FromBase64String(sourceMember);
            string decodedString = Encoding.UTF8.GetString(data);

            return decodedString;
        }
    }
}
