//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.6.6
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from S:\github\labs-oop\MyExcel\MyExcel\LabCalculator.b4 by ANTLR 4.6.6

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

namespace MyExcel {
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using IToken = Antlr4.Runtime.IToken;
using ParserRuleContext = Antlr4.Runtime.ParserRuleContext;

/// <summary>
/// This class provides an empty implementation of <see cref="ILabCalculatorVisitor{Result}"/>,
/// which can be extended to create a visitor which only needs to handle a subset
/// of the available methods.
/// </summary>
/// <typeparam name="Result">The return type of the visit operation.</typeparam>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.6.6")]
[System.CLSCompliant(false)]
public partial class LabCalculatorBaseVisitor<Result> : AbstractParseTreeVisitor<Result>, ILabCalculatorVisitor<Result> {
	/// <summary>
	/// Visit a parse tree produced by the <c>MultiplicativeExpr</c>
	/// labeled alternative in <see cref="LabCalculatorParser.expression"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitMultiplicativeExpr([NotNull] LabCalculatorParser.MultiplicativeExprContext context) { return VisitChildren(context); }

	/// <summary>
	/// Visit a parse tree produced by the <c>ExponentialExpr</c>
	/// labeled alternative in <see cref="LabCalculatorParser.expression"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitExponentialExpr([NotNull] LabCalculatorParser.ExponentialExprContext context) { return VisitChildren(context); }

	/// <summary>
	/// Visit a parse tree produced by the <c>AdditiveExpr</c>
	/// labeled alternative in <see cref="LabCalculatorParser.expression"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitAdditiveExpr([NotNull] LabCalculatorParser.AdditiveExprContext context) { return VisitChildren(context); }

	/// <summary>
	/// Visit a parse tree produced by the <c>NumberExpr</c>
	/// labeled alternative in <see cref="LabCalculatorParser.expression"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitNumberExpr([NotNull] LabCalculatorParser.NumberExprContext context) { return VisitChildren(context); }

	/// <summary>
	/// Visit a parse tree produced by the <c>IdentifierExpr</c>
	/// labeled alternative in <see cref="LabCalculatorParser.expression"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitIdentifierExpr([NotNull] LabCalculatorParser.IdentifierExprContext context) { return VisitChildren(context); }

	/// <summary>
	/// Visit a parse tree produced by the <c>MminMmaxExpr</c>
	/// labeled alternative in <see cref="LabCalculatorParser.expression"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitMminMmaxExpr([NotNull] LabCalculatorParser.MminMmaxExprContext context) { return VisitChildren(context); }

	/// <summary>
	/// Visit a parse tree produced by the <c>ParenthesizedExpr</c>
	/// labeled alternative in <see cref="LabCalculatorParser.expression"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitParenthesizedExpr([NotNull] LabCalculatorParser.ParenthesizedExprContext context) { return VisitChildren(context); }

	/// <summary>
	/// Visit a parse tree produced by the <c>IncDecExpr</c>
	/// labeled alternative in <see cref="LabCalculatorParser.expression"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitIncDecExpr([NotNull] LabCalculatorParser.IncDecExprContext context) { return VisitChildren(context); }

	/// <summary>
	/// Visit a parse tree produced by <see cref="LabCalculatorParser.compileUnit"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitCompileUnit([NotNull] LabCalculatorParser.CompileUnitContext context) { return VisitChildren(context); }

	/// <summary>
	/// Visit a parse tree produced by <see cref="LabCalculatorParser.expression"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitExpression([NotNull] LabCalculatorParser.ExpressionContext context) { return VisitChildren(context); }
}
} // namespace MyExcel
