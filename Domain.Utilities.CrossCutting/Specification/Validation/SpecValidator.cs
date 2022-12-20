﻿using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Utilities.Framework.Specification.Validation
{
    public class SpecValidator<T> 
    {
        private readonly IDictionary<string, Rule<T>> _validations = new Dictionary<string, Rule<T>>();

        public ValidationResult Validate(T obj)
        {
            var validationResult = new ValidationResult();

            foreach (var rule in _validations.Keys)
            {
                var validation = _validations[rule];
                if (!validation.Validate(obj))
                    validationResult.Errors.Add(new ValidationFailure(obj.GetType().Name, validation.ErrorMessage));
            }

            return validationResult;
        }

        protected void Add(string name, Rule<T> rule)
        {
            _validations.Add(name, rule);
        }

        protected void Remove(string name)
        {
            _validations.Remove(name);
        }

        protected Rule<T> GetRule(string name)
        {
            _validations.TryGetValue(name, out var rule);
            return rule;
        }
    }
}
