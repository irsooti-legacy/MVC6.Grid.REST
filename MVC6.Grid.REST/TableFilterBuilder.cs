using System;

namespace MVC6.Grid.REST
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Dynamic.Core;
    using Microsoft.Extensions.Primitives;
    using MVC6.Grid.REST.Extensions;
    using static MVC6.Grid.REST.Types.FilterTypes;

    namespace ECRM.Loyalty.Core.Helpers
    {
        public class TableFilterBuilder
        {
            public TableFilterBuilder() { }

            public TableFilterBuilder(KeyValuePair<string, StringValues> valuePair)
            {
                SetCondition(valuePair);
            }

            public TableFilterBuilder(IEnumerable<System.Collections.Generic.KeyValuePair<string, Microsoft.Extensions.Primitives.StringValues>> Query)
            {

                foreach (var valuePair in Query.Where(
                    w => w.Key.EndsWith(EQUALS) ||
                    w.Key.EndsWith(CONTAINS) ||
                    w.Key.EndsWith(START_SWITH) ||
                    w.Key.EndsWith(ENDS_WITH) ||
                    w.Key.EndsWith(NOT_EQUALS) ||
                    w.Key.EndsWith(GREATER_THAN) ||
                    w.Key.EndsWith(LESS_THAN_OR_EQUAL) ||
                    w.Key.EndsWith(LESS_THAN) ||
                    w.Key.EndsWith(GREATER_THAN_OR_EQUAL) ||
                    w.Key.EndsWith(EARLIER_THAN) ||
                    w.Key.EndsWith(EARLIER_THAN_OR_EQUAL) ||
                    w.Key.EndsWith(LATER_THAN_OR_EQUAL) ||
                    w.Key.EndsWith(LATER_THAN)
                ))
                {
                    SetCondition(valuePair);
                }


            }


            private void SetCondition(KeyValuePair<string, StringValues> valuePair)
            {
                switch (valuePair.Key)
                {


                    case string op when op.EndsWith(NOT_EQUALS):
                        Field = valuePair.Key.Split(new string[] { NOT_EQUALS }, StringSplitOptions.None).First();
                        Operator = nameof(NOT_EQUALS);

                        break;

                    case string op when op.EndsWith(EQUALS):
                        Field = valuePair.Key.Split(new string[] { EQUALS }, StringSplitOptions.None).First();
                        Operator = nameof(EQUALS);

                        break;

                    case string op when op.EndsWith(CONTAINS):
                        Field = valuePair.Key.Split(new string[] { CONTAINS }, StringSplitOptions.None).First();
                        Operator = nameof(CONTAINS);

                        break;



                    case string op when op.EndsWith(START_SWITH):
                        Field = valuePair.Key.Split(new string[] { START_SWITH }, StringSplitOptions.None).First();
                        Operator = nameof(START_SWITH);

                        break;

                    case string op when op.EndsWith(ENDS_WITH):
                        Field = valuePair.Key.Split(new string[] { ENDS_WITH }, StringSplitOptions.None).First();
                        Operator = nameof(ENDS_WITH);

                        break;


                    case string op when op.EndsWith(GREATER_THAN_OR_EQUAL):
                        Field = valuePair.Key.Split(new string[] { GREATER_THAN_OR_EQUAL }, StringSplitOptions.None).First();
                        Operator = nameof(GREATER_THAN_OR_EQUAL);

                        break;

                    case string op when op.EndsWith(GREATER_THAN):
                        Field = valuePair.Key.Split(new string[] { GREATER_THAN }, StringSplitOptions.None).First();
                        Operator = nameof(GREATER_THAN);

                        break;



                    case string op when op.EndsWith(LESS_THAN_OR_EQUAL):
                        Field = valuePair.Key.Split(new string[] { LESS_THAN_OR_EQUAL }, StringSplitOptions.None).First();
                        Operator = nameof(LESS_THAN_OR_EQUAL);

                        break;


                    case string op when op.EndsWith(LESS_THAN):
                        Field = valuePair.Key.Split(new string[] { LESS_THAN }, StringSplitOptions.None).First();
                        Operator = nameof(LESS_THAN);

                        break;

                    case string op when op.EndsWith(EARLIER_THAN):
                        Field = valuePair.Key.Split(new string[] { EARLIER_THAN }, StringSplitOptions.None).First();
                        Operator = nameof(EARLIER_THAN);

                        break;

                    case string op when op.EndsWith(EARLIER_THAN_OR_EQUAL):
                        Field = valuePair.Key.Split(new string[] { EARLIER_THAN_OR_EQUAL }, StringSplitOptions.None).First();
                        Operator = nameof(EARLIER_THAN_OR_EQUAL);

                        break;

                    case string op when op.EndsWith(LATER_THAN_OR_EQUAL):
                        Field = valuePair.Key.Split(new string[] { LATER_THAN_OR_EQUAL }, StringSplitOptions.None).First();
                        Operator = nameof(LATER_THAN_OR_EQUAL);

                        break;


                    case string op when op.EndsWith(LATER_THAN):
                        Field = valuePair.Key.Split(new string[] { LATER_THAN }, StringSplitOptions.None).First();
                        Operator = nameof(LATER_THAN);

                        break;

                    default:
                        break;
                }

                Value = valuePair.Value;

            }

            public IQueryable<TProp> FilterWithCondition<TProp>(IQueryable<TProp> source) where TProp : class
            {

                if (Field == null || Value == null)
                    return source;

                try
                {
                    switch (Operator)
                    {

                        case nameof(NOT_EQUALS):
                            return source.Where($"{Field} != \"{Value}\"");

                        case nameof(EQUALS):
                            return source.Where($"{Field} == \"{Value}\"");

                        case nameof(CONTAINS):
                            return source.Where($"{Field}.Contains(@0)", Value);

                        case nameof(START_SWITH):
                            return source.Where($"{Field}.StartsWith(@0)", Value);

                        case nameof(ENDS_WITH):
                            return source.Where($"{Field}.EndsWith(@0)", Value);

                        case nameof(GREATER_THAN_OR_EQUAL):
                            return source.Where($"{Field} >= {Value}");

                        case nameof(GREATER_THAN):
                            return source.Where($"{Field} > {Value}");

                        case nameof(LESS_THAN_OR_EQUAL):
                            return source.Where($"{Field} =< {Value}");

                        case nameof(LESS_THAN):
                            return source.Where($"{Field} < {Value}");

                        case nameof(EARLIER_THAN_OR_EQUAL):
                            return source.Where($"{Field} <= @0", DateTime.Parse(Value));

                        case nameof(EARLIER_THAN):
                            return source.Where($"{Field} < @0", DateTime.Parse(Value));

                        case nameof(LATER_THAN_OR_EQUAL):
                            return source.Where($"{Field} >= @0", DateTime.Parse(Value));

                        case nameof(LATER_THAN):
                            return source.Where($"{Field} > @0", DateTime.Parse(Value));

                        default:
                            return source;

                    }
                }

                catch (Exception err)
                {
                    Console.WriteLine(err.Message);
                    return source;
                }
            }



            public string Operator { get; set; }
            private string _Field { get; set; }
            public string Field
            {
                get
                {
                    return _Field.ToPascalCase();
                }

                set
                {
                    _Field = value;
                }
            }
            public string Value { get; set; }
            
        }
    }
}
