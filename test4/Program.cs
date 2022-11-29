


class MyClass
{
    public static List<BaseValue> GatherGenerics()
    {
        var parsers = new List<IParser<BaseValue>>();
        parsers.Add(new ParserTypeA());
        parsers.Add(new ParserTypeB());
        var values = ParserClient.ParseString("Parse me!", parsers);
        return values;
    }
}



class BaseValue { }

class ValueTypeA : BaseValue { }

class ValueTypeB : BaseValue { }

class ParserTypeA : IParser<ValueTypeA>
{
    public ValueTypeA Parse(string value)
        => new ValueTypeA();
}

class ParserTypeB : IParser<ValueTypeB>
{
    public ValueTypeB Parse(string value)
        => new ValueTypeB();
}

class ParserClient
{
    public static List<BaseValue> ParseString(string str, List<IParser<BaseValue>> parsers)
    {
        // produce a list of values, one for each parser
    }
}


interface IParser<T> 
{
    public T Parse(string value);
}




