using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnifiedQueries.Validators;

namespace UnifiedQueries
{
    public abstract class QuerySpecificationValidator : QuerySpecificationVisitor
    {
        private bool hasError;
        private readonly List<string> errorMessages = new List<string>();

        protected QuerySpecificationValidator(QuerySpecification querySpecification)
            : base(querySpecification)
        { }

        protected void AddError(string message)
        {
            errorMessages.Add(message);
            this.hasError = true;
        }

        public bool HasError
        {
            get { return this.hasError; }
        }

        public IEnumerable<string> ErrorMessages
        {
            get { return this.errorMessages; }
        }

        public int ErrorCount
        {
            get { return this.errorMessages.Count; }
        }

        public bool Validate(bool throwIfHasError = false)
        {
            this.Visit();
            if (this.hasError && throwIfHasError)
            {
                throw new InvalidOperationException(this.ToString());
            }
            return !this.hasError;
        }

        public override string ToString()
        {
            if (this.hasError)
            {
                var sb = new StringBuilder();
                sb.AppendLine("Validation Failed.");
                this.errorMessages.ForEach(p => sb.AppendLine(p));
                return sb.ToString();
            }
            else
                return "Succeeded";
        }

        private static bool Validate(bool throwIfHasError = false, params QuerySpecificationValidator[] validators)
        {
            if (validators == null || validators.Length == 0)
                throw new ArgumentNullException("validators");
            return validators.Aggregate(true, (current, validator) => current && validator.Validate(throwIfHasError));
        }

        public static bool Validate(QuerySpecification querySpecification, bool throwIfHasError = false)
        {
            var validators = new QuerySpecificationValidator[]
            {
                new ExpressionNameTypeValidator(querySpecification)
            };

            return Validate(throwIfHasError, validators);
        }
    }
}
