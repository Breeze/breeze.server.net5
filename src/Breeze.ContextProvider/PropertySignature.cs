using System;
using System.Reflection;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace Breeze.ContextProvider
{

    internal class PropertySignature
    {
        public PropertySignature(Type instanceType, string propertyPath)
        {
            InstanceType = instanceType;
            PropertyPath = propertyPath;
            Properties = GetProperties(InstanceType, PropertyPath).ToList();
        }

        public Type InstanceType { get; private set; }
        public string PropertyPath { get; private set; }
        public List<PropertyInfo> Properties { get; private set; }

        public string Name
        {
            get { return Properties.Select(p => p.Name).ToAggregateString("_"); }
        }

        public Type ReturnType
        {
            get { return Properties.Last().PropertyType; }
        }

        private IEnumerable<PropertyInfo> GetProperties(Type instanceType, string propertyPath)
        {
            var propertyNames = propertyPath.Split('.');

            var nextInstanceType = instanceType;
            foreach (var propertyName in propertyNames)
            {
                var property = GetProperty(nextInstanceType, propertyName);
                yield return property;
                nextInstanceType = property.PropertyType;
            }
        }

        private PropertyInfo GetProperty(Type instanceType, string propertyName)
        {
            var propertyInfo = (PropertyInfo)TypeFns.FindPropertyOrField(instanceType, propertyName,
              BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public);
            if (propertyInfo == null)
            {
                var msg = string.Format("Unable to locate property '{0}' on type '{1}'.", propertyName, instanceType);
                throw new Exception(msg);
            }
            return propertyInfo;
        }

        public Expression BuildMemberExpression(ParameterExpression parmExpr)
        {
            Expression memberExpr = BuildPropertyExpression(parmExpr, Properties.First());
            foreach (var property in Properties.Skip(1))
            {
                memberExpr = BuildPropertyExpression(memberExpr, property);
            }
            return memberExpr;
        }

        public Expression BuildPropertyExpression(Expression baseExpr, PropertyInfo property)
        {
            return Expression.Property(baseExpr, property);
        }
    }
}
