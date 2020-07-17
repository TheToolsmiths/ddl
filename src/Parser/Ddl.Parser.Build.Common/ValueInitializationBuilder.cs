using System;
using System.Collections.Generic;

using TheToolsmiths.Ddl.Models.Values;
using TheToolsmiths.Ddl.Parser.Ast.Models.Values;
using TheToolsmiths.Ddl.Parser.Build.Contexts;
using TheToolsmiths.Ddl.Results;

using LiteralValue = TheToolsmiths.Ddl.Models.Literals.LiteralValue;
using ValueInitialization = TheToolsmiths.Ddl.Models.Values.ValueInitialization;

namespace TheToolsmiths.Ddl.Parser.Build.Common
{
    public class ValueInitializationBuilder
    {
        public Result<ValueInitialization> BuildValueInitialization(
            IRootEntryBuildContext context,
            Ast.Models.Values.ValueInitialization astInitialization)
        {
            return astInitialization switch
            {
                EmptyValueInitialization initialization => CreateEmptyInitialization(initialization),
                LiteralValueInitialization initialization => CreateLiteralInitialization(initialization),
                StructValueInitialization initialization => CreateStructInitialization(initialization),
                TypeIdentifierInitialization initialization => CreateTypeInitialization(initialization),
                _ => throw new ArgumentOutOfRangeException(nameof(astInitialization))
            };

            Result<ValueInitialization> CreateEmptyInitialization(EmptyValueInitialization initialization)
            {
                return Result.FromValue<ValueInitialization>(new EmptyInitialization());
            }

            Result<ValueInitialization> CreateLiteralInitialization(LiteralValueInitialization initialization)
            {
                var result = context.CommonBuilders.BuildLiteral(initialization.Literal);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                LiteralValue literal = result.Value;

                return Result.FromValue<ValueInitialization>(new LiteralInitialization(literal));
            }

            Result<ValueInitialization> CreateStructInitialization(StructValueInitialization initialization)
            {
                return Result.FromValue<ValueInitialization>(new EmptyInitialization());
            }

            Result<ValueInitialization> CreateTypeInitialization(TypeIdentifierInitialization initialization)
            {
                return Result.FromValue<ValueInitialization>(new EmptyInitialization());
            }
        }

        public Result<StructInitialization> BuildStructInitialization(
            IRootEntryBuildContext context,
            StructValueInitialization astInitialization)
        {
            var result = this.CreateFieldInitializations(context, astInitialization.Fields);

            if (result.IsError)
            {
                throw new NotImplementedException();
            }

            var fieldInitializations = result.Value;

            var structInitialization = new StructInitialization(fieldInitializations);

            return Result.FromValue(structInitialization);
        }

        private Result<IReadOnlyList<FieldInitialization>> CreateFieldInitializations(
            IRootEntryBuildContext context,
            IEnumerable<FieldValueInitialization> astInitializationFields)
        {
            var initializationFields = new List<FieldInitialization>();

            foreach (var astInitializationField in astInitializationFields)
            {
                var result = this.BuildValueInitialization(context, astInitializationField.Initialization);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                var valueInitialization = result.Value;

                var initializationField = new FieldInitialization(astInitializationField.Name.Text, valueInitialization);

                initializationFields.Add(initializationField);
            }

            return Result.FromValue<IReadOnlyList<FieldInitialization>>(initializationFields);
        }
    }
}
