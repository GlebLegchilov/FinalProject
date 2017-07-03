using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using DALInterface.DTO;
using ORM.Models;

namespace DAL.Concrete
{
    class DalToOrmExpressionModifier : ExpressionVisitor
    {
        private static readonly Dictionary<Type, Type> mapper = new Dictionary<Type, Type>()
        {
            { typeof(DalUser), typeof(User) },
            { typeof(DalLot), typeof(Lot) },
            { typeof(DalRole), typeof(Role) },
            { typeof(DalAuction), typeof(Auction) },
            { typeof(DalRate), typeof(Rate) },
            { typeof(DalFeedback), typeof(Feedback) }
        };

        
        private readonly ParameterExpression destParameter;

        public DalToOrmExpressionModifier(ParameterExpression parameter)
        {
            
            this.destParameter = parameter;
        }

        public Expression Modify(Expression expression)
        {
            return Visit(expression);
        }

        protected override Expression VisitParameter(ParameterExpression parameter)
        {
            if (mapper.ContainsKey(parameter.Type))
                return destParameter;

            return base.VisitParameter(parameter);
        }

        protected override Expression VisitMember(MemberExpression member)
        {
            Type exprType = member.Expression.Type;
            if (mapper.ContainsKey(exprType))
            {
                MemberInfo[] members = mapper[exprType].GetMember(member.Member.Name);
                if (members.Length != 1)
                    throw new InvalidCastException($"Cann't casts {exprType} to {mapper[exprType]} in expression tree. {mapper[exprType]} has many {member.Member.Name} members or hasn't it.");
                return Expression.MakeMemberAccess(this.Visit(member.Expression), members[0]);
            }
            return base.VisitMember(member);
        }
    }
}
