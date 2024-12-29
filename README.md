# AVISO: conversão de string para enumeração
## AVISO IMPORTANTE SOBRE CONVERSÃO DE STRING

No exercício foi usado a conversão de string para enumeração assim:

``` C#
OrderStatus os = Enum.Parse<OrderStatus>("Delivered");
```

Mas, dependendo da versão do compilador C#, isso pode dar problema. Se for o caso, tente deste jeito:

``` C#
OrderStatus os = (OrderStatus)Enum.Parse(typeof(OrderStatus), "Delivered");
```

Se mesmo assim ainda tiver dando erro, há ainda uma terceira forma:

``` C#
OrderStatus os;
Enum.TryParse("Delivered", out os);
```