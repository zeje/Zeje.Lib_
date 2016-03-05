using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

namespace Zeje.Core
{
    /// <summary>表达式谓语扩展
    /// <![CDATA[http://blog.csdn.net/leewhoee/article/details/8968023]]>
    /// <![CDATA[
    /// 1、构造函数使用True时：
    /// （1）单个AND有效，多个AND有效，当然了True && XX=XX
    /// （2）单个OR无效，多个OR无效：True || XX=True所以无效。
    /// （3）混合时：
    ///     ※(True && XX) || XX1 等于 XX || XX1，有效；
    ///     ※(True || XX) && XX1 等于 True && XX1 等于 XX1，局部有效
    ///     ※(True || XX) || XX1 等于 True||XX1 等于 True，全部无效
    /// 2、构造函数使用False时：和True情况一样 
    /// ]]>
    /// </summary>
    public static class Predicate_
    {
        /// <summary>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Expression<Func<T, bool>> True<T>() { return f => true; }
        /// <summary>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Expression<Func<T, bool>> False<T>() { return f => false; }
        /// <summary>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <param name="merge"></param>
        /// <returns></returns>
        public static Expression<T> Compose<T>(this Expression<T> first, Expression<T> second, Func<Expression, Expression, Expression> merge)
        {
            // build parameter map (from parameters of second to parameters of first)  
            var map = first.Parameters.Select((f, i) => new { f, s = second.Parameters[i] }).ToDictionary(p => p.s, p => p.f);

            // replace parameters in the second lambda expression with parameters from the first  
            var secondBody = ParameterRebinder.ReplaceParameters(map, second.Body);

            // apply composition of lambda expression bodies to parameters from the first expression   
            return Expression.Lambda<T>(merge(first.Body, secondBody), first.Parameters);
        }
        /// <summary>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
        {
            return first.Compose(second, Expression.And);
        }
        /// <summary>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
        {
            return first.Compose(second, Expression.Or);
        }
    }
    /// <summary>
    /// </summary>
    public class ParameterRebinder : ExpressionVisitor
    {
        /// <summary>
        /// </summary>
        private readonly Dictionary<ParameterExpression, ParameterExpression> map;
        /// <summary>
        /// </summary>
        /// <param name="map"></param>
        public ParameterRebinder(Dictionary<ParameterExpression, ParameterExpression> map)
        {
            this.map = map ?? new Dictionary<ParameterExpression, ParameterExpression>();
        }
        /// <summary>
        /// </summary>
        /// <param name="map"></param>
        /// <param name="exp"></param>
        /// <returns></returns>
        public static Expression ReplaceParameters(Dictionary<ParameterExpression, ParameterExpression> map, Expression exp)
        {
            return new ParameterRebinder(map).Visit(exp);
        }
        /// <summary>
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        protected override Expression VisitParameter(ParameterExpression p)
        {
            ParameterExpression replacement;
            if (map.TryGetValue(p, out replacement))
            {
                p = replacement;
            }
            return base.VisitParameter(p);
        }
    }
}
