// Working with using Microsoft.SqlServer.TransactSql.ScriptDom

// C# Code
string baseSQL = "select * from [DBName].[dbo].[Setting.Member] where ID = @id or Membership in (@membership1, @membership2, @membership3) and CreatedAt between @startDate and @endDate order by ID";
TSql150Parser sql150Parser = new TSql150Parser(true);
IList<ParseError> parseErrors = new List<ParseError>();
TSqlFragment fragment = sql150Parser.Parse(new System.IO.StringReader(baseSQL), out parseErrors);
TSqlScript script = fragment as TSqlScript;
TSqlStatement statement = script.Batches[0].Statements[0];
if (statement is SelectStatement)
{
    QuerySpecification select = ((QuerySpecification)((SelectStatement)statement).QueryExpression);
}

// Immediate Window commands and return values
select.ScriptTokenStream[select.WhereClause.FirstTokenIndex + 2].TokenType == TSqlTokenType.Identifier
true
select.ScriptTokenStream[select.WhereClause.FirstTokenIndex + 2].Text
"ID"
select.ScriptTokenStream[select.WhereClause.FirstTokenIndex + 6].TokenType == TSqlTokenType.Variable
true
select.ScriptTokenStream[select.WhereClause.FirstTokenIndex + 6].Text
"@id"

select.ScriptTokenStream[((NamedTableReference)select.FromClause.TableReferences[0]).SchemaObject.BaseIdentifier.FirstTokenIndex].Text
"[Setting.Member]"
select.ScriptTokenStream[((NamedTableReference)select.FromClause.TableReferences[0]).SchemaObject.DatabaseIdentifier.FirstTokenIndex].Text
"[DBName]"
select.ScriptTokenStream[((NamedTableReference)select.FromClause.TableReferences[0]).SchemaObject.SchemaIdentifier.FirstTokenIndex].Text
"[dbo]"

((BooleanBinaryExpression)select.WhereClause.SearchCondition).BinaryExpressionType
Or
((ColumnReferenceExpression)((BooleanComparisonExpression)((BooleanBinaryExpression)select.WhereClause.SearchCondition).FirstExpression).FirstExpression).MultiPartIdentifier.Identifiers[0].Value
"ID"
((VariableReference)((BooleanComparisonExpression)((BooleanBinaryExpression)select.WhereClause.SearchCondition).FirstExpression).SecondExpression).Name
"@id"
((ColumnReferenceExpression)((InPredicate)((BooleanBinaryExpression)select.WhereClause.SearchCondition).SecondExpression).Expression).MultiPartIdentifier.Identifiers[0].Value
((ColumnReferenceExpression)((InPredicate)((BooleanBinaryExpression)((BooleanBinaryExpression)select.WhereClause.SearchCondition).SecondExpression).FirstExpression).Expression).MultiPartIdentifier.Identifiers[0].Value
"Membership"
((InPredicate)((BooleanBinaryExpression)((BooleanBinaryExpression)select.WhereClause.SearchCondition).SecondExpression).FirstExpression).Values
Count = 3
    [0]: {Microsoft.SqlServer.TransactSql.ScriptDom.VariableReference}
    [1]: {Microsoft.SqlServer.TransactSql.ScriptDom.VariableReference}
    [2]: {Microsoft.SqlServer.TransactSql.ScriptDom.VariableReference}
((VariableReference)((InPredicate)((BooleanBinaryExpression)((BooleanBinaryExpression)select.WhereClause.SearchCondition).SecondExpression).FirstExpression).Values[0]).Name
"@membership1"
((ColumnReferenceExpression)((BooleanTernaryExpression)((BooleanBinaryExpression)((BooleanBinaryExpression)select.WhereClause.SearchCondition).SecondExpression).SecondExpression).FirstExpression).MultiPartIdentifier.Identifiers[0].Value
"CreatedAt"
((VariableReference)((BooleanTernaryExpression)((BooleanBinaryExpression)((BooleanBinaryExpression)select.WhereClause.SearchCondition).SecondExpression).SecondExpression).SecondExpression).Name
"@startDate"
((VariableReference)((BooleanTernaryExpression)((BooleanBinaryExpression)((BooleanBinaryExpression)select.WhereClause.SearchCondition).SecondExpression).SecondExpression).ThirdExpression).Name
"@endDate"